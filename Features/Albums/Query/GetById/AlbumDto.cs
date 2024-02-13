namespace Gallery.Features.Albums.Query.GetById
{
    public class AlbumDto
    {
        public string MainImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
