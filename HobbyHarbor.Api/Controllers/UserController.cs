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
	[Route("/api/v1/users")]
	public class UserController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public UserController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[Route("{username}")]
		public async Task<ActionResult<ProfileDTO>> Get([FromRoute] string username)
		{
			User user = await _mediator.Send(new GetUserByUsername { Username = username });
			if (user == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ProfileDTO>(user));
		}

		[HttpPost]
		public async Task<ActionResult<ProfileDTO>> Post([FromBody] object profile)
		{
			ProfileDTO userProfile = JsonConvert.DeserializeObject<ProfileDTO>(profile.ToString());
			User user = await _mediator.Send(new CreateUser { UserName = userProfile.Username, Email = userProfile.Email });
			return Ok(_mapper.Map<ProfileDTO>(user));
		}

		[HttpPut]
		[Route("id")]
		public async Task<ActionResult<ProfileDTO>> Put([FromBody] object profile)
		{
			//TODO: write put method
			return Ok(new ProfileDTO());
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult<ProfileDTO>> Delete([FromRoute] int id)
		{
			//TODO: write delete method
			return Ok(new ProfileDTO());
		}
	}
}
