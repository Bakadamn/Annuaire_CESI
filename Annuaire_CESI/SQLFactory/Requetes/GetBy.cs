using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
namespace Annuaire_CESI.SQLFactory.Requetes
{
    class GetBy : Requete
    {
        private TypeRequete _typeRequete;
        private List<Contact> _resultatGet;

        public GetBy(TypeFiltre typeFiltre, string filtre)
        {
            _typeRequete = TypeRequete.GetBy;


            using (ContexteSQL db = new ContexteSQL())
            {

                if(typeFiltre==TypeFiltre.Nom)
                _resultatGet = db.Contact.Where(x => x.Nom.Contains(filtre)).ToList<Contact>();

                else if(typeFiltre == TypeFiltre.Prenom)
                _resultatGet = db.Contact.Where(x => x.Prenom.Contains(filtre)).ToList<Contact>();

                else if (typeFiltre == TypeFiltre.Service)
                _resultatGet = db.Contact.Where(x => x.Service.Contains(filtre)).ToList<Contact>();


            }
        }
        public override TypeRequete TypeRequete
        {
            get { return _typeRequete; }
        }

        public override List<Contact> ResultatGet
        {
            get { return _resultatGet; }
        }

    }
}
