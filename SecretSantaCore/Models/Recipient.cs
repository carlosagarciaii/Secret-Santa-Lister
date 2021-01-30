using System;
using System.Collections.Generic;
using System.Text;



namespace SecretSantaCore.Models
{
    public class Recipient
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Items { get; set; }
        public int FamilyNumb { get; set; }

    }
}
