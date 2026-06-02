namespace NANTMedia.API.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public string? DocumentUrl { get; set; }

        public string SubscriptionType { get; set; }

        public string Status { get; set; } = "Pending";

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
