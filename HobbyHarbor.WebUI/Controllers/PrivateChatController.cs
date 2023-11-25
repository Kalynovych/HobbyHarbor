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
	public class PrivateChatController : Controller
	{
		private readonly IMapper _mapper;

		public PrivateChatController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> DeletePrivateChat([FromQuery] int creatorId, [FromQuery] int companionId)
		{
			HttpClient client = await GetAuthorizedClient();

			var response = await client.DeleteAsync($"privateChats/{creatorId}/{companionId}");
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
