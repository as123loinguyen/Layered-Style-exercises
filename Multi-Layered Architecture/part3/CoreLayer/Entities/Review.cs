namespace Multi_Layered_Architecture.part3.CoreLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }

        public Movie Movie { get; set; }  // Điều hướng đến Movie
    }
}
