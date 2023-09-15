using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infra
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

    }
}
