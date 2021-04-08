using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MeyerCorp.Usps.Addresses;

namespace MeyerCorp.Usps.Serverless
{
	public static class Addresses
	{
		[FunctionName("Address")]
		public static async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
			ILogger log)
		{
			log.LogInformation("C# HTTP Address function processed a request.");

			var firmname = req.Query["firmname"];
			var address1 = req.Query["address1"];
			var address2 = req.Query["address2"];
			var city = req.Query["city"];
			var state = req.Query["state"];
			var zip5 = req.Query["zip5"];
			var zip4 = req.Query["zip4"];
			var urbanization = req.Query["urbanization"];

			var validator = new AddressValidation(baseUrl: Environment.GetEnvironmentVariable("BaseUrl"),
				path: Environment.GetEnvironmentVariable("Path"));

			try
			{
				var address = await validator.VerifyAddressAsync(firmname,
					address1,
					address2,
					city,
					state,
					zip5,
					zip4,
					urbanization);

				return new OkObjectResult(address);
			}
			catch (InvalidOperationException ex) { return new BadRequestObjectResult(ex.Message); }
		}
	}
}
