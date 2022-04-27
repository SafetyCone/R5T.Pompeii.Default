using System;

using R5T.T0064;


namespace R5T.Pompeii.Default
{
    [ServiceImplementationMarker]
    public class DirectBuildConfigurationNameProvider : IBuildConfigurationNameProvider, IServiceImplementation
    {
        private string BuildConfigurationName { get; }


        public DirectBuildConfigurationNameProvider(
            [NotServiceComponent] string buildConfigurationName)
        {
            this.BuildConfigurationName = buildConfigurationName;
        }

        public string GetBuildConfigurationName()
        {
            var output = this.BuildConfigurationName;
            return output;
        }
    }
}
