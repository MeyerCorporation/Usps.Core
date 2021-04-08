using MeyerCorp.Usps.Core;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(MeyerCorp.Usps.Api.Startup))]

namespace MeyerCorp.Usps.Api
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			var configuration = builder
				.GetContext()
				.Configuration;

			builder
				.Services
				.AddOptions<ApiOptions>()
				.Configure(options =>
				{
					options.UspsApiKey = TryGetEnvironmentVariable("UspsApiKey");
					options.UspsBaseUrl = TryGetEnvironmentVariable("UspsBaseUrl");
				});

			builder
				.Services
				.AddScoped<IAddresses, Addresses>();
		}

		private static string TryGetEnvironmentVariable(string key)
		{
			if (String.IsNullOrEmpty("key"))
				throw new InvalidOperationException($"'{key}' application setting must be present. Use empty string if no value is needed.");
			else
				return Environment.GetEnvironmentVariable(key);
		}
	}
}
