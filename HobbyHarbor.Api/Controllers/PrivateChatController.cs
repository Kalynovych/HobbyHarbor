using AutoMapper;
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
			ICollection<PrivateChatDTO> privateChatsDTO = _mapper.Map<ICollection<PrivateChatDTO>>(privateChats);

			foreach (var privateChatDTO in privateChatsDTO)
			{
				privateChatDTO.LastMessageAuthor = privateChatDTO.LastMessageAuthor == username ? "you:" : "";
			}

			return Ok(privateChatsDTO);
		}

		[HttpPost]
		public async Task<ActionResult<PrivateChatDTO>> Post([FromBody] object profile)
		{
			//TODO: write post method
			return Ok(new PrivateChatDTO());
		}

		[HttpPut]
		[Route("id")]
		public async Task<ActionResult<PrivateChatDTO>> Put([FromBody] object profile)
		{
			//TODO: write put method
			return Ok(new PrivateChatDTO());
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult<PrivateChatDTO>> Delete([FromRoute] int id)
		{
			//TODO: write delete method
			return Ok(new PrivateChatDTO());
		}
	}
}
