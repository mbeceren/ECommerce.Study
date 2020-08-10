using ECommerce.Study.Business.Interfaces;
using ECommerce.Study.Data.Persistence;
using ECommerce.Study.Data.Repos;
using ECommerce.Study.Domain.Models;
using System.Collections.Generic;

namespace ECommerce.Study.Business.Services
{
	internal class ProductService :  IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IStockRepository _stockRepository;
		internal ProductService(IRepositoryFactory repositoryFactory)
		{
			_productRepository = repositoryFactory.GetProductRepository();
			_stockRepository = repositoryFactory.GetStockRepository();
		}

		public Product GetProductById(int id)
		{
			return _productRepository.GetById(id);
		}

		public Product Save(Product product)
		{
			_stockRepository.Save(product.Stock);
			product = _productRepository.Save(product);
			_productRepository.SaveChanges();
			return product;
		}

		public Product Update(Product product)
		{
			_stockRepository.Update(product.Stock);
			product = _productRepository.Update(product);
			_productRepository.SaveChanges();
			return product;
		}

		public Product GetProductByStockCode(string stockCode)
		{
			return _productRepository.GetProductByStockCode(stockCode);
		}

		public IList<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

		public void Delete(Product product)
		{
			_productRepository.Delete(product);
			_productRepository.SaveChanges();
		}
	}
}
