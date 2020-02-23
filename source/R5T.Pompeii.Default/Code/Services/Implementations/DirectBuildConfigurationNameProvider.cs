using System;


namespace R5T.Pompeii.Default
{
    public class DirectBuildConfigurationNameProvider : IBuildConfigurationNameProvider
    {
        private string BuildConfigurationName { get; }


        public DirectBuildConfigurationNameProvider(string buildConfigurationName)
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
