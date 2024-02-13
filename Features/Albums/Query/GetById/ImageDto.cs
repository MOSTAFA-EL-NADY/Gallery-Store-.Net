namespace Gallery.Features.Albums.Query.GetById
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; }
        public double SizeInMB { get; set; }
        public string Type { get; set; }
        public int AlbumId { get; set; }
        public int CreatedBy { set; get; }
        public DateTime CreatedOn { set; get; }
        public DateTime? UpdatedOn { set; get; }
    }
}
