using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Практическое_занятие_по_теме_Generics.Items;

namespace Практическое_занятие_по_теме_Generics.Inventary
{
    public class CharacterInventory<T>
        where T : Item
    {
        private List<T> Items = new List<T>();

        /// <summary>
        /// Добавление предмета в инвентарь.
        /// </summary>
        /// <param name="item">Добавляемый предмет.</param>
        public void AddItem(T item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Удаление предмета из инвентаря.
        /// </summary>
        /// <param name="item">Удаляемый предмет.</param>
        public void RemoveItem(T item)
        {
            try
            {
                Items.Remove(item);
            }
            catch
            {
                Console.WriteLine("Такого предмета нет!");
            }
        }

        /// <summary>
        /// Вовращает кол-во предметов из инвентаря.
        /// </summary>
        public int GetItemCount()
        {
            return Items.Count;
        }

        /// <summary>
        /// Вовращает список предметов определенного типа.
        /// </summary>
        public List<U> GetItemsOfType<U>()
            where U : Item
        {
            var itemsOfTypeU = Items.OfType<U>();
            return itemsOfTypeU.ToList();
        }

        /// <summary>
        /// Вовращает список предметов используемые персонажем.
        /// </summary>
        public List<T> GetEquippedItems()
        {
            return Items.Where(x => x.Used).ToList();
        }
    }
}
