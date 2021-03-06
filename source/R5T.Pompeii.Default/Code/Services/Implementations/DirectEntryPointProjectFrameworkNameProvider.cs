﻿using System;


namespace R5T.Pompeii.Default
{
    public class DirectEntryPointProjectFrameworkNameProvider : IEntryPointProjectFrameworkNameProvider
    {
        private string EntryPointProjectFrameworkName { get; }


        public DirectEntryPointProjectFrameworkNameProvider(string entryPointProjectFrameworkName)
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
