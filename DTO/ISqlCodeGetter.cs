using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryFog.SqlObjectComparer.DTO
{
    public interface ISqlCodeGetter
    {
        string GetObjectSqlCode(string connString, string dbName, string objName);
    }
}
