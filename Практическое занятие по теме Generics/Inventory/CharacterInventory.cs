using System.Data;
using Практическое_занятие_по_теме_Generics.Items;

namespace Практическое_занятие_по_теме_Generics.Inventary
{
    public class CharacterInventory<T>
        where T : Item
    {
        private List<T> Items = new List<T>();
        private List<T> EquipedItems = new List<T>();

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
            if (Items.Contains(item))
            {
                Items.Remove(item);
                return;
            }
            throw new ArgumentException("Такого предмета нет!");
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
        /// Надеть предмет.
        /// </summary>
        public void EquipItem(T item)
        {
            EquipedItems.Add(item);
        }

        /// <summary>
        /// Снять предмет.
        /// </summary>
        public void UnequipItem(T item)
        {
            EquipedItems.Remove(item);
        }

        /// <summary>
        /// Вовращает список предметов используемые персонажем.
        /// </summary>
        public List<T> GetEquippedItems()
        {
            return EquipedItems.Select(x => x).ToList();
        }
    }
}
