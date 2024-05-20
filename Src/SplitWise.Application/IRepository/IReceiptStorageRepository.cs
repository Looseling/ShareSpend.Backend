namespace ShareSpend.Application.IRepository;

public interface IReceiptStorageRepository
{
    Task<string> CreateAsync(Stream content, string blobName, string containerName, IDictionary<string, string> metadata = null);

    Task<Stream> ReadAsync(string blobName, string containerName);

    Task UpdateAsync(string blobName, string containerName, Stream newContent);

    Task DeleteAsync(string blobName, string containerName);
}