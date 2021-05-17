using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_CESI.SQLFactory.Factorys
{
    class ModifierFactory : RequeteFactory
    {
        private Contact _contact;
        private int _idModif;
        public ModifierFactory(Contact contact, int idModif)
        {
            _contact = contact;
            _idModif = idModif;
        }
        public override Requete CreerRequete()
        {
            return new Requetes.Modifier(_contact, _idModif);
        }
    }
}
