using System;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    /// <summary>
    /// Gets the binaries directory path from the solution file path assuming the standard development directory structure enforced by Visual Studio:
    ///     ../{Solution Directory}/{Project Directory}/bin/Debug/netcoreapp2.2/publish (the binaries directory)
    /// </summary>
    public class PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider : IProjectBuildOutputBinariesDirectoryPathProvider,IServiceImplementation
    {
        private IEntryPointProjectBuildOutputPublishDirectoryPathProvider EntryPointProjectBuildOutputPublishDirectoryPathProvider { get; }


        public PublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider(
            IEntryPointProjectBuildOutputPublishDirectoryPathProvider entryPointProjectBuildOutputPublishDirectoryPathProvider)
        {
            this.EntryPointProjectBuildOutputPublishDirectoryPathProvider = entryPointProjectBuildOutputPublishDirectoryPathProvider;
        }

        public string GetProjectBuildOutputBinariesDirectoryPath()
        {
            var publishDirectoryPath = this.EntryPointProjectBuildOutputPublishDirectoryPathProvider.GetEntryPointProjectBuildOutputPublishDirectoryPath();
            return publishDirectoryPath;
        }
    }
}
