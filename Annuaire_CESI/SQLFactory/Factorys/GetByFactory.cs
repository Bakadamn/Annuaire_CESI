using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_CESI.SQLFactory.Factorys
{
    class GetByFactory :RequeteFactory
    {
        private TypeFiltre _typeFiltre;
        private string _filtre;
        public GetByFactory(TypeFiltre typeFiltre, string filtre)
        {
            _typeFiltre = typeFiltre;
            _filtre = filtre;
        }
        public override Requete CreerRequete()
        {
            return new Requetes.GetBy(_typeFiltre, _filtre);
        }
    }
}
