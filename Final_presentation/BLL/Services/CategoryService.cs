using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();         // karon eta product ke pabe na karon categorywithproduct class e type hoilo products ekta list ache jetar datatype hoilo productsDTO..... r onno dike EF-> tables-> category class er modde products name e ekta list ache but oidar datatype only product. thats why ei line na lekhle error dibe
            });
            return new Mapper(config);
        }

        public static List<CategoryDTO> GetAll()
        {
            var repo = DataAccessFactory.CategoryData();
            return GetMapper().Map<List<CategoryDTO>>(repo.GetAll());
        }
        public static CategoryDTO Get(int id)
        {
            var repo = DataAccessFactory.CategoryData();
            var category = repo.Get(id);
            var ret = GetMapper().Map<CategoryDTO>(category);
            return ret;
        }

        public static CategoryProductDTO GetwithProducts(int id)
        {
            var repo = DataAccessFactory.CategoryData();
            var category = repo.Get(id);
            var ret = GetMapper().Map<CategoryProductDTO>(category);
            return ret;

        }


        // add other method for other CRUD operations
    }
}
