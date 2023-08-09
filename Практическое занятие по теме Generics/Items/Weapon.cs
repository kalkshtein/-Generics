using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Weapon : Item
    {
        /// <summary>
        /// Урон.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Скорость атаки.
        /// </summary>
        public int AtkSpeed { get; private set; }

        public Weapon(int damage, int atkSpeed ,string name, string type, bool used)
            : base(name, type, used)
        {
            this.Damage = damage;
            this.AtkSpeed = atkSpeed;
        }
    }
}
