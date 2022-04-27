using System;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    public class StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider : IEntryPointProjectBuildOutputPublishDirectoryPathProvider,IServiceImplementation
    {
        private IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider EntryPointProjectBuildOutputFrameworkDirectoryPathProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(
            IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider entryPointProjectBuildOutputFrameworkDirectoryPathProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.EntryPointProjectBuildOutputFrameworkDirectoryPathProvider = entryPointProjectBuildOutputFrameworkDirectoryPathProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectBuildOutputPublishDirectoryPath()
        {
            var frameworkDirectoryPath = this.EntryPointProjectBuildOutputFrameworkDirectoryPathProvider.GetEntryPointProjectBuildOutputFrameworkDirectoryPath();

            var publishDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetPublishDirectoryPathFromFrameworkDirectoryPath(frameworkDirectoryPath);
            return publishDirectoryPath;
        }
    }
}
