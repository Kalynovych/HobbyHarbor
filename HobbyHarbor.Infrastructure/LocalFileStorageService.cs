using HobbyHarbor.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HobbyHarbor.Infrastructure
{
	public class LocalFileStorageService : IFileStorageService
	{
		private readonly string _localPath;

		public LocalFileStorageService(IConfiguration configuration)
		{
			_localPath = configuration["LocalPath"];
		}

		public async Task<bool> CreateRootCatalogAsync(string rootCatalogName, CancellationToken token = default)
		{
			try
			{
				Directory.CreateDirectory(_localPath + rootCatalogName);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> DeleteFileAsync(string path, CancellationToken token = default)
		{
			try
			{
				File.Delete(_localPath + path);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<Stream> DownloadFileAsync(string path, CancellationToken token = default)
		{
			try
			{
				FileStream fileStream = File.Open(_localPath + path, FileMode.Open);
				return fileStream;
			}
			catch
			{
				return null;
			}
		}

		public bool SetRootCatalog(string rootCatalogName)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UploadFileAsync(string path, Stream stream, CancellationToken token = default)
		{
			try
			{
				FileStream fileStream = File.Create(_localPath + path);
				await stream.CopyToAsync(fileStream, token);
				fileStream.Close();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				stream.Close();
			}
		}
	}
}
