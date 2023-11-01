using AutoMapper;
using Microsoft.Extensions.Localization;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class OnlineStatusValueConverter : IValueConverter<DateTime, string>
	{
		private readonly IStringLocalizer<CommonResources> _localizer;

		public OnlineStatusValueConverter(IStringLocalizer<CommonResources> localizer)
		{
			_localizer = localizer;
		}

		public string Convert(DateTime lastActivity, ResolutionContext context)
		{
			var passedTime = DateTime.Now - lastActivity;
			string result = "";
			if (passedTime.Days > 0) result = $"{passedTime.Days} {_localizer["DayAgo"]}";
			else if (passedTime.Hours > 0) result = $"{passedTime.Hours} {_localizer["HourAgo"]}";
			else if (passedTime.Minutes > 0) result = $"{passedTime.Minutes} {_localizer["MinuteAgo"]}";
			return $"{_localizer["Online"]} {result}";
		}
	}
}
