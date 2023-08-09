using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Armor : Item
    {
        /// <summary>
        /// Урон.
        /// </summary>
        public int Defence { get; private set; }

        /// <summary>
        /// Скорость атаки.
        /// </summary>
        public int Weight { get; private set; }

        public Armor(int defence, int weight,string name, string type, bool used)
            : base(name, type, used)
        {
            this.Defence = defence;
            this.Weight = weight;
        }
    }
}
