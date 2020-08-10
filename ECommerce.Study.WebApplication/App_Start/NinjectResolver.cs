using ECommerce.Study.WebApplication.Profilers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;


namespace ECommerce.Study.WebApplication
{
	public class NinjectResolver : IDependencyResolver
	{
		private readonly IKernel _kernel;
		public NinjectResolver()
		{
			_kernel = new StandardKernel();
			Bind();
		}
		public object GetService(Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}

		private void Bind()
		{
			_kernel.Bind<Business.Providers.IServiceProvider, Business.Providers.ServiceProvider>()
				.ToConstructor(ctor => new Business.Providers.ServiceProvider(ConfigurationManager.ConnectionStrings["ECommerce.Context"].ConnectionString ))
				.InSingletonScope();
			_kernel.Bind<ICustomAutoMapper>().To<CustomAutoMapper>().InSingletonScope();
		}
	}
}