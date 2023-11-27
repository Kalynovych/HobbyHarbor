using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace HobbyHarbor.WebUI.Hubs
{
	public class PrivateChatHub : Hub
	{
		private readonly IMapper _mapper;

		public PrivateChatHub(IMapper mapper)
		{
			_mapper = mapper;
		}

		[Authorize]
		public async Task SendMessage(PrivateMessageInputModel message)
		{
			HttpClient client = await GetAuthorizedClient();

			message.AuthorUsername = Context.User.FindFirst("name")?.Value;
			message.Time = DateTime.Now;

			var response = await client.PostAsJsonAsync("messages/private", _mapper.Map<PrivateMessageDTO>(message));
			PrivateMessageViewModel messageViewModel = null;
			if (response.IsSuccessStatusCode)
			{
				PrivateMessageDTO privateMessageDTO = await response.Content.ReadFromJsonAsync<PrivateMessageDTO>();
				messageViewModel = _mapper.Map<PrivateMessageViewModel>(privateMessageDTO);
			}

			await Clients.Users(message.AuthorUsername, messageViewModel.CompanionUsername).SendAsync("ReceiveMessage", messageViewModel.Id);
		}

		[Authorize]
		public async Task EditMessage(PrivateMessageViewModel message)
		{
			await Clients.Users(message.AuthorUsername, message.CompanionUsername).SendAsync("ReceiveEditedMessage", message);
		}

		[Authorize]
		public async Task DeleteMessage(PrivateMessageViewModel message)
		{
			string username = Context.User.FindFirst("name")?.Value;
			await Clients.Users(username, message.CompanionUsername).SendAsync("DeleteMessage", message.Id);
		}

		[Authorize]
		public async Task<HttpClient> GetAuthorizedClient()
		{
			var accessToken = await Context.GetHttpContext().GetTokenAsync("access_token");

			var client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071/api/v1/");
			client.SetBearerToken(accessToken);
			return client;
		}
	}
}
