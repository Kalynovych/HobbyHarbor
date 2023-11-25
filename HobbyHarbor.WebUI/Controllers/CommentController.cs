using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;
using HobbyHarbor.WebUI.ViewComponents;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.Controllers
{
	public class CommentController : Controller
	{
		private readonly IMapper _mapper;

		public CommentController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetComments([FromQuery] int postId)
		{
			HttpClient client = await GetAuthorizedClient();
			var response = await client.GetAsync("comments/" + postId);
			ICollection<CommentViewModel> commentViewModels = null;
			if (response.IsSuccessStatusCode)
			{
				var commentDTOs = await response.Content.ReadFromJsonAsync<ICollection<CommentDTO>>();
				commentViewModels = _mapper.Map<ICollection<CommentViewModel>>(commentDTOs);
			}

			return ViewComponent(typeof(CommentsListViewComponent), commentViewModels);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetReplies([FromQuery] int commentId)
		{
			HttpClient client = await GetAuthorizedClient();
			var response = await client.GetAsync($"comments/{commentId}/replies");
			ICollection<CommentViewModel> commentViewModels = null;
			if (response.IsSuccessStatusCode)
			{
				var commentDTOs = await response.Content.ReadFromJsonAsync<ICollection<CommentDTO>>();
				commentViewModels = _mapper.Map<ICollection<CommentViewModel>>(commentDTOs);
			}

			return ViewComponent(typeof(CommentsListViewComponent), commentViewModels);
		}

		[Authorize]
		public async Task<HttpClient> GetAuthorizedClient()
		{
			var accessToken = await HttpContext.GetTokenAsync("access_token");

			var client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071/api/v1/");
			client.SetBearerToken(accessToken);

			return client;
		}
	}
}
