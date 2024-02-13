using Gallery.Dto;
using MediatR;

namespace Gallery.Features.Albums.Query.GetById
{
    public class GetAlbumByIdQuery : IRequest<ResponseDto>
    {
        public int Id { get; set; }

        public GetAlbumByIdQuery(int id)
        {
            Id = id;
        }
    }
}
