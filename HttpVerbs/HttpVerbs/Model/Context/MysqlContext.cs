using Microsoft.EntityFrameworkCore;

namespace HttpVerbs.Model.Context
{
    public class MysqlContext : DbContext
    {
        public MysqlContext()
        {

        }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) //O parametro options será passado para o base
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
