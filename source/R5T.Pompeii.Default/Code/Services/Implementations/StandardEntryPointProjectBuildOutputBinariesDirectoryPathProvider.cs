using System;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    public class StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider : IEntryPointProjectBuildOutputBinariesDirectoryPathProvider,IServiceImplementation
    {
        private IEntryPointProjectDirectoryPathProvider EntryPointProjectDirectoryPathProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
            IEntryPointProjectDirectoryPathProvider entryPointProjectDirectoryPathProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.EntryPointProjectDirectoryPathProvider = entryPointProjectDirectoryPathProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetEntryPointProjectBuildOutputBinariesDirectoryPath()
        {
            var entryPointProjectDirectoryPath = this.EntryPointProjectDirectoryPathProvider.GetEntryPointProjectDirectoryPath();

            var entryPointProjectBuildOutputBinariesDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetBinariesDirectoryPathFromProjectDirectoryPath(entryPointProjectDirectoryPath);
            return entryPointProjectBuildOutputBinariesDirectoryPath;
        }
    }
}
