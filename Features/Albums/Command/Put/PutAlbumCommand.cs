using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Albums.Command.Put
{
    public class PutAlbumCommand : IRequest<ResponseDto>
    {
        public int AlbumId { get; set; }
        public PutAlbumDto PutAlbumDto { get; set; }


        public PutAlbumCommand(int albumId, PutAlbumDto putAlbumDto)
        {
            AlbumId = albumId;
            PutAlbumDto = putAlbumDto;
        }

    }
}
