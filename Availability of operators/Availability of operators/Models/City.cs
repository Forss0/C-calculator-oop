using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availability_of_operators.Work
{
    namespace Models
    {
        public class City
        {
            public int Population { get; set; }

            public City(int population)
            {
                Population = population;
            }

            public static City operator +(City c, int amount)
            {
                c.Population += amount;
                return c;
            }

            public static City operator -(City c, int amount)
            {
                c.Population -= amount;
                return c;
            }

            public static bool operator ==(City a, City b)
            {
                return a.Population == b.Population;
            }

            public static bool operator !=(City a, City b)
            {
                return a.Population != b.Population;
            }

            public static bool operator <(City a, City b)
            {
                return a.Population < b.Population;
            }

            public static bool operator >(City a, City b)
            {
                return a.Population > b.Population;
            }
        }
    }

}