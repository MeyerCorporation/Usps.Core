using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Serverless
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

            var address = new AddressValidation(firmname,
                address1,
                address2,
                city,
                state,
                zip5,
                zip4,
                urbanization);

            await address.VerifyAddressAsync();
            string responseMessage = string.IsNullOrEmpty(address1)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {address1}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
