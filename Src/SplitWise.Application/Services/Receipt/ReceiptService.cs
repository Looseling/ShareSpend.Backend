using Microsoft.EntityFrameworkCore.Storage.Json;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using System.Text.Json;

namespace ShareSpend.Application.Services.Receipt
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptImageProcessor _receiptImageProcessor;
        private readonly IReceiptImageStorage _receiptImageStorage;
        //private readonly IReceiptRepository _receiptRepository;
        //private readonly IReceiptStorageRepository _receiptStorageRepository;
        //private readonly IReceiptContainerRepository _receiptContainerRepository;

        public ReceiptService(IReceiptImageProcessor receiptImageProcessor, IReceiptImageStorage receiptImageStorage)
        {
            _receiptImageProcessor = receiptImageProcessor;
            _receiptImageStorage = receiptImageStorage;
        }

        public async Task<ReceiptServiceModel> ProcessReceipt(string containerId, byte[] image)
        {
            var receiptUUID = Guid.NewGuid().ToString();

            //save image in azure storage
            var receiptStorageModel = new Storage
            {
                ReceiptContainerId = containerId,
                ReceiptId = receiptUUID,
                ReceiptImage = image,
            };

            await _receiptImageStorage.SaveReceiptAsync(receiptStorageModel);

            //process image through chat gpt.
            var receiptImageData = await _receiptImageProcessor.GetDataFromReceipt(image);

            //TODO: save all needed data in db

            return new ReceiptServiceModel
            (
                receiptUUID,
                containerId,
                receiptImageData
            );
        }
    }
}