using AutoMapper;
using Microsoft.Extensions.Localization;

namespace HobbyHarbor.WebUI.MappingProfiles
{
	public class SexValueConverter : IValueConverter<string, string>
	{
		private readonly IStringLocalizer<CommonResources> _localizer;

		public SexValueConverter(IStringLocalizer<CommonResources> localizer)
		{
			_localizer = localizer;
		}

		public string Convert(string sex, ResolutionContext context)
		{
			return sex == "male" ? _localizer["Male"] : _localizer["Female"];
		}
	}
}
