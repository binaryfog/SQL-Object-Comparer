using System;

namespace BinaryFog.SqlObjectComparer.DTO
{
    public class Environment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionStringTemplate { get; set; }
    }
}
