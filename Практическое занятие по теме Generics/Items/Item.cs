namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Item
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Количество предмета в инвентаре.
        /// </summary>
        public int Count { get; private set; }

        public Item(string name, int count)
        {
            this.Name = name;
            this.Count += count;
        }
    }
}

