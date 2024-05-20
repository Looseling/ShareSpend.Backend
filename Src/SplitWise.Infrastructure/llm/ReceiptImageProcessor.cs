using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using System.Text;
using System.Text.Json;
using static OpenAI_API.Chat.ChatMessage;

namespace ShareSpend.Infrastructure.llm
{
    public class ReceiptImageProcessor : IReceiptImageProcessor
    {
        private readonly IConfiguration _config;

        public ReceiptImageProcessor(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ProcessedReecipt> GetDataFromReceipt(byte[] imageBytes)
        {
            try
            {
                var receiptImagePath = saveImageOnTheMachine(imageBytes);
                var receiptInput = ImageInput.FromFile(receiptImagePath);
                var systemMessage = "";
                var gptResponseJsonStructure = "{\"merchant_name\": \"string\",\"address\": \"string\",\"list_of_products\": [{\"product_name\": \"string\",\"quantity\": \"number\",\"price\": \"number\",\"discount\": \"number\"}],\"total\": \"number\",\"date\": \"string\"}}";
                var prompt = $"I am giving you image of the receipt from shop. Please return data on the receipt in the format of JSON: {gptResponseJsonStructure}";

                var openai = new OpenAIAPI(_config["OpenAi:ApiKey"]);
                ChatRequest chatRequest = new ChatRequest()
                {
                    Model = Model.GPT4_Vision,
                    Temperature = 0.0,
                    MaxTokens = 4096,
                    ResponseFormat = ChatRequest.ResponseFormats.Text,
                    Messages = new ChatMessage[] {
                    new ChatMessage(ChatMessageRole.System, systemMessage),
                    new ChatMessage(ChatMessageRole.User, prompt, receiptInput)
                }
                };

                var response = await openai.Chat.CreateChatCompletionAsync(chatRequest);

                var result = JsonSerializer.Deserialize<ProcessedReecipt>(response.ToString());

                return result;
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
        }

        private string saveImageOnTheMachine(byte[] image)
        {
            var receiptId = Guid.NewGuid().ToString();
            var receiptImagePath = Path.Combine("./../receipts", receiptId);
            File.WriteAllBytes(receiptImagePath, image);
            return receiptImagePath;
        }
    }
}