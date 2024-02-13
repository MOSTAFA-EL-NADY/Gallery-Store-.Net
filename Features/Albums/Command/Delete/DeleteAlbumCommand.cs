using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Albums.Command.Delete
{
    public class DeleteAlbumCommand : IRequest<ResponseDto>
    {
        public int AlbumId { get; set; }
        public DeleteAlbumCommand(int albumId)
        {
            AlbumId = albumId;
        }
    }
}
