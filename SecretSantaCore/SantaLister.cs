using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using SecretSantaCore.Models;

namespace SecretSantaCore
{
    public class SantaLister
    {
        List<Recipient> recipients = new List<Recipient>();
        List<Recipient> givers = new List<Recipient>();
        List<Recipient> elligible = new List<Recipient>();
        List<FamilyGroup> familyGroups = new List<FamilyGroup>();
        List<Recipient2Giver> matchedPairs = new List<Recipient2Giver>();
        Random rand = new Random();


        public SantaLister()
        {
            recipients.Add(new Recipient { Name = "Carole" , FamilyNumb = 1});
            recipients.Add(new Recipient { Name = "Debbie", FamilyNumb = 1 });
            recipients.Add(new Recipient { Name = "Dave", FamilyNumb = 2 });
            recipients.Add(new Recipient { Name = "Donna", FamilyNumb = 2 });
            recipients.Add(new Recipient { Name = "Zach", FamilyNumb = 3});
            recipients.Add(new Recipient { Name = "Sarah", FamilyNumb = 3 });
            recipients.Add(new Recipient { Name = "Bethany", FamilyNumb = 4 });
            recipients.Add(new Recipient { Name = "Carlos", FamilyNumb = 4 });
            recipients.Add(new Recipient { Name = "Steve", FamilyNumb = 5 });
            recipients.Add(new Recipient { Name = "Doreen", FamilyNumb = 5 });
            /*
            recipients.Add(new Recipient { Name = "Gabe", FamilyNumb = 6 });
            recipients.Add(new Recipient { Name = "Nate", FamilyNumb = 7 });
            recipients.Add(new Recipient { Name = "Amanda", FamilyNumb = 8 });
            */

            


        }

        public bool Run()
        {
            int rndNumb;
            while (matchedPairs.Count != recipients.Count)
            {
                OneMoreTime:
                givers.Clear();
                matchedPairs.Clear();
                foreach (var r in recipients)
                {
                    givers.Add(r);
                }
                foreach (var recipient in recipients)
                {
                    Console.WriteLine($"Recipient:{recipient.Name}");
                    elligible.Clear();
                    elligible = givers.Where(r => r.FamilyNumb != recipient.FamilyNumb).ToList();
                    if (elligible.Count > 0)
                    {
                        rndNumb = rand.Next(0, elligible.Count - 1);


                        if (elligible[rndNumb] != null && elligible.Count > 0)
                        {
                            matchedPairs.Add(new Recipient2Giver { Giver = elligible[rndNumb], Receiver = recipient });
                            givers.Remove(elligible[rndNumb]);
                        }
                        else if (elligible.Count > 0)
                        {
                            matchedPairs.Add(new Recipient2Giver { Giver = elligible.FirstOrDefault(), Receiver = recipient });

                        }
                        else
                        {
                            matchedPairs.Add(new Recipient2Giver { Giver = new Recipient(), Receiver = recipient });

                        }

                    }
                    if (matchedPairs.FirstOrDefault(m => m.Receiver.Name == "Doreen" && m.Giver.Name == "Carlos") != null)
                    {
                        goto OneMoreTime;
                    }

                }


            }

            foreach (var matchP in matchedPairs)
            {
                Console.WriteLine($"Giver:\t{matchP.Giver.Name}\tRecipient:\t{matchP.Receiver.Name}");
            }
            Console.WriteLine($"Total Matches:\t{matchedPairs.Count}");
            return true;
        }



    }
}
