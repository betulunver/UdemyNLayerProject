
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Entities;

namespace UdemyNLayerProject.Core.Repositories
{
    interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetwithCategoryByProductId(int productId);
    }
}
