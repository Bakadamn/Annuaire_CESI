using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_CESI.SQLFactory.Factorys
{
    class DeleteFactory : RequeteFactory
    {
        private int _aSupprimer;
        public DeleteFactory(int aSupprimer)
        {
            _aSupprimer = aSupprimer;
        }
        public override Requete CreerRequete()
        {
            return new Requetes.Delete(_aSupprimer);
        }
    }
}
