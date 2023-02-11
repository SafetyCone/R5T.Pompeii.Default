using System;

using R5T.Macommania;using R5T.T0064;


namespace R5T.Pompeii.Default
{
    /// <summary>
    /// Gets the solution file path from the current executable's file path assuming the standard development directory structure enforced by Visual Studio:
    ///     ../{Solution Directory}/{Project Directory}/bin/Debug/netcoreapp2.2/{executable file}
    /// </summary>
    [ServiceImplementationMarker]
    public class StandardSolutionDirectoryPathProvider : ISolutionDirectoryPathProvider,IServiceImplementation
    {
        private IExecutableFileDirectoryPathProvider ExecutableFileDirectoryPathProvider { get; }
        private ISolutionAndProjectFileSystemConventions SolutionAndProjectFileSystemConventions { get; }


        public StandardSolutionDirectoryPathProvider(
            IExecutableFileDirectoryPathProvider executableFileDirectoryPathProvider,
            ISolutionAndProjectFileSystemConventions solutionAndProjectFileSystemConventions)
        {
            this.ExecutableFileDirectoryPathProvider = executableFileDirectoryPathProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetSolutionDirectoryPath()
        {
            var executableFileDirectoryPath = this.ExecutableFileDirectoryPathProvider.GetExecutableFileDirectoryPath();

            var frameworkDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetFrameworkDirectoryPathFromExecutableDirectoryPath(executableFileDirectoryPath);
            var configurationDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetConfigurationDirectoryPathFromFrameworkDirectoryPath(frameworkDirectoryPath);
            var binariesDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetBinariesDirectoryPathFromConfigurationDirectoryPath(configurationDirectoryPath);
            var projectDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetProjectDirectoryPathFromBinariesDirectoryPath(binariesDirectoryPath);
            var solutionDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetSolutionDirectoryPathFromProjectDirectoryPath(projectDirectoryPath);
            return solutionDirectoryPath;
        }
    }
}
