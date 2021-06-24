using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Entities;

namespace UdemyNLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //db ile ilgili değil iç metot
        //bool ControlInnerBarcode(Product product)
        Task<Product> GetWithCategoryByProductId(int productId);

    }
}
