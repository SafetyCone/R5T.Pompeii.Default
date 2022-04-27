using System;

using R5T.T0064;


namespace R5T.Pompeii.Default
{
    [ServiceImplementationMarker]
    public class DirectEntryPointProjectNameProvider : IEntryPointProjectNameProvider, IServiceImplementation
    {
        private string EntryPointProjectName { get; }


        public DirectEntryPointProjectNameProvider(
            [NotServiceComponent] string entryPointProjectName)
        {
            this.EntryPointProjectName = entryPointProjectName;
        }

        public string GetEntryPointProjectName()
        {
            return this.EntryPointProjectName;
        }
    }
}
