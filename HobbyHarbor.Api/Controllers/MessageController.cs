using AutoMapper;
using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HobbyHarbor.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/v1/messages")]
	public class MessageController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public MessageController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<MessageDTO>> Get([FromRoute] int id)
		{
			Message message = await _mediator.Send(new GetMessageById { Id = id });
			if (message == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<MessageDTO>(message));
		}

		[HttpGet]
		[Route("private/chat/{creatorId}/{companionId}")]
		public async Task<ActionResult<ICollection<PrivateMessageDTO>>> GetPrivateMessages([FromRoute] int creatorId, [FromRoute] int companionId)
		{
			ICollection<PrivateMessage> messages = await _mediator.Send(new GetPrivateMessagesById { CreatorId = creatorId, CompanionId = companionId });
			if (messages == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ICollection<PrivateMessageDTO>>(messages));
		}

		[HttpGet]
		[Route("public/chat/{id}")]
		public async Task<ActionResult<ICollection<PrivateMessageDTO>>> GetPublicMessages([FromRoute] int id)
		{
			ICollection<PublicMessage> messages = await _mediator.Send(new GetPublicMessagesById { Id = id });
			if (messages == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ICollection<PublicMessageDTO>>(messages));
		}

		[HttpPost]
		[Route("private")]
		public async Task<ActionResult<PrivateMessageDTO>> PostPrivate([FromBody] object message)
		{
			PrivateMessageDTO privateMessageDTO = JsonConvert.DeserializeObject<PrivateMessageDTO>(message.ToString());
			User creator = await _mediator.Send(new GetUserById { Id = privateMessageDTO.CreatorId });
			User companion = await _mediator.Send(new GetUserById { Id = privateMessageDTO.CompanionId });
			Message replyTo = await _mediator.Send(new GetMessageById { Id = privateMessageDTO.ReplyMessageId });

			privateMessageDTO.MessageAuthorId = creator.Username == privateMessageDTO.AuthorUsername ? creator.Id : companion.Id;
			PrivateMessage newMessage = _mapper.Map<PrivateMessage>(privateMessageDTO);
			newMessage.ReplyTo = replyTo;
			PrivateMessage privateMessage = await _mediator.Send(new CreatePrivateMessage { Message = newMessage });

			return Ok(_mapper.Map<PrivateMessageDTO>(privateMessage));
		}

		[HttpPost]
		[Route("public")]
		public async Task<ActionResult<PublicMessageDTO>> PostPublic([FromBody] object message)
		{
			PublicMessageDTO publicMessageDTO = JsonConvert.DeserializeObject<PublicMessageDTO>(message.ToString());
			User author = await _mediator.Send(new GetUserByUsername { Username = publicMessageDTO.AuthorUsername });
			Message replyTo = await _mediator.Send(new GetMessageById { Id = publicMessageDTO.ReplyMessageId });

			publicMessageDTO.MessageAuthorId = author.Id;
			PublicMessage newMessage = _mapper.Map<PublicMessage>(publicMessageDTO);
			newMessage.ReplyTo = replyTo;
			PublicMessage publicMessage = await _mediator.Send(new CreatePublicMessage { Message = newMessage });
			publicMessage.PublicChat = await _mediator.Send(new GetPublicChatById { Id = publicMessage.PublicChatId });

			return Ok(_mapper.Map<PublicMessageDTO>(publicMessage));
		}

		[HttpPut]
		[Route("private")]
		public async Task<ActionResult<PrivateMessageDTO>> PutPrivate([FromBody] object message)
		{
			PrivateMessageDTO privateMessageDTO = JsonConvert.DeserializeObject<PrivateMessageDTO>(message.ToString());
			PrivateMessage existingMessage = await _mediator.Send(new GetPrivateMessageByMessageId { Id = privateMessageDTO.Id });

			if (existingMessage != null && existingMessage.MessageAuthor.Username == privateMessageDTO.AuthorUsername)
			{
				existingMessage.MessageText = privateMessageDTO.MessageText;
				await _mediator.Send(new UpdateMessage { Message = existingMessage });
				return Ok(_mapper.Map<PrivateMessageDTO>(existingMessage));
			}

			return Forbid();
		}

		[HttpPut]
		[Route("public")]
		public async Task<ActionResult<PublicMessageDTO>> PutPublic([FromBody] object message)
		{
			PublicMessageDTO publicMessageDTO = JsonConvert.DeserializeObject<PublicMessageDTO>(message.ToString());
			PublicMessage existingMessage = await _mediator.Send(new GetPublicMessageById { Id = publicMessageDTO.Id });

			if (existingMessage != null && existingMessage.MessageAuthor.Username == publicMessageDTO.AuthorUsername)
			{
				existingMessage.MessageText = publicMessageDTO.MessageText;
				await _mediator.Send(new UpdateMessage { Message = existingMessage });
				return Ok(_mapper.Map<PublicMessageDTO>(existingMessage));
			}

			return Forbid();
		}

		[HttpDelete]
		[Route("private/{id}")]
		public async Task<ActionResult<PrivateMessageDTO>> DeletePrivate([FromRoute] int id)
		{
			PrivateMessage message = await _mediator.Send(new GetPrivateMessageByMessageId { Id = id });
			if (message == null)
				return BadRequest();

			await _mediator.Send(new DeleteMessage { Message = message });
			return Ok(_mapper.Map<PrivateMessageDTO>(message));
		}

		[HttpDelete]
		[Route("public/{id}")]
		public async Task<ActionResult<PublicMessageDTO>> DeletePublic([FromRoute] int id)
		{
			PublicMessage message = await _mediator.Send(new GetPublicMessageById { Id = id });
			if (message == null)
				return BadRequest();

			await _mediator.Send(new DeleteMessage { Message = message });
			return Ok(_mapper.Map<PublicMessageDTO>(message));
		}
	}
}
