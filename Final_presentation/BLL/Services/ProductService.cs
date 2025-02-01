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
    public class ProductService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            return new Mapper(config);
        }

        public static List<ProductDTO> GetAll()
        {
            var repo = DataAccessFactory.ProductData();
            return GetMapper().Map<List<ProductDTO>>(repo.GetAll());
        }
        public static ProductDTO Get(int id)
        {
            var repo = DataAccessFactory.ProductData();
            var product = repo.Get(id);
            var ret = GetMapper().Map<ProductDTO>(product);
            return ret;
        }
    }
}
