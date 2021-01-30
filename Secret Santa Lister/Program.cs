using System;
using SecretSantaCore;
using System.Collections.Generic;
using System.Linq;

namespace Secret_Santa_Lister
{
    class Program
    {
        static SantaLister santa = new SantaLister();
        static void Main(string[] args)
        {
            List<int> sup = new List<int>();
            List<int> doh = new List<int>();

            for (int i = 1; i <= 20; i++)
            {
                sup.Add(i);
            }

            

            foreach (var i in sup)
            {
                
            }


            santa.Run();
        }
    }
}
