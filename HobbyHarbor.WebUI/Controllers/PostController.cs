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
	public class PostController : Controller
	{
		private readonly IMapper _mapper;

		public PostController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> PutReaction([FromBody] PostReactionInputModel inputModel)
		{
			HttpClient client = await GetAuthorizedClient();

			string username = User.FindFirst("name")?.Value;
			var response = await client.PutAsJsonAsync($"posts/{inputModel.PostId}/reaction/{username}", inputModel.Reaction);
			if (response.IsSuccessStatusCode)
			{
				return Ok(await response.Content.ReadAsStringAsync());
			}

			return StatusCode((int)response.StatusCode);
		}

		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> DeleteReaction([FromQuery] int postId)
		{
			HttpClient client = await GetAuthorizedClient();

			string username = User.FindFirst("name")?.Value;
			var response = await client.DeleteAsync($"posts/{postId}/reaction/{username}");
			if (response.IsSuccessStatusCode)
			{
				return Ok(await response.Content.ReadAsStringAsync());
			}

			return StatusCode((int)response.StatusCode);
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
