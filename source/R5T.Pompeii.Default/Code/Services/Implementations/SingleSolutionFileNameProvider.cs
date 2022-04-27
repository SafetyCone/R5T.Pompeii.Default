using System;
using System.IO;
using System.Linq;

using R5T.Angleterria;
using R5T.Lombardy;
using R5T.Magyar;using R5T.T0064;


namespace R5T.Pompeii.Default
{[ServiceImplementationMarker]
    public class SingleSolutionFileNameProvider : ISolutionFileNameProvider,IServiceImplementation
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public SingleSolutionFileNameProvider(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetSolutionFileName(string solutionDirectoryPath)
        {
            var searchPattern = $"{SearchPatternHelper.All}{PathHelper.FileExtensionSeparator}{VisualStudioSolutionFile.FileExtension}";

            var solutionFilePaths = Directory.EnumerateFiles(solutionDirectoryPath, searchPattern, SearchOption.TopDirectoryOnly);
            if(solutionFilePaths.Count() > 1)
            {
                throw new Exception($"{nameof(SingleSolutionFileNameProvider)} cannot have more than one solution file in the solution directory. Found: {solutionFilePaths.Count()}. Solution directory:\n{solutionDirectoryPath}");
            }

            if(solutionFilePaths.Count() < 1)
            {
                throw new Exception($"{nameof(SingleSolutionFileNameProvider)} found no solution files in directory:\n{solutionDirectoryPath}");
            }

            var solutionFilePath = solutionFilePaths.First();

            var solutionFileName = this.StringlyTypedPathOperator.GetFileName(solutionFilePath);
            return solutionFileName;
        }
    }
}
