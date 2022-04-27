using System;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    public class StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider : IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider,IServiceImplementation
    {
        private IEntryPointProjectBuildOutputBinariesDirectoryPathProvider EntryPointProjectBuildOutputBinariesDirectoryPathProvider { get; }
        private IBuildConfigurationNameProvider BuildConfigurationNameProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
            IEntryPointProjectBuildOutputBinariesDirectoryPathProvider entryPointProjectBuildOutputBinariesDirectoryPathProvider,
            IBuildConfigurationNameProvider buildConfigurationNameProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.EntryPointProjectBuildOutputBinariesDirectoryPathProvider = entryPointProjectBuildOutputBinariesDirectoryPathProvider;
            this.BuildConfigurationNameProvider = buildConfigurationNameProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectBuildOutputConfigurationDirectoryPath()
        {
            var binDirectoryPath = this.EntryPointProjectBuildOutputBinariesDirectoryPathProvider.GetEntryPointProjectBuildOutputBinariesDirectoryPath();

            var buildConfigurationName = this.BuildConfigurationNameProvider.GetBuildConfigurationName();

            var configurationDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetConfigurationDirectoryPathFromBinariesDirectoryPath(binDirectoryPath, buildConfigurationName);
            return configurationDirectoryPath;
        }
    }
}
