using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;

namespace ShareSpend.Infrastructure.Storage
{
    public class ReceiptImageStorage : IReceiptImageStorage
    {
        private readonly BlobContainerClient _blobContainerClient;

        public ReceiptImageStorage(IConfiguration config)
        {
            _blobContainerClient = new BlobContainerClient(config["Azure:BlobStorage:ConnectionString"], config["Azure:BlobStorage:ContainerName"]);
        }

        public async Task<ReceiptStorageModel> GetReceiptAsync(string receiptContainerId, string receiptId)
        {
            // Create the blob client
            BlobClient blobClient = _blobContainerClient.GetBlobClient(receiptContainerId + "/" + receiptId);

            // Download the receipt content
            var response = await blobClient.DownloadAsync();

            // Read the receipt content as a byte array
            using (var memoryStream = new MemoryStream())
            {
                await response.Value.Content.CopyToAsync(memoryStream);
                byte[] receiptContent = memoryStream.ToArray();

                // Create the ReceiptStorageModel object
                ReceiptStorageModel receiptStorageModel = new ReceiptStorageModel
                {
                    ReceiptContainerId = receiptContainerId,
                    ReceiptId = receiptId,
                    ReceiptImage = receiptContent
                };

                return receiptStorageModel;
            }
        }

        public async Task SaveReceiptAsync(ReceiptStorageModel receiptStorageModel)
        {
            // Create the blob client
            try
            {
                BlobClient blobClient = _blobContainerClient.GetBlobClient(receiptStorageModel.ReceiptContainerId + "/" + receiptStorageModel.ReceiptId);

                using (var stream = new MemoryStream(receiptStorageModel.ReceiptImage))
                {
                    await blobClient.UploadAsync(stream, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}