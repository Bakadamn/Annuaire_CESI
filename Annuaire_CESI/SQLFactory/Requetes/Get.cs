using System;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire_CESI.SQLFactory.Requetes
{
    public class Get : Requete
    {
        private readonly TypeRequete _typeRequete;
        private List<Contact> _resultatGet;
        private string _retourSql;
        public Get()
        {
            _typeRequete = TypeRequete.Get;
            using (ContexteSQL db = new ContexteSQL())
            {
               
                _resultatGet = db.Contact.ToList<Contact>();

                //mettre validation



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

        public override string RetourSql => throw new NotImplementedException();


    }
}
