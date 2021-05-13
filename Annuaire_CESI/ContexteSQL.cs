using System.Data.Common;
using System.Data.Entity;


namespace Annuaire_CESI
{
    class ContexteSQL : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
    }
}
