using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace HobbyHarbor.WebUI.Hubs
{
	public class PublicChatHub : Hub
	{
		private readonly IMapper _mapper;

		public PublicChatHub(IMapper mapper)
		{
			_mapper = mapper;
		}

		[Authorize]
		public async Task SendMessage(PublicMessageInputModel message)
		{
			HttpClient client = await GetAuthorizedClient();

			message.AuthorUsername = Context.User.FindFirst("name")?.Value;
			message.Time = DateTime.Now;

			var response = await client.PostAsJsonAsync("messages/public", _mapper.Map<PublicMessageDTO>(message));
			PublicMessageViewModel messageViewModel = null;
			if (response.IsSuccessStatusCode)
			{
				PublicMessageDTO publicMessageDTO = await response.Content.ReadFromJsonAsync<PublicMessageDTO>();
				messageViewModel = _mapper.Map<PublicMessageViewModel>(publicMessageDTO);
			}

			await Clients.Users(messageViewModel.Participants).SendAsync("ReceiveMessage", messageViewModel.Id);
		}

		[Authorize]
		public async Task EditMessage(PublicMessageViewModel message)
		{
			await Clients.Users(message.Participants).SendAsync("ReceiveEditedMessage", message);
		}

		[Authorize]
		public async Task DeleteMessage(PublicMessageViewModel message)
		{
			await Clients.Users(message.Participants).SendAsync("DeleteMessage", message.Id);
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
