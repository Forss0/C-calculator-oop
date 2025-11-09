using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availability_of_operators.Work
{
    namespace Models
    {
        public class CreditCard
        {
            public double Money { get; set; }
            public int CVC { get; private set; }

            public CreditCard(double money, int cvc)
            {
                Money = money;
                CVC = cvc;
            }

            public static CreditCard operator +(CreditCard card, double amount)
            {
                card.Money += amount;
                return card;
            }

            public static CreditCard operator -(CreditCard card, double amount)
            {
                card.Money -= amount;
                return card;
            }

            // == та != порівнюють CVC код
            public static bool operator ==(CreditCard a, CreditCard b)
            {
                return a.CVC == b.CVC;
            }

            public static bool operator !=(CreditCard a, CreditCard b)
            {
                return a.CVC != b.CVC;
            }

            public static bool operator <(CreditCard a, CreditCard b)
            {
                return a.Money < b.Money;
            }

            public static bool operator >(CreditCard a, CreditCard b)
            {
                return a.Money > b.Money;
            }
        }
    }

}
