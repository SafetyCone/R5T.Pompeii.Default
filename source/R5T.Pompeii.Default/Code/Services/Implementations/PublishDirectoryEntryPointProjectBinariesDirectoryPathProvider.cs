using System;


namespace R5T.Pompeii.Default
{
    public class PublishDirectoryEntryPointProjectBinariesDirectoryPathProvider : IEntryPointProjectBinariesDirectoryPathProvider
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
