namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Item
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; private set; }

        public Item(string name) 
        {
            this.Name = name;
        }
    }
}

