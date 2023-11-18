using Azure.Identity;
using Azure.Storage.Blobs;
using HobbyHarbor.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HobbyHarbor.Infrastructure
{
	public class BlobStorageService : IFileStorageService
	{
		private readonly BlobServiceClient _serviceClient;
		private BlobContainerClient _containerClient;

		public bool SetRootCatalog(string rootCatalogName)
		{
			_containerClient = _serviceClient.GetBlobContainerClient(rootCatalogName);
			return _containerClient != null;
		}

		public BlobStorageService(IConfiguration configuration)
		{
			string serviceUri = configuration["ServiceUri"];
			if (serviceUri != null)
			{
				_serviceClient = new BlobServiceClient(
					new Uri(serviceUri),
					new DefaultAzureCredential());
			}
		}

		public async Task<bool> CreateRootCatalogAsync(string rootCatalogName, CancellationToken token = default)
		{
			try
			{
				_containerClient = await _serviceClient.CreateBlobContainerAsync(rootCatalogName, cancellationToken: token);
				return _containerClient != null;
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
				var container = path.Split("/")[1];
				path = path.Replace($"/{container}", "");
				BlobContainerClient containerClient = _serviceClient.GetBlobContainerClient(container);
				BlobClient client = containerClient.GetBlobClient(path);
				await client.DeleteAsync();
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
				var container = path.Split("/")[1];
				path = path.Replace($"/{container}", "");
				BlobContainerClient containerClient = _serviceClient.GetBlobContainerClient(container);
				MemoryStream stream = new MemoryStream();
				BlobClient client = containerClient.GetBlobClient(path);
				await client.DownloadToAsync(stream);
				return stream;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> UploadFileAsync(string path, Stream stream, CancellationToken token = default)
		{
			try
			{
				var container = path.Split("/")[1];
				path = path.Replace($"/{container}", "");
				BlobContainerClient containerClient = _serviceClient.GetBlobContainerClient(container);
				BlobClient client = containerClient.GetBlobClient(path);
				await client.UploadAsync(stream, token);
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
