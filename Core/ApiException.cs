using MeyerCorp.Usps.Core.Models;
using System;
using System.Runtime.Serialization;

namespace MeyerCorp.Usps.Core
{
	public class ApiException : Exception
	{
		const string DefaultMessage = "USPS API returned an error.";

		public ApiException(Error error) : base(DefaultMessage) { Error = error; }

		public ApiException(Error error, Exception innerException) : base(DefaultMessage, innerException) { Error = error; }

		protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		public bool HasError { get { return Data.Contains("Error"); } }

		public Error Error
		{
			get
			{
				return HasError
				  ? Data["Error"] as Error
				  : null;
			}
			set
			{
				if (HasError)
					Data.Add("Error", value);
				else
					Data["Error"] = value;
			}
		}
	}
}
