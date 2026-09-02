using BookStoreAPI.DTOs.User;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
 
        [HttpGet]
        public ActionResult<List<UserResponseDto>> GetAll()
        {
            return Ok(_userService.GetAll());
        }
 
        [HttpGet("{id}")]
        public ActionResult<UserResponseDto> GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }
            return Ok(user);
        }
    }
}