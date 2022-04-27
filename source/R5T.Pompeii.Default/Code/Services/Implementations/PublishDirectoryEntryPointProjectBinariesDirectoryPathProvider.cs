using System;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    public class PublishDirectoryEntryPointProjectBinariesDirectoryPathProvider : IEntryPointProjectBinariesDirectoryPathProvider,IServiceImplementation
    {
        private IEntryPointProjectBuildOutputPublishDirectoryPathProvider EntryPointProjectBuildOutputPublishDirectoryPathProvider { get; }


        public PublishDirectoryEntryPointProjectBinariesDirectoryPathProvider(
            IEntryPointProjectBuildOutputPublishDirectoryPathProvider entryPointProjectBuildOutputPublishDirectoryPathProvider)
        {
            this.EntryPointProjectBuildOutputPublishDirectoryPathProvider = entryPointProjectBuildOutputPublishDirectoryPathProvider;
        }

        public string GetEntryPointProjectBinariesDirectoryPath()
        {
            var publishDirectoryPath = this.EntryPointProjectBuildOutputPublishDirectoryPathProvider.GetEntryPointProjectBuildOutputPublishDirectoryPath();
            return publishDirectoryPath;
        }
    }
}
