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
	[Route("/api/v1/privateChats")]
	public class PrivateChatController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public PrivateChatController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[Route("{username}")]
		public async Task<ActionResult<ICollection<PrivateChatDTO>>> Get([FromRoute] string username)
		{
			ICollection<PrivateChat> privateChats = await _mediator.Send(new GetPrivateChatsByUsername { Username = username });
			if (privateChats == null)
			{
				return NotFound();
			}

			ICollection<PrivateChatDTO> privateChatsDTO = _mapper.Map<ICollection<PrivateChatDTO>>(privateChats);
			return Ok(privateChatsDTO);
		}

		[HttpPost]
		public async Task<ActionResult<PrivateChatDTO>> Post([FromBody] object chat)
		{
			PrivateChatDTO privateChatDTO = JsonConvert.DeserializeObject<PrivateChatDTO>(chat.ToString());
			User creator = await _mediator.Send(new GetUserByUsername { Username = privateChatDTO.CreatorUsername });
			User companion = await _mediator.Send(new GetUserByUsername { Username = privateChatDTO.CompanionUsername });

			if (creator != null && companion != null)
			{
				PrivateChat privateChat = new PrivateChat { Creator = creator, Companion = companion };
				PrivateChat newPrivateChat = await _mediator.Send(new CreatePrivateChat { PrivateChat = privateChat });

				return Ok(_mapper.Map<PrivateChatDTO>(newPrivateChat));
			}

			return Forbid();
		}

		[HttpDelete]
		[Route("{creatorId}/{companionId}")]
		public async Task<ActionResult> Delete([FromRoute] int creatorId, [FromRoute] int companionId)
		{
			PrivateChat privateChat = await _mediator.Send(new GetPrivateChatById { CreatorId = creatorId, CompanionId = companionId });
			if (privateChat == null)
				return BadRequest();

			(int, int) result = await _mediator.Send(new DeletePrivateChat { PrivateChat = privateChat });
			return Ok(result);
		}
	}
}
