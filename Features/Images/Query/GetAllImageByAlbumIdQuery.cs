using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Images.Query
{
    public class GetAllImageByAlbumIdQuery : IRequest<ImageResponseDto>
    {
        public int AlbumId { get; set; }

        public GetAllImageByAlbumIdQuery(int albumId)
        {
            AlbumId = albumId;
        }
    }
}
