using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenema_Pharmacy.Models
{
    public class Item
    {
        public MedicalProduct Product { get; set; }
        public int Stock { get; set; }
    }
}