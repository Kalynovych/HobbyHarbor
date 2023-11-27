using System.Diagnostics;
using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using HobbyHarbor.Application.DTOs;
using System.Net;

namespace HobbyHarbor.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMapper _mapper;
		private readonly IHttpClientFactory _httpClientFactory;

		public HomeController(ILogger<HomeController> logger, IMapper mapper, IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
			_mapper = mapper;
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				HttpClient client = await GetAuthorizedClient();

				var response = await client.GetAsync("users/" + GetUsername());
				if (response.StatusCode == HttpStatusCode.Unauthorized)
				{
					return RedirectToAction("Logout");
				}

				ProfileDTO user = new();
				if (response.IsSuccessStatusCode)
				{
					user = await response.Content.ReadFromJsonAsync<ProfileDTO>();
				}
				else if (response.StatusCode == HttpStatusCode.NotFound)
				{
					response = await client.PostAsJsonAsync("users", new ProfileDTO { Username = GetUsername(), Email = GetEmail() });
					if (response.IsSuccessStatusCode)
					{
						user = await response.Content.ReadFromJsonAsync<ProfileDTO>();
					}
				}

				response = await client.GetAsync("posts/" + user.Id);
				if (response.IsSuccessStatusCode)
				{
					user.Posts = await response.Content.ReadFromJsonAsync<ICollection<PostDTO>>();
				}

				return View(_mapper.Map<ProfileViewModel>(user));
			}

			return View();
		}

		[Authorize]
		public async Task<IActionResult> PrivateChats()
		{
			HttpClient client = await GetAuthorizedClient();
			var response = await client.GetAsync("privateChats/" + GetUsername());
			if (response.IsSuccessStatusCode)
			{
				var privateChats = await response.Content.ReadFromJsonAsync<ICollection<PrivateChatDTO>>();

				return View(_mapper.Map<ICollection<PrivateChatViewModel>>(privateChats));
			}

			return View("Error");
		}

		[Authorize]
		public async Task<IActionResult> PublicChats()
		{
			HttpClient client = await GetAuthorizedClient();
			var response = await client.GetAsync("publicChats/" + GetUsername());
			if (response.IsSuccessStatusCode)
			{
				var publicChats = await response.Content.ReadFromJsonAsync<ICollection<PublicChatDTO>>();

				return View(_mapper.Map<ICollection<PublicChatViewModel>>(publicChats));
			}

			return View("Error");
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

		private string GetUsername()
		{
			return User.FindFirst("name")?.Value;
		}

		private string GetEmail()
		{
			return User.FindFirst("email")?.Value;
		}

		[Authorize]
		public async Task<HttpClient> GetAuthorizedClient()
		{
			await RefreshTokenAsync();
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			
			var client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7071/api/v1/");
			client.SetBearerToken(accessToken);

			return client;
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
				GrantType = "refresh_token",
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