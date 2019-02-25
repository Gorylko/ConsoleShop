﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Repositories.Interfaces;
using ConsoleShop.Data.Repositories;
using ConsoleShop.Shared.Helpers;

namespace ConsoleShop.Business.Services
{
    public class ProductService
    {
        private IRepository<Product> _productRepository = new ProductRepository();

        public IReadOnlyCollection<Product> GetSearchList(string searchParameter, string searchQuery)
        {
            return _productRepository.GetSearchListFromDb(searchParameter, searchQuery);
        }

        public IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return _productRepository.GetProductsByCategoryIdFromDb(categoryId);
        }

    }
}
