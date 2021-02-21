using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
namespace ForestApp_IdentifiyApi.Extension
{
    public static class FluentValidationConfiguration
	{
	
			public static IMvcBuilder UseIdentitiyApiFluentValidation(this IMvcBuilder mvcBuilder)
			{
				mvcBuilder.AddFluentValidation(x => {
					x.RegisterValidatorsFromAssemblyContaining<Startup>();
					x.ImplicitlyValidateChildProperties = true;
				});
				return mvcBuilder;
			}
	}
}
