using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Macommania;


namespace R5T.Pompeii.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="StandardSolutionAndProjectFileSystemConventions"/> implmentation of <see cref="ISolutionAndProjectFileSystemConventions"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardSolutionAndProjectFileSystemConventions(this IServiceCollection services,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ISolutionAndProjectFileSystemConventions, StandardSolutionAndProjectFileSystemConventions>()
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardSolutionAndProjectFileSystemConventions"/> implmentation of <see cref="ISolutionAndProjectFileSystemConventions"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ISolutionAndProjectFileSystemConventions> AddStandardSolutionAndProjectFileSystemConventionsAction(this IServiceCollection services,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISolutionAndProjectFileSystemConventions>(() => services.AddStandardSolutionAndProjectFileSystemConventions(
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardSolutionDirectoryPathProvider"/> implementation of <see cref="ISolutionDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardSolutionDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IExecutableFileDirectoryPathProvider> addExecutableFileDirectoryPathProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            services
                .AddSingleton<ISolutionDirectoryPathProvider, StandardSolutionDirectoryPathProvider>()
                .RunServiceAction(addExecutableFileDirectoryPathProvider)
                .RunServiceAction(addSolutionAndProjectFileSystemConventions)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardSolutionDirectoryPathProvider"/> implementation of <see cref="ISolutionDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ISolutionDirectoryPathProvider> AddStandardSolutionDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IExecutableFileDirectoryPathProvider> addExecutableFileDirectoryPathProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<ISolutionDirectoryPathProvider>(() => services.AddStandardSolutionDirectoryPathProvider(
                addExecutableFileDirectoryPathProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectEntryPointProjectNameProvider"/> implementation of <see cref="IEntryPointProjectNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectEntryPointProjectNameProvider(this IServiceCollection services, string entryPointProjectName)
        {
            services.AddSingleton<IEntryPointProjectNameProvider, DirectEntryPointProjectNameProvider>((serviceProvider) =>
            {
                var directEntryPointProjectNameProvider = new DirectEntryPointProjectNameProvider(entryPointProjectName);
                return directEntryPointProjectNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectEntryPointProjectNameProvider"/> implementation of <see cref="IEntryPointProjectNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectNameProvider> AddDirectEntryPointProjectNameProviderAction(this IServiceCollection services, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectNameProvider>(() => services.AddDirectEntryPointProjectNameProvider(entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<ISolutionDirectoryPathProvider> addSolutionDirectoryPathProvider,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            services
                .AddSingleton<IEntryPointProjectDirectoryPathProvider, StandardEntryPointProjectDirectoryPathProvider>()
                .RunServiceAction(addSolutionDirectoryPathProvider)
                .RunServiceAction(addEntryPointProjectNameProvider)
                .RunServiceAction(addSolutionDirectoryPathProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectDirectoryPathProvider> AddStandardEntryPointProjectDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<ISolutionDirectoryPathProvider> addSolutionDirectoryPathProvider,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectDirectoryPathProvider>(() => services.AddStandardEntryPointProjectDirectoryPathProvider(
                addSolutionDirectoryPathProvider,
                addEntryPointProjectNameProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SingleProjectInDirectoryEntryPointProjectFilePathProvider"/> implementation of <see cref="IEntryPointProjectFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSingleProjectInDirectoryEntryPointProjectFilePathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<IEntryPointProjectFilePathProvider, SingleProjectInDirectoryEntryPointProjectFilePathProvider>()
                .RunServiceAction(addEntryPointProjectDirectoryPathProvider)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SingleProjectInDirectoryEntryPointProjectFilePathProvider"/> implementation of <see cref="IEntryPointProjectFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFilePathProvider> AddSingleProjectInDirectoryEntryPointProjectFilePathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFilePathProvider>(() => services.AddSingleProjectInDirectoryEntryPointProjectFilePathProvider(
                addEntryPointProjectDirectoryPathProvider,
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectEntryPointProjectFrameworkNameProvider"/> implementation of <see cref="IEntryPointProjectFrameworkNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectEntryPointProjectFrameworkNameProvider(this IServiceCollection services, string entryPointProjectFrameworkName)
        {
            services.AddSingleton<IEntryPointProjectFrameworkNameProvider, DirectEntryPointProjectFrameworkNameProvider>((serviceProvider) =>
            {
                var directEntryPointProjectFrameworkNameProvider = new DirectEntryPointProjectFrameworkNameProvider(entryPointProjectFrameworkName);
                return directEntryPointProjectFrameworkNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectEntryPointProjectFrameworkNameProvider"/> implementation of <see cref="IEntryPointProjectFrameworkNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFrameworkNameProvider> AddDirectEntryPointProjectFrameworkNameProviderAction(this IServiceCollection services, string entryPointProjectFrameworkName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFrameworkNameProvider>(() => services.AddDirectEntryPointProjectFrameworkNameProvider(entryPointProjectFrameworkName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="NetCoreAppV2_2EntryPointProjectFrameworkNameProvider"/> implementation of <see cref="IEntryPointProjectFrameworkNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddNetCoreAppV2_2EntryPointProjectFrameworkNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<IEntryPointProjectFrameworkNameProvider, NetCoreAppV2_2EntryPointProjectFrameworkNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="NetCoreAppV2_2EntryPointProjectFrameworkNameProvider"/> implementation of <see cref="IEntryPointProjectFrameworkNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFrameworkNameProvider> AddNetCoreAppV2_2EntryPointProjectFrameworkNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFrameworkNameProvider>(() => services.AddNetCoreAppV2_2EntryPointProjectFrameworkNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            services
                .AddSingleton<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider, StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider>()
                .RunServiceAction(addEntryPointProjectDirectoryPathProvider)
                .RunServiceAction(addSolutionAndProjectFileSystemConventions)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectDirectoryPathProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectEntryPointProjectBuildConfigurationNameProvider"/> implementation of <see cref="IEntryPointProjectBuildConfigurationNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectEntryPointProjectBuildConfigurationNameProvider(this IServiceCollection services, string entryPointProjectBuildConfigurationName)
        {
            services.AddSingleton<IEntryPointProjectBuildConfigurationNameProvider, DirectEntryPointProjectBuildConfigurationNameProvider>((serviceProvider) =>
            {
                var directEntryPointProjectBuildConfigurationNameProvider = new DirectEntryPointProjectBuildConfigurationNameProvider(entryPointProjectBuildConfigurationName);
                return directEntryPointProjectBuildConfigurationNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectEntryPointProjectBuildConfigurationNameProvider"/> implementation of <see cref="IEntryPointProjectBuildConfigurationNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> AddDirectEntryPointProjectBuildConfigurationNameProviderAction(this IServiceCollection services, string entryPointProjectBuildConfigurationName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildConfigurationNameProvider>(() => services.AddDirectEntryPointProjectBuildConfigurationNameProvider(entryPointProjectBuildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> addEntryPointProjectBuildOutputBinariesDirectoryPathProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services
                .AddSingleton<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider, StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>()
                .RunServiceAction(addEntryPointProjectBuildOutputBinariesDirectoryPathProvider)
                .RunServiceAction(addEntryPointProjectBuildConfigurationNameProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> addEntryPointProjectBuildOutputBinariesDirectoryPathProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                addEntryPointProjectBuildOutputBinariesDirectoryPathProvider,
                addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> addEntryPointProjectBuildOutputConfigurationDirectoryPathProvider,
            ServiceAction<IEntryPointProjectFrameworkNameProvider> addEntryPointProjectFrameworkNameProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            services
                .AddSingleton<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider, StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider>()
                .RunServiceAction(addEntryPointProjectBuildOutputConfigurationDirectoryPathProvider)
                .RunServiceAction(addEntryPointProjectFrameworkNameProvider)
                .RunServiceAction(addSolutionAndProjectFileSystemConventions)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> addEntryPointProjectBuildOutputConfigurationDirectoryPathProvider,
            ServiceAction<IEntryPointProjectFrameworkNameProvider> addEntryPointProjectFrameworkNameProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
                addEntryPointProjectBuildOutputConfigurationDirectoryPathProvider,
                addEntryPointProjectFrameworkNameProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            services
                .AddSingleton<IEntryPointProjectBuildOutputPublishDirectoryPathProvider, StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider>()
                .RunServiceAction(addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider)
                .RunServiceAction(addSolutionAndProjectFileSystemConventions)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,
            ServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }
    }
}
