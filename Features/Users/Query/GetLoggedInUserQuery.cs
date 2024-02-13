using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Users.Query
{
    public class GetLoggedInUserQuery : IRequest<ResponseDto>
    {
    }
}
