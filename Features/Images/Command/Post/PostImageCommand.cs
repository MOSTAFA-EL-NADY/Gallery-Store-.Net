using Gallery.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Gallery.Features.Images.Command.Post
{
    public class PostImageCommand : IRequest<ResponseDto>
    {

        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public int AlbumId { get; set; }
    }
}
