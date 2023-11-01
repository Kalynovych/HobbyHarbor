using AutoMapper;

namespace HobbyHarbor.WebUI
{
	public class FileToBase64ValueConverter : IValueConverter<string?, string?>
	{
		public string? Convert(string? path, ResolutionContext context)
		{
			string? resultString;
			try
			{
				using (FileStream fileStream = new FileStream(path, FileMode.Open))
				{
					byte[] bytes = new byte[fileStream.Length];
					fileStream.Read(bytes, 0, bytes.Length);
					resultString = System.Convert.ToBase64String(bytes);
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
