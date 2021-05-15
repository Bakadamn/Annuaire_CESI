using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_CESI.SQLFactory.Factorys
{
    class AddFactory : RequeteFactory
    {
        private Contact _contact;
        public AddFactory(Contact contact)
        {
            _contact = contact;
        }
        public override Requete CreerRequete()
        {
            return new Requetes.Add(_contact);
        }
    }
}
