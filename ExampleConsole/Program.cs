using MeyerCorp.Usps.Core.Xml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MeyerCorp.Usps.Example
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine("Welcome to the ExampleConsole for the MeyerCorp.Usps.Core");
			Console.WriteLine();

			if (args.Length < 1)
			{
				while (true)
				{
					Console.WriteLine("Enter the line number to try out the Usps.Core:");
					Console.WriteLine();
					Console.WriteLine("1: To validate an address");
					Console.WriteLine("2: To look up the city and state for a Zip Code");
					Console.WriteLine("3: To look up a Zip Code for an address");
					Console.WriteLine();
					Console.WriteLine("99: Exit the program");

					var line = Console.ReadLine();

					try
					{
						switch (line)
						{
							case "1":
								await ValidateAddressAsync();
								break;
							case "2":
								await LookupCityStateAsync();
								break;
							case "99":
								foreach (var node in Process.GetProcessesByName("ExampleConsole"))
									node.Kill();

								break;
							default:
								Console.WriteLine();
								Console.WriteLine("C'mon, let's enter one of the choices, please.");
								Console.WriteLine();
								break;
						}
					}
					catch (InvalidOperationException ex)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine();
						Console.WriteLine("We've got a problem. This is most likely an error returned by the USPS API:");
						Console.WriteLine();
						Console.WriteLine(ex.Message);
						Console.WriteLine();
					}
					catch (Exception ex)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine();
						Console.WriteLine("There's a problem with this application. Let the owner know, thx.");
						Console.WriteLine();
					}
					finally
					{
						Console.ForegroundColor = ConsoleColor.White;
					}
				}
			}
		}

		#region Validation

		private static async Task ValidateAddressAsync()
		{
			var configuration = GetConfiguration();
			var options = Options.Create(new Core.ApiOptions
			{
				UspsApiKey = configuration["ApiUsername"],
				UspsBaseUrl = "https://secure.shippingapis.com/ShippingAPI.dll",
			});

			using var addresses = new Core.Addresses(options);

			var addressestovalidate = GetAddressesToValidate();

			var results = await addresses.ValidateAsync(1, addressestovalidate.ToArray());

			Print(results);
		}

		private static IEnumerable<Address> GetAddressesToValidate()
		{
			var output = new List<Address>();

			var index = 1;
			var exit = false;

			while (!exit && index < 6)
				exit = GetAddressesToValidate(output, index++);

			return output;
		}

		private static bool GetAddressesToValidate(List<Address> output, int index)
		{
			if (AskWhetherReadyToRun())
				return true;
			//var numberword = index switch
			//{
			//	1 => "first",
			//	2 => "second",
			//	3 => "third",
			//	4 => "fourth",
			//	5 => "fifth",
			//	_ => throw new ArgumentOutOfRangeException(),
			//};
			Console.WriteLine("Enter the first address line (or leave blank):");
			var address1_1 = Console.ReadLine();
			Console.WriteLine("Enter the second address line (or leave blank):");
			var address2_1 = Console.ReadLine();
			Console.WriteLine("Enter the firm name (or leave blank):");
			var firmname_1 = Console.ReadLine();
			Console.WriteLine("Enter the city (or leave blank):");
			var city_1 = Console.ReadLine();
			Console.WriteLine("Enter the state (or leave blank):");
			var state_1 = Console.ReadLine();
			Console.WriteLine("Enter the 5-digit Zip Code (or leave blank):");
			var zip5_1 = Console.ReadLine();
			Console.WriteLine("Enter the 4-digit Zip Code suffix (or leave blank):");
			var zip4_1 = Console.ReadLine();
			Console.WriteLine("Enter the urbanization (or leave blank):");
			var urbanization_1 = Console.ReadLine();

			output.Add(new Address
			{
				Address1 = address1_1,
				Address2 = address2_1,
				City = city_1,
				FirmName = firmname_1,
				Id = index,
				State = state_1,
				Urbanization = urbanization_1,
				Zip4 = zip4_1,
				Zip5 = zip5_1,
			});

			return false;
		}

		private static void Print(IEnumerable<Core.Models.Address> results)
		{
			Console.WriteLine("Survey says!");
			Console.WriteLine();

			foreach (var result in results)
			{
				Console.WriteLine($"Address #{result.Id}:");
				Console.WriteLine($"Address 1: {result.Address1}");
				Console.WriteLine($"Address 2: {result.Address2}");
				Console.WriteLine($"City: {result.City}");
				Console.WriteLine($"State: {result.State}");
				Console.WriteLine($"Zip 5: {result.Zip5}");
				Console.WriteLine($"Zip 4: {result.Zip4}");
				Console.WriteLine($"Urbanization: {result.Urbanization}");
				Console.WriteLine($"Address 2 (abbr): {result.Address2Abbreviation}");
				Console.WriteLine($"City (abbr): {result.CityAbbreviation}");
				Console.WriteLine($"Is a Business:{result.Business}");
				Console.WriteLine($"Carrier Route: {result.CarrierRoute}");
				Console.WriteLine($"Central Delivery Point: {result.CentralDeliveryPoint}");
				Console.WriteLine($"Delivery Point: {result.DeliveryPoint}");
				Console.WriteLine($"DPVCRMA: {result.DPVCMRA}");
				Console.WriteLine($"DPV Confirmation: {result.DPVConfirmation}");
				Console.WriteLine($"DPV Footnotes: {result.DPVFootnotes}");
				Console.WriteLine($"Error: {result.Error}");
				Console.WriteLine($"Firm Name: {result.FirmName}");
				Console.WriteLine($"FootNotes: {result.Footnotes}");
				Console.WriteLine($"Is Vacant: {result.Vacant}");
				Console.WriteLine();
			}
		}

		#endregion

		#region CityStateLookup

		private static async Task LookupCityStateAsync()
		{
			var configuration = GetConfiguration();
			var options = Options.Create(new Core.ApiOptions
			{
				UspsApiKey = configuration["ApiUsername"],
				UspsBaseUrl = "https://secure.shippingapis.com/ShippingAPI.dll",
			});

			using var addresses = new Core.Addresses(options);

			var citystatestovalidate = GetCityStatesToLookup();

			var results = await addresses.LookupCityStateAsync(citystatestovalidate.ToArray());

			Print(results);
		}

		private static void Print(IEnumerable<Core.Models.CityState> results)
		{
			Console.WriteLine("Survey says!");
			Console.WriteLine();

			foreach (var result in results)
			{
				Console.WriteLine($"Zip Code #: {result.Id}");
				Console.WriteLine($"City: {result.City}");
				Console.WriteLine($"State: {result.State}");
				Console.WriteLine($"Zip 5: {result.Zip5}");
				Console.WriteLine($"Error: {result.Error}");
				Console.WriteLine();
			}
		}

		private static IEnumerable<CityState> GetCityStatesToLookup()
		{
			var output = new List<CityState>();

			var index = 1;
			var exit = false;

			while (!exit && index < 6)
				exit = GetCityStatesToLookup(output, index++);

			return output;
		}

		private static bool GetCityStatesToLookup(List<CityState> output, int index)
		{
			if (AskWhetherReadyToRun())
				return true;

			Console.WriteLine("Enter Zip Code:");
			var zipcode = Console.ReadLine();

			output.Add(new CityState
			{
				Id = index,
				Zip5 = zipcode,
			});

			return false;
		}

		#endregion

		#region ZipCodeLookup

		#endregion

		private static bool AskWhetherReadyToRun()
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Press 'ENTER' to add an entry or just enter '^^' to indicate that you are ready to run the validation.");
			Console.ForegroundColor = ConsoleColor.White;

			return Console.ReadLine().Equals("^^");
		}

		/// <summary>
		/// Add your USPS API user ID to your user secrets!
		/// </summary>
		/// <returns></returns>
		private static IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.AddUserSecrets<Program>();

			return builder.Build();
		}
	}
}
