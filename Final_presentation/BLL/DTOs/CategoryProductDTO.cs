using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryProductDTO : CategoryDTO
    {
        public List<ProductDTO> Products { get; set; }     // here <ProductsDTO> neyar karon hoilo amader product er o collection dorkar.

        public CategoryProductDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}
