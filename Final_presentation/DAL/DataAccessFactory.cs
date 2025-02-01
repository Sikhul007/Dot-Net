using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<Category, int, Category> CategoryData()
        {
            return new CategoryRepo();
        }
    }
}// etar modde mainly jotogula interface banano oi sob interface gular repor mathod ba instance banabo 
