using System;
namespace KB.Infrastructure
{
    public interface ITableIsolationResolver
    {
        string ReplaceTableName(string commandText);
    }
}
