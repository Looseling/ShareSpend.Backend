using Microsoft.AspNetCore.Mvc;
using ShareSpend.Application.IRepository;
using ShareSpend.Application.Services.Receipt;
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

        public ReceiptController(IReceiptService receiptService, IUserRepository userRepository)
        {
            _receiptService = receiptService;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostReceiptImage(
            [FromBody][Required] ReceiptParamsCon rpc)
        {
            var user = await _userRepository.GetUserByIdAsync(rpc.userId);

            if (user != null)
            {
                return BadRequest("User not found");
            }

            if (rpc.image == null)
            {
                return BadRequest("Image not found");
            }

            var scannedReceipt = _receiptService.ProcessReceipt(rpc.userId, rpc.image);

            return scannedReceipt != null
                ? Ok(scannedReceipt)
                : BadRequest("Error processing receipt");
        }
    }

    public class ReceiptParamsCon
    {
        [Required]
        public int userId { get; set; }

        [Required]
        public byte[] image { get; set; }
    }
}