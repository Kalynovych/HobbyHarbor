﻿using AutoMapper;
using HobbyHarbor.Application.DTOs;
using HobbyHarbor.WebUI.Models;
using HobbyHarbor.WebUI.ViewComponents;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.Controllers
{
	public class MessageController : Controller
	{
		private readonly IMapper _mapper;

		public MessageController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetPrivateMessages([FromQuery] int creatorId, [FromQuery] int companionId)
		{
			HttpClient client = await GetAuthorizedClient();

			var response = await client.GetAsync($"messages/private/chat/{creatorId}/{companionId}");
			return await GetMessageViewComponent(response);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetPublicMessages([FromQuery] int publicChatId)
		{
			HttpClient client = await GetAuthorizedClient();

			var response = await client.GetAsync($"messages/public/chat/{publicChatId}");
			return await GetMessageViewComponent(response);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetMessage([FromQuery] int id)
		{
			HttpClient client = await GetAuthorizedClient();

			var response = await client.GetAsync($"messages/{id}");
			MessageViewModel messageViewModel = null;
			if (response.IsSuccessStatusCode)
			{
				var messageDTO = await response.Content.ReadFromJsonAsync<MessageDTO>();
				messageViewModel = _mapper.Map<MessageViewModel>(messageDTO);
			}

			return ViewComponent(typeof(MessageViewComponent), messageViewModel);
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> EditPrivateMessage([FromBody] PrivateMessageViewModel message)
		{
			message.AuthorUsername = User.FindFirst("name")?.Value;
			HttpClient client = await GetAuthorizedClient();

			var response = await client.PutAsJsonAsync("messages/private", _mapper.Map<PrivateMessageDTO>(message));
			PrivateMessageViewModel messageViewModel;
			if (response.IsSuccessStatusCode)
			{
				var messageDTO = await response.Content.ReadFromJsonAsync<PrivateMessageDTO>();
				messageViewModel = _mapper.Map<PrivateMessageViewModel>(messageDTO);
				return Ok(messageViewModel);
			}

			return Forbid();
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> EditPublicMessage([FromBody] PublicMessageViewModel message)
		{
			message.AuthorUsername = User.FindFirst("name")?.Value;
			HttpClient client = await GetAuthorizedClient();

			var response = await client.PutAsJsonAsync("messages/public", _mapper.Map<PublicMessageDTO>(message));
			PublicMessageViewModel messageViewModel;
			if (response.IsSuccessStatusCode)
			{
				var messageDTO = await response.Content.ReadFromJsonAsync<PublicMessageDTO>();
				messageViewModel = _mapper.Map<PublicMessageViewModel>(messageDTO);
				return Ok(messageViewModel);
			}

			return Forbid();
		}

		[HttpDelete]
		[Authorize]
		public async Task<IActionResult> DeleteMessage([FromQuery] int id, [FromQuery] bool isPublic)
		{
			HttpClient client = await GetAuthorizedClient();

			var response = await client.GetAsync($"messages/{id}");
			if (response.IsSuccessStatusCode)
			{
				var messageDTO = await response.Content.ReadFromJsonAsync<MessageDTO>();
				if (messageDTO != null && messageDTO.AuthorUsername != User.FindFirst("name")?.Value)
					return Forbid();
			}

			if (isPublic)
			{
				response = await client.DeleteAsync($"messages/public/{id}");
				if (response.IsSuccessStatusCode)
				{
					var message = await response.Content.ReadFromJsonAsync<PublicMessageDTO>();
					return Ok(_mapper.Map<PublicMessageViewModel>(message));
				}
			}
			else
			{
				response = await client.DeleteAsync($"messages/private/{id}");
				if (response.IsSuccessStatusCode)
				{
					var message = await response.Content.ReadFromJsonAsync<PrivateMessageDTO>();
					return Ok(_mapper.Map<PrivateMessageViewModel>(message));
				}
			}

			return NotFound();
		}

		private async Task<IActionResult> GetMessageViewComponent(HttpResponseMessage response)
		{
			ICollection<MessageViewModel> messageViewModels = null;
			if (response.IsSuccessStatusCode)
			{
				var messagesDTOs = await response.Content.ReadFromJsonAsync<ICollection<MessageDTO>>();
				messageViewModels = _mapper.Map<ICollection<MessageViewModel>>(messagesDTOs);
			}
			if (messageViewModels.Count == 0)
			{
				return Ok();
			}

			return ViewComponent(typeof(MessagesListViewComponent), messageViewModels);
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
