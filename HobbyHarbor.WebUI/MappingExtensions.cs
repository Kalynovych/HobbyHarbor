namespace HobbyHarbor.WebUI
{
	public static class MappingExtensions
	{
		public static string? FileToBase64String(this AutoMapper.Profile profile, string path)
		{
			string? resultString;
			try
			{
				using (FileStream fileStream = new FileStream(path, FileMode.Open))
				{
					byte[] bytes = new byte[fileStream.Length];
					fileStream.Read(bytes, 0, bytes.Length);
					resultString = Convert.ToBase64String(bytes);
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
