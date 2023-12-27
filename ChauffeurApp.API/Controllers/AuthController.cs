using ChauffeurApp.Application.DTOs;
using ChauffeurApp.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ChauffeurApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseAPIController
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO user)
        {
            return HandleResult(await _authService.RegisterUser(user));
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            return HandleResult(await _authService.Login(user));
        }

        [HttpPost]
        [Route("RefreshAccessToken")]
        public async Task<IActionResult> GetNewTokenFromRefreshToken(TokenDTO tokenDTO)
        {
            return HandleResult(await _tokenService.RefreshAccessToken(tokenDTO));
        }

        [HttpPost]
        [Route("InitiateChangePhoneNumber")]
        public async Task<IActionResult> InitiateChangePhoneNumberForUser(ChangePhoneNumberDTO changePhoneNumberDTO)
        {
            return HandleResult(await _authService.InitiateChangePhoneNumber(changePhoneNumberDTO));
        }

        [HttpPost]
        [Route("ResetPhoneNumber")]
        public async Task<IActionResult> ResetPhoneNumberForUser(ResetPhoneNumberDTO resetPhoneNumberDTO)
        {
            return HandleResult(await _authService.ResetPhoneNumber(resetPhoneNumberDTO));
        }


        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IFormFile)
        {
            return HandleResult(await _authService.UploadFile(_IFormFile));
        }

    }
}

