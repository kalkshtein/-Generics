using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практическое_занятие_по_теме_Generics.ItemTypes;

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

        /// <summary>
        /// Тип оружия.
        /// </summary>
        public WeaponTypes Type { get; private set; }

        public Weapon(int damage, int atkSpeed, WeaponTypes type, string name)
            : base(name)
        {
            this.Damage = damage;
            this.AtkSpeed = atkSpeed;
            this.Type = type;
        }
    }
}
