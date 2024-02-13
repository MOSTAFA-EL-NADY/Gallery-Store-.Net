namespace Gallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseDto> AddImage([FromForm] PostImageCommand command) => await _mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> DeleteImage(int id) => await _mediator.Send(new DeleteImageCommand(id));
        [HttpGet("{albumId}")]
        [EnableQuery]
        public async Task<ImageResponseDto> GetAllImages(int albumId) => await _mediator.Send(new GetAllImageByAlbumIdQuery(albumId));
    }
}
