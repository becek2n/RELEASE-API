using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RELEASE.API.Models
{
    public class ModelAPIProduct
    {
        public int ID { get; set; }
        public Nullable<int> CategoriID { get; set; }
        public string Categori { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public byte[] Photo1 { get; set; }
        public byte[] Photo2 { get; set; }
        public byte[] Photo3 { get; set; }
    }

    public class ModelAPICategory
    {
        public int ID { get; set; }
        public string Categori { get; set; }
    }

}