namespace Gallery.Models
{
    public class Album : BaseEntity
    {
        public string? MainImage { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual List<Image>? Images { get; set; }

    }
}
