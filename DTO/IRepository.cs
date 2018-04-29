using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryFog.SqlObjectComparer.DTO
{
    public interface IRepository
    {
        IList<Environment> ListEnvironments();
        void AddEnvironment(Environment env);
        void DeleteEnvironment(int envId);
        void EditEnvironment(Environment env);


    }
}
