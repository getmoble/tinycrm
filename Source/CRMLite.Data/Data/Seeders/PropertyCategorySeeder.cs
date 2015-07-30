using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Data.Data.Seeders
{
    public class PropertyCategorySeeder
    {
        public static void Seed(DataContext context)
        {
            var propertycategory = new List<PropertyCategory>
            {
               new PropertyCategory{Name = "Apartment"},
               new PropertyCategory{Name = "Villa"},
               new PropertyCategory{Name = "Office"},
               new PropertyCategory{Name = "Retail"},
               new PropertyCategory{Name = "Hotel Apartment"},
               new PropertyCategory{Name = "Warehouse"},
               new PropertyCategory{Name = "Land commercial"},
               new PropertyCategory{Name = "Labour Camp"},
               new PropertyCategory{Name = "Residential Building"},
               new PropertyCategory{Name = "Multiple Sale Units"},
               new PropertyCategory{Name = "Land Residential"},
               new PropertyCategory{Name = "Commercial Full Building"},
               new PropertyCategory{Name = "Penthouse"},
               new PropertyCategory{Name = "Duplex"},
               new PropertyCategory{Name = "Loft Apartment"},
               new PropertyCategory{Name = "Town House"},
               new PropertyCategory{Name = "Hotel"},
               new PropertyCategory{Name = "Land Mixed use"},
               new PropertyCategory{Name = "Compound"},
               new PropertyCategory{Name = "Half Floor"},
               new PropertyCategory{Name = "Full Floor"},
               new PropertyCategory{Name = "Commercial Villa"}
            };
            propertycategory.ForEach(s => context.PropertyCategories.Add(s));
            context.SaveChanges();
        }
    }
}
