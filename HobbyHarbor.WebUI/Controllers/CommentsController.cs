using AutoMapper;
using HobbyHarbor.Application.Queries;
using HobbyHarbor.Core.Entities;
using HobbyHarbor.WebUI.Models;
using HobbyHarbor.WebUI.ViewComponents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.Controllers
{
	public class CommentsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public CommentsController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetComments([FromQuery] int postId)
		{
			IEnumerable<Comment> comments = await _mediator.Send(new GetCommentsByPostId { Id = postId, Take = 10 });
			var commentViewModels = _mapper.Map<IEnumerable<CommentViewModel>>(comments);
			return ViewComponent(typeof(CommentsListViewComponent), commentViewModels);
		}

		[HttpGet]
		public async Task<IActionResult> GetReplies([FromQuery] int commentId)
		{
			IEnumerable<Comment> comments = await _mediator.Send(new GetRepliesByCommentId { Id = commentId });
			var commentViewModels = _mapper.Map<IEnumerable<CommentViewModel>>(comments);
			return ViewComponent(typeof(CommentsListViewComponent), commentViewModels);
		}
	}
}
