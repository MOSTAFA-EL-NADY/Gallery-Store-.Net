namespace Gallery.Features.Albums.Query.GetAll
{
    public class GetAllAlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string MainImage { get; set; }

        public GetAllAlbumDto(int id, string title, string description, DateTime createdOn, string albumImage)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedOn = createdOn;
            MainImage = albumImage;
        }
    }
}
