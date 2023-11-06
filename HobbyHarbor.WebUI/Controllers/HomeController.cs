﻿using System.Diagnostics;
using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HobbyHarbor.Core.Entities;
using MediatR;
using HobbyHarbor.Application.Queries;
using Microsoft.AspNetCore.Authentication;
using IdentityModel.Client;
using HobbyHarbor.Application.Commands;

namespace HobbyHarbor.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;
		private readonly IHttpClientFactory _httpClientFactory;

		public HomeController(ILogger<HomeController> logger, IMapper mapper, IMediator mediator, IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
			_mapper = mapper;
			_mediator = mediator;
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var username = User.Claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault();

				User user = await _mediator.Send(new GetUserByUsername { Username = username });
				if (user == null)
				{
					var email = User.Claims.Where(x => x.Type == "email").Select(x => x.Value).FirstOrDefault();
					user = await _mediator.Send(new CreateUser { UserName = username, Email = email });
				}

				user.Posts = await _mediator.Send(new GetPostsByCreatorId { Id = user.Id, Take = 10 });
				return View(_mapper.Map<ProfileViewModel>(user));
			}

			return View();
		}

		public async Task<IActionResult> Login()
		{
			return Challenge(new AuthenticationProperties { RedirectUri = "/" });
		}

		public async Task<IActionResult> Logout()
		{
			return SignOut("Cookie", "oidc");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private async Task CreateLocalUserAsync()
		{

		}

		private async Task RefreshTokenAsync()
		{
			var serverClient = _httpClientFactory.CreateClient();
			var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:5001/");


			var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
			var refreshTokenClient = _httpClientFactory.CreateClient();

			var tokenResponse = await refreshTokenClient.RequestRefreshTokenAsync(new RefreshTokenRequest
			{
				Address = discoveryDocument.TokenEndpoint,
				RefreshToken = refreshToken,
				ClientId = "client_mvc",
				ClientSecret = "client_secret"
			});

			var authInfo = await HttpContext.AuthenticateAsync("Cookie");
			authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
			authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);

			await HttpContext.SignInAsync("Cookie", authInfo.Principal, authInfo.Properties);
		}
	}
}