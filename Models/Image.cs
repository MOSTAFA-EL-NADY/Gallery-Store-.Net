namespace Gallery.Models
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
