namespace Gallery.Features.Albums.Command.Put
{
    public class PutAlbumDto
    {
        public IFormFile? MainImage { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
