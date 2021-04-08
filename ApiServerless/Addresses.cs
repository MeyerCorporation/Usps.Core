using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Core.Api
{
	public class Addresses
	{
		private readonly IAddresses AddressValidator;

		public Addresses(IAddresses addressesValidator) { AddressValidator = addressesValidator; }

		[FunctionName("Validate")]
		[OpenApiOperation(operationId: "Validate", tags: new[] { "Address Validation" })]
		[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
		[OpenApiParameter(name: "revision", In = ParameterLocation.Query, Required = true, Type = typeof(int), Description = "Value used to return of all available response fields. Set this value to 1 to return all currently documented response fields.")]

		[OpenApiParameter(name: "firmName_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Firm Name (first address).")]
		[OpenApiParameter(name: "address1_1", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "Delivery Address in the destination address. Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in the Detail 1 Record (first address).")]
		[OpenApiParameter(name: "address2_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. May contain secondary unit designator, such as APT or SUITE, for Accountable mail. (first address)")]
		[OpenApiParameter(name: "city_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "City name of the destination address. (first address)")]
		[OpenApiParameter(name: "state_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Two-character state code of the destination address. (first address)")]
		[OpenApiParameter(name: "urbanization_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Urbanization. For Puerto Rico addresses only. (first address)")]
		[OpenApiParameter(name: "zip5_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination 5-digit ZIP Code. Numeric values (0-9) only. If International, all zeroes. (first address)")]
		[OpenApiParameter(name: "zip4_1", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination ZIP + 4 Numeric values(0 - 9) only.If International, all zeroes.")]

		[OpenApiParameter(name: "firmName_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Firm Name (second address).")]
		[OpenApiParameter(name: "address1_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in the Detail 1 Record (second address).")]
		[OpenApiParameter(name: "address2_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. May contain secondary unit designator, such as APT or SUITE, for Accountable mail. (second address)")]
		[OpenApiParameter(name: "city_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "City name of the destination address. (second address)")]
		[OpenApiParameter(name: "state_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Two-character state code of the destination address. (second address)")]
		[OpenApiParameter(name: "urbanization_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Urbanization. For Puerto Rico addresses only. (second address)")]
		[OpenApiParameter(name: "zip5_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination 5-digit ZIP Code. Numeric values (0-9) only. If International, all zeroes. (second address)")]
		[OpenApiParameter(name: "zip4_2", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination ZIP + 4 Numeric values(0 - 9) only.If International, all zeroes.")]

		[OpenApiParameter(name: "firmName_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Firm Name (third address).")]
		[OpenApiParameter(name: "address1_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in the Detail 1 Record (third address).")]
		[OpenApiParameter(name: "address2_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. May contain secondary unit designator, such as APT or SUITE, for Accountable mail. (third address)")]
		[OpenApiParameter(name: "city_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "City name of the destination address. (third address)")]
		[OpenApiParameter(name: "state_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Two-character state code of the destination address. (third address)")]
		[OpenApiParameter(name: "urbanization_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Urbanization. For Puerto Rico addresses only. (third address)")]
		[OpenApiParameter(name: "zip5_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination 5-digit ZIP Code. Numeric values (0-9) only. If International, all zeroes. (third address)")]
		[OpenApiParameter(name: "zip4_3", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination ZIP + 4 Numeric values(0 - 9) only.If International, all zeroes.")]

		[OpenApiParameter(name: "firmName_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Firm Name (fourth address).")]
		[OpenApiParameter(name: "address1_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in the Detail 1 Record (fourth address).")]
		[OpenApiParameter(name: "address2_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. May contain secondary unit designator, such as APT or SUITE, for Accountable mail. (fourth address)")]
		[OpenApiParameter(name: "city_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "City name of the destination address. (fourth address)")]
		[OpenApiParameter(name: "state_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Two-character state code of the destination address. (fourth address)")]
		[OpenApiParameter(name: "urbanization_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Urbanization. For Puerto Rico addresses only. (fourth address)")]
		[OpenApiParameter(name: "zip5_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination 5-digit ZIP Code. Numeric values (0-9) only. If International, all zeroes. (fourth address)")]
		[OpenApiParameter(name: "zip4_4", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination ZIP + 4 Numeric values(0 - 9) only.If International, all zeroes.")]

		[OpenApiParameter(name: "firmName_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Firm Name (fifth address).")]
		[OpenApiParameter(name: "address1_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. Required for all mail and packages, however 11-digit Destination Delivery Point ZIP+4 Code can be provided as an alternative in the Detail 1 Record (fifth address).")]
		[OpenApiParameter(name: "address2_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Delivery Address in the destination address. May contain secondary unit designator, such as APT or SUITE, for Accountable mail. (fifth address)")]
		[OpenApiParameter(name: "city_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "City name of the destination address. (fifth address)")]
		[OpenApiParameter(name: "state_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Two-character state code of the destination address. (fifth address)")]
		[OpenApiParameter(name: "urbanization_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Urbanization. For Puerto Rico addresses only. (fifth address)")]
		[OpenApiParameter(name: "zip5_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination 5-digit ZIP Code. Numeric values (0-9) only. If International, all zeroes. (fifth address)")]
		[OpenApiParameter(name: "zip4_5", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Destination ZIP + 4 Numeric values(0 - 9) only.If International, all zeroes.")]

		[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
		public async Task<IActionResult> Validate([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Address/Validate")] HttpRequest req, ILogger log)
		{
			log.LogInformation("HTTP trigger for Validate function processed a request.");

			if (!req.Query.ContainsKey("revision")) return new BadRequestObjectResult("Revision must be specified in the query: 'revision=0|1'.");

			var revision = Int32.Parse(req.Query["revision"]);
			var addresses = GetAddresses(req.Query).ToArray();

			try
			{
				var result = await AddressValidator.ValidateAsync(revision, addresses);

				return new OkObjectResult(result);
			}
			catch (InvalidOperationException ex) { return new BadRequestObjectResult(ex.Message); }
		}

		private static IEnumerable<Xml.Address> GetAddresses(IQueryCollection query)
		{
			var output = new List<Xml.Address>();

			for (int index = 1; index < 6; index++)
			{
				if (CheckAddressPameters(query, index))
				{
					output.Add(new Xml.Address
					{
						Id = index,
						FirmName = query[$"firmName_{index}"],
						Address1 = query[$"address1_{index}"],
						Address2 = query[$"address2_{index}"],
						City = query[$"city_{index}"],
						State = query[$"state_{index}"],
						Urbanization = query[$"urbanization_{index}"],
						Zip5 = query[$"zip5_{index}"],
						Zip4 = query[$"zip4_{index}"],
					});
				}
			}

			return output;
		}

		private static bool CheckAddressPameters(IQueryCollection query, int index)
		{
			return query.ContainsKey($"firmName_{index}")
				|| query.ContainsKey($"address1_{index}")
				|| query.ContainsKey($"address2_{index}")
				|| query.ContainsKey($"city_{index}")
				|| query.ContainsKey($"state_{index}")
				|| query.ContainsKey($"urbanization_{index}")
				|| query.ContainsKey($"zip5_{index}")
				|| query.ContainsKey($"zip4_{index}");
		}
	}
}

