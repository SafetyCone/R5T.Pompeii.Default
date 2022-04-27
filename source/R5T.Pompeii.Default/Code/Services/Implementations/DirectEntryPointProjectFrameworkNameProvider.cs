using System;

using R5T.T0064;


namespace R5T.Pompeii.Default
{
    [ServiceImplementationMarker]
    public class DirectEntryPointProjectFrameworkNameProvider : IEntryPointProjectFrameworkNameProvider, IServiceImplementation
    {
        private string EntryPointProjectFrameworkName { get; }


        public DirectEntryPointProjectFrameworkNameProvider(
            [NotServiceComponent] string entryPointProjectFrameworkName)
        {
            this.EntryPointProjectFrameworkName = entryPointProjectFrameworkName;
        }

        public string GetEntryPointProjectFrameworkName()
        {
            var output = this.EntryPointProjectFrameworkName;
            return output;
        }
    }
}
