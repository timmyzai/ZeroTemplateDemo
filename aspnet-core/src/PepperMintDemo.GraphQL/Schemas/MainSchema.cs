using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using PepperMintDemo.Queries.Container;
using System;

namespace PepperMintDemo.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}