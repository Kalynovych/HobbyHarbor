using AutoMapper;
using HobbyHarbor.Application.Interfaces;

namespace HobbyHarbor.Application.Mapper.ValueConverters
{
	public class FileToBase64ValueConverter : IValueConverter<string?, string?>
	{
		private readonly IFileStorageService _fileStorageService;

		public FileToBase64ValueConverter(IFileStorageService fileStorageService)
		{
			_fileStorageService = fileStorageService;
		}

		public string? Convert(string? path, ResolutionContext context)
		{
			string? resultString = null;
			try
			{
				using (Stream stream = _fileStorageService.DownloadFileAsync(path).Result)
				{
					if (stream != null)
					{
						stream.Position = 0;
						byte[] bytes = new byte[stream.Length];
						stream.Read(bytes, 0, bytes.Length);
						resultString = System.Convert.ToBase64String(bytes);
					}
				}
			}
			catch
			{
				resultString = null;
			}

			return resultString;
		}
	}
}
