using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MeyerCorp.Usps.Api
{
	public static partial class Methods
	{
		/// <summary>
		/// Add a CORS policy that all controllers in this library will use.
		/// </summary>
		/// <param name="builder">Builder to add to.</param>
		/// <param name="configurePolicy">Configuration delegate.</param>
		public static void AddUspsCorsPolicy(this CorsOptions builder, Action<CorsPolicyBuilder> configurePolicy)
		{
			builder.AddPolicy("UspsCors", configurePolicy);
		}

		//public static IServiceCollection AddConfiguration(this IServiceCollection services, string connectionString, Action<UspsOptions> uspsOptions)
		//{
		//services.A}
	}
}
