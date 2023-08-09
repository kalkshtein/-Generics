using Практическое_занятие_по_теме_Generics.ItemTypes;

namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Armor : Item
    {
        /// <summary>
        /// Защита.
        /// </summary>
        public int Defence { get; private set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Тип брони.
        /// </summary>
        public ArmorTypes Type { get; private set; }

        public Armor(int defence, int weight, ArmorTypes type, string name)
            : base(name)
        {
            this.Defence = defence;
            this.Weight = weight;
            this.Type = type;
        }
    }
}
