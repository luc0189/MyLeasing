using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
     
        public string ImageUrl { get; set; }

        
                public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
                ? null:
                $"https://myleasinglc.azurewebsites.net{ImageUrl.Substring(1)}";
        public Property Property { get; set; }
    }

}
