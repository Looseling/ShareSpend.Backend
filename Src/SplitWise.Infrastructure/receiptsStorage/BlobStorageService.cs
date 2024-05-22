using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;

namespace ShareSpend.Infrastructure.ReceiptsStorage
{
    public class BlobStorageService : IReceiptImageStorage
    {
        private readonly BlobContainerClient _containerClient;

        public BlobStorageService(IConfiguration config)
        {
            _containerClient = new BlobContainerClient(config["Azure:BlobStorage:ConnectionString"], config["Azure:BlobStorage:ContainerName"]);
        }

        public async Task<Storage> GetReceiptAsync(string receiptContainerId, string receiptId)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(receiptContainerId + "/" + receiptId);

            var response = await blobClient.DownloadAsync();

            using (var memoryStream = new MemoryStream())
            {
                await response.Value.Content.CopyToAsync(memoryStream);
                byte[] receiptContent = memoryStream.ToArray();

                Storage receiptStorageModel = new Storage
                {
                    ReceiptContainerId = receiptContainerId,
                    ReceiptId = receiptId,
                    ReceiptImage = receiptContent
                };

                return receiptStorageModel;
            }
        }

        public async Task SaveReceiptAsync(Storage receiptStorageModel)
        {
            using (var stream = new MemoryStream(receiptStorageModel.ReceiptImage))
            {
                BlobClient blobClient = _containerClient.GetBlobClient(receiptStorageModel.ReceiptContainerId + "/" + receiptStorageModel.ReceiptId);
                await blobClient.UploadAsync(stream, true);
            }
        }
    }
}