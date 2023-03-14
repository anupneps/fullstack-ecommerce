using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Db;
using backend.src.Models;
using backend.src.Repositories.BaseRepo;
using backend.src.Repositories.ProductRepo;

namespace Api.src.Repositories.ProductRepo
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext context) : base(context)
        {
        }
    }
}