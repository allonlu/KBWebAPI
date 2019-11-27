using System;
namespace Comm100.Framework.Infrastructure
{
    public interface IMultiTenantTableResolver
    {
        string ResolveTableName(string commandText);
    }
}
