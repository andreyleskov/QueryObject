using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cat
    {
        public int Id { get; set; }
        public decimal CuteFactor { get; set; }
        public string Name { get; set; }

        public int OwnerId { get; set; }

        public string AskForMilk()
        {
            return CuteFactor > 0 ? "Meow" : "Shhh";
        }
    }
}
