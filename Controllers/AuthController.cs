using Microsoft.AspNetCore.Mvc;
using testapi.Data;
using testapi.DTOs.User;
using testapi.Models;

namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepository.Register(new User { UserName=request.userName},request.password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
       
            return Ok(response);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepository.Login(request.UserName,request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }



}
