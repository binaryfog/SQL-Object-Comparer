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
                // Get environments collection
                var envs = db.GetCollection<DTO.Environment>("environments");

                // Insert new environment document (Id will be auto-incremented)
                envs.Insert(env);

                // Index document using a document property
                envs.EnsureIndex(x => x.Name);
            }
        }

        public void DeleteEnvironment(int envId)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                // Get environments collection
                var envs = db.GetCollection<DTO.Environment>("environments");

               

            }
        }

        public void EditEnvironment(DTO.Environment env)
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                // Get environments collection
                var envs = db.GetCollection<DTO.Environment>("environments");

                envs.Update(env);

            }
        }

        public IList<DTO.Environment> ListEnvironments()
        {
            using (var db = new LiteDatabase(DbLocation))
            {
                // Get environments collection
                var envs = db.GetCollection<DTO.Environment>("environments");


                List<DTO.Environment> result = new List<DTO.Environment>();
                result.AddRange(envs.FindAll());
                return result;
            }
        }
    }
}
