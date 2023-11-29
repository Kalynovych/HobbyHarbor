using AutoMapper;
using HobbyHarbor.Application.DTOs;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.Controllers
{
	public class ChatController : Controller
	{
		private readonly IMapper _mapper;

		public ChatController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreatePrivateChat([FromQuery] string companionUsername)
		{
			HttpClient client = await GetAuthorizedClient();

			string creatorUsername = User.FindFirst("name")?.Value;
			PrivateChatDTO privateChatDTO = new PrivateChatDTO { CreatorUsername = creatorUsername, CompanionUsername = companionUsername };
			var response = await client.PostAsJsonAsync($"privateChats", privateChatDTO);
			if (response.IsSuccessStatusCode)
			{
				var privateChat = await response.Content.ReadAsStringAsync();
				return Ok(privateChat);
			}

			return StatusCode((int)response.StatusCode);

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

		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> DeletePublicChat([FromQuery] int publicChatId)
		{
			HttpClient client = await GetAuthorizedClient();

			var response = await client.DeleteAsync($"publicChats/{publicChatId}");
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
