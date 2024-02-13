using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Account.Command.Login
{
    public class LoginCommnad : IRequest<ResponseDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
