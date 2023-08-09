using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Potion : Item
    {
        /// <summary>
        /// Эффект.
        /// </summary>
        public string Effect { get; private set; }

        /// <summary>
        /// Продолжительность действия.
        /// </summary>
        public int Duration { get; private set; }

        public Potion(string effect, int duration, string name, string type, bool used)
            : base(name, type, used)
        {
            this.Effect = effect;
            this.Duration = duration;
        }
    }
}
