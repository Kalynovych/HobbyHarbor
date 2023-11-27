using AutoMapper;
using HobbyHarbor.Application.Commands;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/v1/publicChats")]
	public class PublicChatController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public PublicChatController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[Route("{username}")]
		public async Task<ActionResult<ICollection<PublicChatDTO>>> Get([FromRoute] string username)
		{
			ICollection<PublicChat> publicChats = await _mediator.Send(new GetPublicChatsByUsername { Username = username });
			if (publicChats == null)
			{
				return NotFound();
			}

			ICollection<PublicChatDTO> publicChatsDTO = _mapper.Map<ICollection<PublicChatDTO>>(publicChats);
			return Ok(publicChatsDTO);
		}

		[HttpPost]
		public async Task<ActionResult<PrivateChatDTO>> Post([FromBody] object profile)
		{
			//TODO: write post method
			return Ok(new PrivateChatDTO());
		}
		
		[HttpDelete]
		[Route("{publicChatId}/")]
		public async Task<ActionResult> Delete([FromRoute] int publicChatId)
		{
			PublicChat publicChat = await _mediator.Send(new GetPublicChatById { Id = publicChatId });
			if (publicChat == null)
				return BadRequest();

			int result = await _mediator.Send(new DeletePublicChat { PublicChat = publicChat });
			return Ok(result);
		}
	}
}
