using System;

using R5T.T0064;


namespace R5T.Pompeii.Default
{
    /// <summary>
    /// Provides a solution file name provided at construction.
    /// </summary>
    [ServiceImplementationMarker]
    public class DirectSolutionFileNameProvider : ISolutionFileNameProvider, IServiceImplementation
    {
        private string SolutionFileName { get; }

        
        public DirectSolutionFileNameProvider(
            [NotServiceComponent] string solutionFileName)
        {
            this.SolutionFileName = solutionFileName;
        }

        public string GetSolutionFileName(string solutionDirectoryPath)
        {
            return this.SolutionFileName;
        }
    }
}
