using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Annuaire_CESI
{
    static class AppelAPI
    {
        public static string path = "https://api.randomuser.me";

       
        public static async Task<Contact> AppelApiAsync()
        {
            Contact contactRetour;

            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.randomuser.me");
                var response = await client.GetAsync("https://api.randomuser.me");
                response.EnsureSuccessStatusCode();

                var resultat = await response.Content.ReadAsStringAsync();
                RootObject nouvContact = JsonConvert.DeserializeObject<RootObject>(resultat);

                contactRetour = new Contact
                {
                    Nom = nouvContact.results[0].name.last,
                    Prenom = nouvContact.results[0].name.first,
                    Telephone = nouvContact.results[0].phone,
                    DateEntree = nouvContact.results[0].registered.date,
                    Service = "Service"

                };

            }
            return contactRetour;
            
            
            
        }

        public class RootObject
        {
            public List<Result> results { get; set; }

        }

        public class Name
        {
            public string first { get; set; }
            public string last { get; set; }
        }
        public class Registered
        {
            public DateTime date { get; set; }
        }
        public class Result
        {
            public Name name { get; set; }
            public string phone { get; set; }
            public Registered registered { get; set; }
        }
    }
}
