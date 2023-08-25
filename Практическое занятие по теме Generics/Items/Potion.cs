using Практическое_занятие_по_теме_Generics.ItemTypes;

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

        /// <summary>
        /// Тип зелья.
        /// </summary>
        public PotionTypes Type { get; private set; }

        public Potion(string effect, int duration, PotionTypes type, string name, int count)
            : base(name, count)
        {
            this.Effect = effect;
            this.Duration = duration;
            this.Type = type;
        }
    }
}
