using Multi_Layered_Architecture.part3.CoreLayer.Entities;

namespace Multi_Layered_Architecture.part3.BusinessLayer
{
    public static class RatingCalculator
    {
        public static decimal CalculateAverageRating(IEnumerable<Review> reviews)
        {
            if (reviews == null || !reviews.Any()) return 0;
            return (decimal)reviews.Average(r => r.ReviewText.Length);
        }
    }
}
