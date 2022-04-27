using System;

using R5T.Angleterria;

using R5T.T0064;


namespace R5T.Pompeii.Default
{
    [ServiceImplementationMarker]
    public class NetCoreAppV2_2EntryPointProjectFrameworkNameProvider : DirectEntryPointProjectFrameworkNameProvider,
        IEntryPointProjectFrameworkNameProvider,
        IServiceImplementation
    {
        public NetCoreAppV2_2EntryPointProjectFrameworkNameProvider()
            : base(NetCoreAppV2_2.FrameworkName)
        {
        }
    }
}
