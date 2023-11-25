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
		public async Task<ActionResult<PrivateChatDTO>> Post([FromBody] object profile)
		{
			//TODO: write post method
			return Ok(new PrivateChatDTO());
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
