using System;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    public class StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider : IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider,IServiceImplementation
    {
        private IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider EntryPointProjectBuildOutputConfigurationDirectoryPathProvider { get; }
        private IEntryPointProjectFrameworkNameProvider EntryPointProjectFrameworkNameProvider { get;}
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
            IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider entryPointProjectBuildOutputConfigurationDirectoryPathProvider,
            IEntryPointProjectFrameworkNameProvider entryPointProjectFrameworkNameProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.EntryPointProjectBuildOutputConfigurationDirectoryPathProvider = entryPointProjectBuildOutputConfigurationDirectoryPathProvider;
            this.EntryPointProjectFrameworkNameProvider = entryPointProjectFrameworkNameProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectBuildOutputFrameworkDirectoryPath()
        {
            var buildOutputConfigurationDirectoryPath = this.EntryPointProjectBuildOutputConfigurationDirectoryPathProvider.GetEntryPointProjectBuildOutputConfigurationDirectoryPath();

            var frameworkName = this.EntryPointProjectFrameworkNameProvider.GetEntryPointProjectFrameworkName();

            var buildOutputFrameworkDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetFrameworkDirectoryPathFromConfigurationDirectoryPath(buildOutputConfigurationDirectoryPath, frameworkName);
            return buildOutputFrameworkDirectoryPath;
        }
    }
}
