﻿using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductService
    {
        Product GetProduct(long productId);
        IEnumerable<Product> GetAllProducts();
        long AddProduct(Product product);
        long GetAvailableProductItem(long productId);
        ProductSearchResponse GetProductSearchResponse(ProductSearchRequest searchRequest);
    }
}
