using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using ShareSpend.Domain.Entities.DTOs.Input;
using System.ComponentModel.DataAnnotations;

namespace SplitWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerRepository _receiptContainerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReceiptImageStorage _receiptImageStorage;

        public ContainerController(IContainerRepository receiptContainerRepository, IUserRepository userRepository, IReceiptImageStorage receiptImageStorage)
        {
            _receiptContainerRepository = receiptContainerRepository;
            _userRepository = userRepository;
            _receiptImageStorage = receiptImageStorage;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiptContainers()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostContainer([FromBody][Required] ContainerDto containerDTO)
        {
            // Assuming receiptContainerDto has a List of UserIds
            var user = await _userRepository.GetUserByIdAsync(containerDTO.UserId);
            var containerPublicId = Guid.NewGuid().ToString();
            var container = new Container
            {
                Name = containerDTO.Name,
                PublicId = containerPublicId,
                Description = containerDTO.Description,
                AdminId = containerDTO.UserId
            };

            container.Users = new List<User>() { user };
            await _receiptContainerRepository.AddContainer(container);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiptContainerById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiptContainersByUserId(int userId)
        {
            return Ok();
        }
    }
}