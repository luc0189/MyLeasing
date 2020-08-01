using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
   public interface IConverterHelper
    {
        Task<Property> ToPropertyAsync(PropertyViewModel model,bool isNew);
    }
}
