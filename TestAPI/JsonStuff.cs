using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    public class JsonStuff
    {
        public static string LINK = @"https://eu.api.battle.net/wow/character/";
        public static string HEADER = "?fields=guild&locale=en_GB&apikey=";

        private static string CreateRequestUrl(string realm, string characterName)
        {
            return LINK + realm + "/" + characterName + HEADER + Key.KEY;
        }

        private static string GetRacesRequestString()
        {
            return "https://eu.api.battle.net/wow/data/character/races?locale=en_GB&apikey=" + Key.KEY;
        }

        private static string GetClassesRequestString()
        {
            return "https://eu.api.battle.net/wow/data/character/classes?locale=en_GB&apikey=" + Key.KEY;
        }

        private static string CreateRequest(string requestString)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestString);

            string result = "";

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            } catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }

            return result;
        }

        public static int Test(string realm, string characterName)
        {
            string requestString = CreateRequestUrl(realm, characterName);
            string request = CreateRequest(requestString);

            var json = JsonConvert.DeserializeObject<Character>(request);

            return json.Level;
        }

        public static Character GetCharacter(string realm, string name)
        {
            string requestString = CreateRequestUrl(realm, name);
            string request = CreateRequest(requestString);

            var charJson = JsonConvert.DeserializeObject<Character>(request);

            return charJson;
        }

        public static Race GetRace(int id)
        {
            string requestString = GetRacesRequestString();
            string request = CreateRequest(requestString);

            var json = JsonConvert.DeserializeObject<CharInfoArrays>(request);

            return json.GetRace(id);
        }

        public static Class GetClass(int id)
        {
            string requestString = GetClassesRequestString();
            string request = CreateRequest(requestString);

            var json = JsonConvert.DeserializeObject<CharInfoArrays>(request);

            return json.GetClass(id);
        }



    }
}
