namespace Gallery.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Album> Albums { get; set; }

    }
}
