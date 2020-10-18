using System.Reflection;
using GigPlanner.GraphQL.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace GigPlanner.GraphQL
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}