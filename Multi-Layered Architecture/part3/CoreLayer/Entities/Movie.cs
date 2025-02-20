﻿using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Multi_Layered_Architecture.part3.CoreLayer.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
