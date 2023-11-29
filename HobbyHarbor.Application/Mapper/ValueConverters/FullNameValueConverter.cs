using AutoMapper;

namespace HobbyHarbor.Application.Mapper.ValueConverters
{
	public class FullNameValueConverter : IValueConverter<Core.Entities.Profile, string>
	{
		public string Convert(Core.Entities.Profile source, ResolutionContext context)
		{
			return $"{source.Name} {source.Surname}";
		}
	}
}
