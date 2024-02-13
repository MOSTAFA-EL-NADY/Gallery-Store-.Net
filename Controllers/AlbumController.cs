namespace Gallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseDto> PostAlbum([FromForm] PostAlbumCommand command) => await _mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<ResponseDto> DeleteAlbum(int id) => await _mediator.Send(new DeleteAlbumCommand(id));

        [HttpGet]
        public async Task<ResponseDto> GetAllAlbums() => await _mediator.Send(new GetAllAlbumQuery());

        [HttpGet("{id}")]
        public async Task<ResponseDto> GetAlbumById(int id) => await _mediator.Send(new GetAlbumByIdQuery(id));
        [HttpPut("{id}")]
        public async Task<ResponseDto> PutAlbum(int id, [FromForm] PutAlbumDto putAlbumDto)
        {
            return await _mediator.Send(new PutAlbumCommand(id, putAlbumDto));
        }
    }
}
