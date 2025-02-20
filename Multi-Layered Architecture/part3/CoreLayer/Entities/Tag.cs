namespace Multi_Layered_Architecture.part3.CoreLayer.Entities
{
    public class Tag
    {
        public int Id { get; set; }  // Khóa chính
        public string Name { get; set; }  // Tên tag (VD: "Hành động", "Kinh dị")

        // Thêm thuộc tính sau nếu thiếu:
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
