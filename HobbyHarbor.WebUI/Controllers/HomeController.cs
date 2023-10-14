using System.Diagnostics;
using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HobbyHarbor.Core.Entities;
using MediatR;
using HobbyHarbor.Application.Queries;

namespace HobbyHarbor.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public HomeController(ILogger<HomeController> logger, IMapper mapper, IMediator mediator)
		{
			_logger = logger;
			_mapper = mapper;
			_mediator = mediator;
		}

		public IActionResult Index()
		{
			User user = _mediator.Send(new GetFullUserById { Id = 1 }).Result;
			return View(_mapper.Map<ProfileViewModel>(user));
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
	}
}