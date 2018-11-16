using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Recipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
    }
}
