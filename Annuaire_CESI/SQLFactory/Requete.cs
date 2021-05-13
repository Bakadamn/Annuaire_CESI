

using System.Collections.Generic;

namespace Annuaire_CESI.SQLFactory
{
    public abstract class Requete
    {
        public abstract TypeRequete TypeRequete { get; }
        public abstract List<Contact> ResultatGet { get; }
        public abstract string RetourSql { get; }

    }
}
