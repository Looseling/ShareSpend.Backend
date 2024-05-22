using Microsoft.AspNetCore.Mvc;
using ShareSpend.Application.IRepository;
using ShareSpend.Application.Services.Receipt;
using ShareSpend.Domain.Entities.DTOs.Input;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SplitWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;
        private readonly IUserRepository _userRepository;
        private readonly IContainerRepository _containerRepository;

        public ReceiptController(IReceiptService receiptService, IUserRepository userRepository, IContainerRepository containerRepository)
        {
            _receiptService = receiptService;
            _userRepository = userRepository;
            _containerRepository = containerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostReceiptImage(
            [FromBody][Required] ReceiptDto receiptdto)
        {
            var userExists = await _userRepository.IsUserExists(receiptdto.UserId);
            var containerExists = await _containerRepository.IsContainerExists(receiptdto.ContainerId);

            if (!userExists)
            {
                return BadRequest("User not found");
            }

            if (!containerExists)
            {
                return BadRequest("Container not found");
            }

            if (receiptdto.Image == null)
            {
                return BadRequest("Image not found");
            }

            var scannedReceipt = _receiptService.ProcessReceipt(receiptdto.UserId, receiptdto.Image);

            return scannedReceipt != null
                ? Ok(scannedReceipt)
                : BadRequest("Error processing receipt");
        }
    }
}