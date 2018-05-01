using BinaryFog.SqlObjectComparer.DTO;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryFog.SqlObjectComparer.Repository
{
    public class Repository : IRepository
    {
        public string DbLocation { get; set; } = @"./App_Data/MyData.db";

        public void AddEnvironment(DTO.Environment env)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                // Get customer collection
                var customers = db.GetCollection<DTO.Environment>("environments");

                // Insert new customer document (Id will be auto-incremented)
                customers.Insert(env);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);
            }
        }

        public void DeleteEnvironment(int envId)
        {
            throw new NotImplementedException();
        }

        public void EditEnvironment(DTO.Environment env)
        {
            throw new NotImplementedException();
        }

        public IList<DTO.Environment> ListEnvironments()
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                // Get customer collection
                var customers = db.GetCollection<DTO.Environment>("environments");

                // Use Linq to query documents
                return customers.FindAll() as IList<DTO.Environment>;
            }
        }
    }
}
