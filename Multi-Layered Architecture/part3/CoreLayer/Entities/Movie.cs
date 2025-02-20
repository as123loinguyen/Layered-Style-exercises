﻿using System;
using System.Collections.Generic;

namespace Multi_Layered_Architecture.part3.CoreLayer.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        // Liên kết với Review
        public ICollection<Review> Reviews { get; set; }

        // Thêm thuộc tính này để giải quyết lỗi
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
