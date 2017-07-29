using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Excqape;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class RegistrationExtensions
	{
		private static readonly Type[] ExcqapeTypes = { typeof(IQuery<,>), typeof(ICommand<>) };

		private static void AddExcqape(this IServiceCollection services, Action<RegisterExcqapeOptions> optionsConfig)
		{
			if (optionsConfig == null)
				throw new ArgumentNullException(nameof(optionsConfig));

			var options = new RegisterExcqapeOptions();
			optionsConfig.Invoke(options);

			if (options.FromAssembliesOf == null || !options.FromAssembliesOf.Any())
				throw new ArgumentException("types to scan assemblies of cannot be null or empty");

			services.Scan(scan => scan
				.FromAssembliesOf(options.FromAssembliesOf)
				.AddClasses(classes => classes.AssignableToAny(ExcqapeTypes))
				.AsImplementedInterfaces()
				.WithLifetime(options.Lifetime)
			);
		}
	}

	public class RegisterExcqapeOptions
	{
		public ICollection<Type> FromAssembliesOf { get; private set; }
		public ServiceLifetime Lifetime { get; private set; }

		public RegisterExcqapeOptions()
		{
			FromAssembliesOf = new List<Type>(0);
			Lifetime = ServiceLifetime.Scoped;
		}

		public RegisterExcqapeOptions ScanAssembliesOf(params Type[] fromAssembliesOf)
		{
			if (fromAssembliesOf == null || !fromAssembliesOf.Any())
				throw new ArgumentException("list of types to scan assemblies of cannot be null or empty", nameof(fromAssembliesOf));

			if (fromAssembliesOf.Any(x => x == null))
				throw new ArgumentException("list of types to scan assemblies of cannot contain null", nameof(fromAssembliesOf));

			FromAssembliesOf = fromAssembliesOf;
			return this;
		}

		public RegisterExcqapeOptions WithLifetime(ServiceLifetime lifetime)
		{
			if (!typeof(ServiceLifetime).GetTypeInfo().IsEnumDefined(lifetime))
				throw new ArgumentException("not a valid ServiceLifetime", nameof(lifetime));

			Lifetime = lifetime;
			return this;
		}
	}
}
