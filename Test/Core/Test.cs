using MeyerCorp.Usps.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Meyer.UspsCore.Test.Core
{
    public abstract class Test
    {
		protected Test()
		{
			var builder = new ConfigurationBuilder()
				.AddUserSecrets<AddressesTest>();

			Configuration = builder.Build();

			ApiOptions = Options.Create(new ApiOptions
			{
				UspsApiKey = Configuration["ApiUsername"],
				UspsBaseUrl = BaseUrl,
			});
		}

        protected IConfiguration Configuration { get; set; }
        protected IOptions<ApiOptions> ApiOptions { get; }

        protected const string BaseUrl = "https://secure.shippingapis.com/ShippingAPI.dll";
    }
}