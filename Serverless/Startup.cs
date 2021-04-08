//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//[assembly: FunctionsStartup(typeof(MeyerCorp.Usps.Serverless.Startup))]

//namespace MeyerCorp.Usps.Serverless
//{
//	public class Startup : FunctionsStartup
//	{
//		public const int SystemError = 0x01000000;
//		public const int ConfigurationError = 0x00000010;

//		public override void Configure(IFunctionsHostBuilder builder)
//		{
//			builder
//				.Services
//				.AddOptions<Configuration>()
//				.Configure<IConfiguration>((settings, configuration) =>
//				{
//					configuration.GetSection("MyConfiguration").Bind(settings);
//				});

//			builder.Services.AddOptions<MyConfigurationSecrets>()
//				.Configure<IConfiguration>((settings, configuration) =>
//				{
//					configuration.GetSection("MyConfigurationSecrets").Bind(settings);
//				});
//		}

//		private static string TryGetEnvironmentVariable(string key)
//		{
//			if (String.IsNullOrEmpty("key"))
//				throw new InvalidOperationException($"'{key}' application setting must be present. Use empty string if no value is needed.")
//				{
//					HResult = SystemError + ConfigurationError,
//				};
//			else
//				return Environment.GetEnvironmentVariable(key);
//		}
//	}
//}