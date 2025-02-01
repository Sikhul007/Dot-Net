using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Cate")]
        public int CatId { get; set; }  // this is foreign key
        public Category Cate { get; set; } // kar foreign key? ei catefory table er.
    }
}
