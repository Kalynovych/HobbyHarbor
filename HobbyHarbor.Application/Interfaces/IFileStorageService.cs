namespace HobbyHarbor.Application.Interfaces
{
	public interface IFileStorageService
	{
		bool SetRootCatalog(string rootCatalogName);

		Task<bool> CreateRootCatalogAsync(string rootCatalogName, CancellationToken token = default);

		Task<bool> UploadFileAsync(string path, Stream stream, CancellationToken token = default);

		Task<bool> DeleteFileAsync(string path, CancellationToken token = default);

		Task<Stream> DownloadFileAsync(string path, CancellationToken token = default);
	}
}
