using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("/api/v1/posts")]
	public class PostController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public PostController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[Route("{creatorId}")]
		public async Task<ActionResult<ICollection<PostDTO>>> Get([FromRoute] int creatorId)
		{
			var posts = await _mediator.Send(new GetPostsByCreatorId { Id = creatorId, Take = 10 });
			if (posts == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ICollection<PostDTO>>(posts));
		}

		[HttpPost]
		public async Task<ActionResult<PostDTO>> Post([FromBody] object post)
		{
			//TODO: write post method
			return Ok(new PostDTO());
		}

		[HttpPut]
		[Route("id")]
		public async Task<ActionResult<PostDTO>> Put([FromBody] object post)
		{
			//TODO: write put method
			return Ok(new PostDTO());
		}

		[HttpDelete]
		[Route("id")]
		public async Task<ActionResult<PostDTO>> Delete([FromBody] int id)
		{
			//TODO: write delete method
			return Ok(new PostDTO());
		}
	}
}
