using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    public class CharInfoArrays
    {
        public List<Race> Races = new List<Race>();
        public List<Class> Classes = new List<Class>();


        public Race GetRace(int id)
        {
            foreach(Race race in Races)
            {
                if (race.Id == id)
                    return race;
            }
            return null;
        }

        public Class GetClass(int id)
        {
            foreach (Class cl in Classes)
            {
                if (cl.Id == id)
                {
                    return cl;
                }
            }
            return null;
        }

    }
}
