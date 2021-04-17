using MeyerCorp.Usps.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeyerCorp.Usps.Core.Extentions
{
	public static partial class Methods
	{
		public static T As<T>(this Model model) where T : Model
		{
			return model as T;
		}

		public static IEnumerable<T> As<T>(this IEnumerable<Model> models) where T : Model
		{
			return models
				.Select(m => m as T)
				.Where(m => m != null);
		}

		public static IEnumerable<Error> Errors(this IEnumerable<Model> models)
		{
			return models
				.Select(m => m as Error)
				.Where(m => m != null);
		}
	}
}
