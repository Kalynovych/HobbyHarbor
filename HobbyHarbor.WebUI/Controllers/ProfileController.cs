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
	public class ProfileController : Controller
	{
		private readonly IMapper _mapper;

		public ProfileController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetProfile([FromQuery] int skip)
		{
			HttpClient client = await GetAuthorizedClient();

			string username = User.FindFirst("name")?.Value;
			var response = await client.GetAsync($"users/except/{username}/{skip}");
			ProfileViewModel profileViewModel = null;
			if (response.IsSuccessStatusCode)
			{
				var profile = await response.Content.ReadFromJsonAsync<ProfileDTO>();
				profileViewModel = _mapper.Map<ProfileViewModel>(profile);
			}

			return profileViewModel == null ? NotFound() : ViewComponent(typeof(SearchProfileViewComponent), profileViewModel);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostChoice([FromQuery] string target, [FromQuery] bool isLiked)
		{
			HttpClient client = await GetAuthorizedClient();

			string user = User.FindFirst("name")?.Value;
			var response = await client.PostAsJsonAsync($"users/choice/{user}/{target}", isLiked);
			if (response.IsSuccessStatusCode)
			{
				return Ok();
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
