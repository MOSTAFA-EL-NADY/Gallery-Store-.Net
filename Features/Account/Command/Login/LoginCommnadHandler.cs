using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gallery.Features.Account.Command.Login
{
    public class LoginCommnadHandler : IRequestHandler<LoginCommnad, ResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ResponseHelper _response;
        public LoginCommnadHandler(UserManager<User> userManager,
                                   SignInManager<User> signInManager,
                                   ITokenService tokenService,
                                   ResponseHelper response)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _response = response;
        }
        public async Task<ResponseDto> Handle(LoginCommnad request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return _response.NotFound("UserName Not Exists");
            // the last param if the user enter wrong pass the account is locked t or f 
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                return _response.NotFound("Password Not Correct");

            var token = await _tokenService.CreateToken(user, _userManager);

            return _response.RetrievedSuccessfully(token, "User Logged in Successfully");
        }
    }
}
