using ECommerce.Study.WebApplication.Code;
using ECommerce.Study.WebApplication.Models;
using ECommerce.Study.WebApplication.Profilers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ECommerce.Study.WebApplication.Controllers
{
	public class ProductController : ControllerBase
	{
		private readonly Business.Providers.IServiceProvider _serviceProvider;
		private readonly ICustomAutoMapper _mapper;
		public ProductController(Business.Providers.IServiceProvider serviceProvider, ICustomAutoMapper mapper)
		{
			_serviceProvider = serviceProvider;
			_mapper = mapper;
		}

		public ActionResult Index()
		{
			try
			{
				var productService = _serviceProvider.ProductService();
				var allProducts = productService.GetAll();
				if (allProducts == null || allProducts.Count == 0)
					return View();

				return View(new ProductIndexViewModel
				{
					Products = _mapper.Map<IList<Domain.Models.Product>, IList<ProductViewModel>>(allProducts)
				});
			}
			catch
			{
				return View("Error");
			}
		}


		[Authorize]
		[HttpGet]
		public ActionResult Add()
		{
			ViewBag.IsAddOrUpdate = true;
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult Add(ProductViewModel product)
		{
			ViewBag.IsAddOrUpdate = true;

			if (!ModelState.IsValid)
			{
				return View(new ProductAddViewModel
				{
					Product = product,
					Errors = ModelState.Values.Where(w => w.Errors.Count > 0).SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage)
				});
			}

			try
			{
				var domainProduct = _mapper.Map<ProductViewModel, Domain.Models.Product>(product);
				var productService = _serviceProvider.ProductService();
				var existingProduct = productService.GetProductByStockCode(domainProduct.StockCode);
				if (existingProduct != null)
				{
					return View(new ProductAddViewModel
					{
						Product = product,
						Errors = new List<string> { $"{existingProduct.StockCode} ürün koduna sahip bir ürün zaten bulunmaktadır." }
					});
				}

				domainProduct = productService.Save(domainProduct);
				if (domainProduct == null)
				{
					return View(new ProductAddViewModel
					{
						Product = product,
						Errors = new List<string> { "Ürün kaydedilirken bir hata oluştu." }
					});
				}

				return View(new ProductAddViewModel
				{
					Product = product,
					Success = true
				});
			}
			catch
			{
				return View("Error");
			}
		}

		[Authorize]
		[HttpGet]
		public ActionResult Update(string stockCode)
		{
			ViewBag.IsAddOrUpdate = false;
			if (string.IsNullOrWhiteSpace(stockCode))
				return View("NotFound");

			try
			{
				var productService = _serviceProvider.ProductService();
				var product = productService.GetProductByStockCode(stockCode);
				if (product == null)
					return View("NotFound");

				return View("Add", new ProductAddViewModel
				{
					Product = _mapper.Map<Domain.Models.Product, ProductViewModel>(product),
				});
			}
			catch
			{
				return View("Error");
			}
		}

		[Authorize]
		[HttpPost]
		public ActionResult Update(ProductViewModel product)
		{
			ViewBag.IsAddOrUpdate = false;

			if (!ModelState.IsValid)
			{
				return View("Add", new ProductAddViewModel
				{
					Product = product,
					Errors = ModelState.Values.Where(w => w.Errors.Count > 0).SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage)
				});
			}

			try
			{
				var domainProduct = _mapper.Map<ProductViewModel, Domain.Models.Product>(product);
				var productService = _serviceProvider.ProductService();
				var existingProduct = productService.GetProductByStockCode(domainProduct.StockCode);
				if (existingProduct == null)
				{
					return View("Add", new ProductAddViewModel
					{
						Product = product,
						Errors = new List<string> { $"{product.StockCode} ürün koduna sahip bir ürün bulanamadı." }
					});
				}

				existingProduct.Name = domainProduct.Name;
				existingProduct.Description = domainProduct.Description;
				existingProduct.Price = domainProduct.Price;
				existingProduct.Stock.StockCount = domainProduct.Stock.StockCount;

				domainProduct = productService.Update(existingProduct);
				if (domainProduct == null)
				{
					return View("Add", new ProductAddViewModel
					{
						Product = product,
						Errors = new List<string> { "Ürün güncellenirken bir hata oluştu." }
					});
				}

				return View("Add", new ProductAddViewModel
				{
					Product = product,
					Success = true
				});
			}
			catch
			{
				return View("Error");
			}
		}

		[Authorize]
		[HttpGet]
		public ActionResult Delete(string stockCode)
		{
			if (string.IsNullOrWhiteSpace(stockCode))
				return new HttpStatusCodeResult(401);

			try
			{
				var productService = _serviceProvider.ProductService();
				var product = productService.GetProductByStockCode(stockCode);
				if (product == null)
					return HttpNotFound();

				productService.Delete(product);
				return new HttpStatusCodeResult(200);
			}
			catch
			{
				return new HttpStatusCodeResult(500);
			}
		}

		[Authorize]
		[HttpGet]
		public ActionResult Detail(string stockCode)
		{
			if (string.IsNullOrWhiteSpace(stockCode))
				return View("NotFound");

			try
			{
				var productService = _serviceProvider.ProductService();
				var dbProduct = productService.GetProductByStockCode(stockCode);
				if (dbProduct == null)
					return View("NotFound");

				var barcodeBytes = BarcodeGenerator.Generate(dbProduct.StockCode, 200, 80);
				var barcodeBase64String = Convert.ToBase64String(barcodeBytes);

				return View(new ProductDetailViewModel
				{
					Product = _mapper.Map<Domain.Models.Product, ProductViewModel>(dbProduct),
					BarcodeBase64String = barcodeBase64String
				});
			}
			catch
			{
				return View("Error");
			}
		}

	}
}