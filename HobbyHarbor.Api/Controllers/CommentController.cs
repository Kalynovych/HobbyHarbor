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
	[Route("/api/v1/comments")]
	public class CommentController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public CommentController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		[Route("{postId}")]
		public async Task<ActionResult<ICollection<CommentDTO>>> Get([FromRoute] int postId)
		{
			ICollection<Comment> comments = await _mediator.Send(new GetCommentsByPostId { Id = postId, Take = 10 });
			if (comments == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ICollection<CommentDTO>>(comments));
		}

		[HttpGet]
		[Route("{id}/replies")]
		public async Task<ActionResult<ICollection<CommentDTO>>> GetReplies([FromRoute] int id)
		{
			ICollection<Comment> comments = await _mediator.Send(new GetRepliesByCommentId { Id = id });
			if (comments == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ICollection<CommentDTO>>(comments));
		}
	}
}
