using System;

namespace Annuaire_CESI.SQLFactory.Factorys
{
    public class GetFactory : RequeteFactory
    {
        public GetFactory()
        {
        }
        public override Requete CreerRequete()
        {
            return new Requetes.Get();
        }
    }
}
