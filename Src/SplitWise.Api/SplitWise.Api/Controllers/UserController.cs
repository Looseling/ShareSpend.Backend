using Microsoft.AspNetCore.Mvc;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using ShareSpend.Domain.Entities.DTOs.Input;
using System.ComponentModel.DataAnnotations;

namespace SplitWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(
                       [FromBody][Required] UserDto userdto)
        {
            var user = new User
            {
                PublicId = userdto.UserPublicId,
                Name = userdto.Name,
                Email = userdto.Email
            };

            await _userRepository.AddUser(user);

            return Ok(user);
        }
    }
}