using System;
using System.Collections.Generic;
using System.Text;
using SecretSantaCore.Models;

namespace SecretSantaCore.Models
{
    public class FamilyGroup
    {
        public Recipient familyHead = new Recipient();
        public List<Recipient> familyMembers = new List<Recipient>();

    }
}
