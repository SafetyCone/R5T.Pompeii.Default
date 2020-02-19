using System;


namespace R5T.Pompeii.Default
{
    /// <summary>
    /// Provides a solution file name provided at construction.
    /// </summary>
    public class DirectSolutionFileNameProvider : ISolutionFileNameProvider
    {
        private string SolutionFileName { get; }

        
        public DirectSolutionFileNameProvider(string solutionFileName)
        {
            this.SolutionFileName = solutionFileName;
        }

        public string GetSolutionFileName(string solutionDirectoryPath)
        {
            return this.SolutionFileName;
        }
    }
}
