using Gallery.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Gallery.Features.Albums.Command.Post
{
    public class PostAlbumCommand : IRequest<ResponseDto>
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? MainImage { get; set; }
    }
}
