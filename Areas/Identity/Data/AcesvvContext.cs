using Acesvv.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Acesvv.Data;

public class AcesvvContext : IdentityDbContext<UsuarioModel>
{
    public AcesvvContext(DbContextOptions<AcesvvContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }



}
