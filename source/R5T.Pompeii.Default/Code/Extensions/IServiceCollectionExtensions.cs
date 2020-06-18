using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Angleterria;
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
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
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
        public static IServiceAction<ISolutionAndProjectFileSystemConventions> AddStandardSolutionAndProjectFileSystemConventionsAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISolutionAndProjectFileSystemConventions>(() => services.AddStandardSolutionAndProjectFileSystemConventions(
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardSolutionDirectoryPathProvider"/> implementation of <see cref="ISolutionDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardSolutionDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IExecutableFileDirectoryPathProvider> addExecutableFileDirectoryPathProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
            IServiceAction<IExecutableFileDirectoryPathProvider> addExecutableFileDirectoryPathProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
        public static IServiceAction<IEntryPointProjectNameProvider> AddDirectEntryPointProjectNameProviderAction(this IServiceCollection services, string entryPointProjectName)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectNameProvider>(() => services.AddDirectEntryPointProjectNameProvider(entryPointProjectName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<ISolutionDirectoryPathProvider> addSolutionDirectoryPathProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
        public static IServiceAction<IEntryPointProjectDirectoryPathProvider> AddStandardEntryPointProjectDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionDirectoryPathProvider> addSolutionDirectoryPathProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
            IServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
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
        public static IServiceAction<IEntryPointProjectFilePathProvider> AddSingleProjectInDirectoryEntryPointProjectFilePathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
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
        public static IServiceAction<IEntryPointProjectFrameworkNameProvider> AddDirectEntryPointProjectFrameworkNameProviderAction(this IServiceCollection services, string entryPointProjectFrameworkName)
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
        public static IServiceAction<IEntryPointProjectFrameworkNameProvider> AddNetCoreAppV2_2EntryPointProjectFrameworkNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFrameworkNameProvider>(() => services.AddNetCoreAppV2_2EntryPointProjectFrameworkNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
        public static IServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectDirectoryPathProvider> addEntryPointProjectDirectoryPathProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectDirectoryPathProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectBuildConfigurationNameProvider"/> implementation of <see cref="IBuildConfigurationNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectBuildConfigurationNameProvider(this IServiceCollection services, string entryPointProjectBuildConfigurationName)
        {
            services.AddSingleton<IBuildConfigurationNameProvider, DirectBuildConfigurationNameProvider>((serviceProvider) =>
            {
                var directEntryPointProjectBuildConfigurationNameProvider = new DirectBuildConfigurationNameProvider(entryPointProjectBuildConfigurationName);
                return directEntryPointProjectBuildConfigurationNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectBuildConfigurationNameProvider"/> implementation of <see cref="IBuildConfigurationNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IBuildConfigurationNameProvider> AddDirectBuildConfigurationNameProviderAction(this IServiceCollection services, string entryPointProjectBuildConfigurationName)
        {
            var serviceAction = new ServiceAction<IBuildConfigurationNameProvider>(() => services.AddDirectBuildConfigurationNameProvider(entryPointProjectBuildConfigurationName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> addEntryPointProjectBuildOutputBinariesDirectoryPathProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            services
                .AddSingleton<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider, StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>()
                .RunServiceAction(addEntryPointProjectBuildOutputBinariesDirectoryPathProvider)
                .RunServiceAction(addBuildConfigurationNameProvider)
                .RunServiceAction(addSolutionAndProjectFileSystemConventions)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> addEntryPointProjectBuildOutputBinariesDirectoryPathProvider,
            IServiceAction<IBuildConfigurationNameProvider> addBuildConfigurationNameProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                addEntryPointProjectBuildOutputBinariesDirectoryPathProvider,
                addBuildConfigurationNameProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> implementation of <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> addEntryPointProjectBuildOutputConfigurationDirectoryPathProvider,
            IServiceAction<IEntryPointProjectFrameworkNameProvider> addEntryPointProjectFrameworkNameProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
        public static IServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> addEntryPointProjectBuildOutputConfigurationDirectoryPathProvider,
            IServiceAction<IEntryPointProjectFrameworkNameProvider> addEntryPointProjectFrameworkNameProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
            IServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
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
        public static IServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider>(() => services.AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                addEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,
                addSolutionAndProjectFileSystemConventions));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectSolutionFileNameProvider"/> implementation of <see cref="ISolutionFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectSolutionFileNameProvider(this IServiceCollection services, string solutionFileName)
        {
            services.AddSingleton<ISolutionFileNameProvider, DirectSolutionFileNameProvider>((serviceProvider) =>
            {
                var directSolutionFileNameProvider = new DirectSolutionFileNameProvider(solutionFileName);
                return directSolutionFileNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectSolutionFileNameProvider"/> implementation of <see cref="ISolutionFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISolutionFileNameProvider> AddDirectSolutionFileNameProviderAction(this IServiceCollection services, string solutionFileName)
        {
            var serviceAction = new ServiceAction<ISolutionFileNameProvider>(() => services.AddDirectSolutionFileNameProvider(solutionFileName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SingleSolutionFileNameProvider"/> implementation of <see cref="ISolutionFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSingleSolutionFileNameProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ISolutionFileNameProvider, SingleSolutionFileNameProvider>()
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SingleSolutionFileNameProvider"/> implementation of <see cref="ISolutionFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISolutionFileNameProvider> AddSingleSolutionFileNameProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISolutionFileNameProvider>(() => services.AddSingleSolutionFileNameProvider(
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardSolutionFilePathProvider"/> implementation of <see cref="ISolutionFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardSolutionFilePathProvider(this IServiceCollection services,
            IServiceAction<ISolutionDirectoryPathProvider> addSolutionDirectoryPathProvider,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ISolutionFilePathProvider, StandardSolutionFilePathProvider>()
                .RunServiceAction(addSolutionDirectoryPathProvider)
                .RunServiceAction(addSolutionFileNameProvider)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardSolutionFilePathProvider"/> implementation of <see cref="ISolutionFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISolutionFilePathProvider> AddStandardSolutionFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionDirectoryPathProvider> addSolutionDirectoryPathProvider,
            IServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddStandardSolutionFilePathProvider(
                addSolutionDirectoryPathProvider,
                addSolutionFileNameProvider,
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StandardProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStandardProjectBinariesOutputDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<ISolutionFilePathProvider> addSolutionFilePathProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IVisualStudioStringlyTypedPathPartsOperator> addVisualStudioStringlyTypedPathPartsOperator,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<IProjectBuildOutputBinariesDirectoryPathProvider, StandardProjectBuildOutputBinariesDirectoryPathProvider>()
                .RunServiceAction(addSolutionFilePathProvider)
                .RunServiceAction(addEntryPointProjectNameProvider)
                .RunServiceAction(addVisualStudioStringlyTypedPathPartsOperator)
                .RunServiceAction(addSolutionAndProjectFileSystemConventions)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StandardProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider> AddStandardProjectBinariesOutputDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<ISolutionFilePathProvider> addSolutionFilePathProvider,
            IServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            IServiceAction<IVisualStudioStringlyTypedPathPartsOperator> addVisualStudioStringlyTypedPathPartsOperator,
            IServiceAction<ISolutionAndProjectFileSystemConventions> addSolutionAndProjectFileSystemConventions,
            IServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddStandardProjectBinariesOutputDirectoryPathProvider(
                addSolutionFilePathProvider,
                addEntryPointProjectNameProvider,
                addVisualStudioStringlyTypedPathPartsOperator,
                addSolutionAndProjectFileSystemConventions,
                addStringlyTypedPathOperator));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddPublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> addEntryPointProjectBuildOutputPublishDirectoryPathProvider)
        {
            services
                .AddSingleton<IProjectBuildOutputBinariesDirectoryPathProvider, PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider>()
                .RunServiceAction(addEntryPointProjectBuildOutputPublishDirectoryPathProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider"/> implementation of <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider> AddPublishDirectoryProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> addEntryPointProjectBuildOutputPublishDirectoryPathProvider)
        {
            var serviceAction = new ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddPublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectBuildOutputPublishDirectoryPathProvider));
            return serviceAction;
        }
    }
}
