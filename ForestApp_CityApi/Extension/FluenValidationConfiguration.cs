using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_CityApi.Extension
{
    public static class FluenValidationConfiguration
    {
		public static IMvcBuilder UseCityApiFluentValidation(this IMvcBuilder mvcBuilder)
		{
			mvcBuilder.AddFluentValidation(x => {
				x.ImplicitlyValidateChildProperties = true;
			});
			return mvcBuilder;
		}
	}
}
