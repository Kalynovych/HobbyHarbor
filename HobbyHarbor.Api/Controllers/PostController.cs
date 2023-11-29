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

		[HttpGet]
		[Route("{id}/reaction/{username}")]
		public async Task<ActionResult<bool?>> GetReaction([FromRoute] int id, [FromRoute] string username)
		{
			bool? reaction = await _mediator.Send(new GetUserPostReaction { Id = id, Username = username });

			return Ok(reaction);
		}

		[HttpPut]
		[Route("{id}/reaction/{username}")]
		public async Task<ActionResult<int>> PutReaction([FromBody] bool value, [FromRoute] int id, [FromRoute] string username)
		{
			User user = await _mediator.Send(new GetUserByUsername { Username = username });
			PostsReaction reaction = new PostsReaction { User = user, UserId = user.Id, PostId = id, IsLiked = value };
			await _mediator.Send(new UpdateUserPostReaction { PostsReaction = reaction });
			(int, int) reactions = await _mediator.Send(new GetReactions { PostId = id });

			return Ok(new { likes = reactions.Item1, dislikes = reactions.Item2 });
		}

		[HttpDelete]
		[Route("{id}/reaction/{username}")]
		public async Task<ActionResult<int>> DeleteReaction([FromRoute] int id, [FromRoute] string username)
		{
			User user = await _mediator.Send(new GetUserByUsername { Username = username });
			PostsReaction reaction = new PostsReaction { User = user, UserId = user.Id, PostId = id };
			await _mediator.Send(new DeleteUserPostReaction { PostsReaction = reaction });
			(int, int) reactions = await _mediator.Send(new GetReactions { PostId = id });

			return Ok(new { likes = reactions.Item1, dislikes = reactions.Item2 });
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
