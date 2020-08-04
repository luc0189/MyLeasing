﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyLeasing.Common.Models
{
    public class PropertyResponse
    {
        public int Id { get; set; }

        public string Neighborhood { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public int SquareMeters { get; set; }

        public int Rooms { get; set; }

        public int Stratum { get; set; }

        public bool HasParkingLot { get; set; }

        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public string PropertyType { get; set; }

        public ICollection<PropertyImageResponse> PropertyImages { get; set; }

        public ICollection<ContractResponse> Contracts { get; set; }
        public string FirstImage => PropertyImages == null || PropertyImages.Count == 0
            ?  "https://cdn4.iconfinder.com/data/icons/twitter-29/512/159_Twitter_Image_Picture-64.png"
        : PropertyImages.FirstOrDefault().ImageUrl;
         
    }
}
