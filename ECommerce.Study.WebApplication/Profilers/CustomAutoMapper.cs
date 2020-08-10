using AutoMapper;
using System.Collections.Generic;

namespace ECommerce.Study.WebApplication.Profilers
{
	public interface ICustomAutoMapper
	{
		TDestination Map<TSource, TDestination>(TSource source);
	}

	internal class CustomProfile : Profile
	{
		public CustomProfile()
		{
			CreateMap<Domain.Models.Product, Models.ProductViewModel>()
				.ForMember(dest => dest.StockCount, opts => opts.MapFrom(source => source.Stock != null ? source.Stock.StockCount : 0))
				.ReverseMap()
				.ForMember(dest => dest.Stock, opts => opts.MapFrom(source => new Domain.Models.Stock { StockCount = source.StockCount }));
		}

	}
	public class CustomAutoMapper : ICustomAutoMapper
	{
		public IMapper Mapper { get; set; }
		public CustomAutoMapper()
		{
			var profiles = new List<Profile>
			{
				new CustomProfile()
			};

			var mapperConfiguration = new MapperConfiguration(cfg =>
			{
				foreach (var profile in profiles)
				{
					cfg.AddProfile(profile);
				}
			});

			Mapper = mapperConfiguration.CreateMapper();
		}
		public TDestination Map<TSource, TDestination>(TSource source)
		{
			return Mapper.Map<TDestination>(source);
		}

	}
}
