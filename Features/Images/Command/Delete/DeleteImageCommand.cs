using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Images.Command.Delete
{
    public class DeleteImageCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }

        public DeleteImageCommand(int id)
        {
            Id = id;
        }
    }
}
