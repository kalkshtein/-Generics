using Практическое_занятие_по_теме_Generics.Items;

namespace Практическое_занятие_по_теме_Generics.Inventary
{
    public class CharacterInventory<T>
        where T : Item
    {
        private readonly List<T> _items = new();
        private readonly List<T> _equipedItems = new();

        /// <summary>
        /// Добавление предмета в инвентарь.
        /// </summary>
        /// <param name="item">Добавляемый предмет.</param>
        public void AddItem(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Удаление предмета из инвентаря.
        /// </summary>
        /// <param name="item">Удаляемый предмет.</param>
        public void RemoveItem(T item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                return;
            }
            throw new ArgumentException("Такого предмета нет!");
        }

        /// <summary>
        /// Вовращает кол-во предметов из инвентаря.
        /// </summary>
        public int GetItemCount()
        {
            return _items.Count;
        }

        /// <summary>
        /// Вовращает список предметов определенного типа.
        /// </summary>
        public List<U> GetItemsOfType<U>()
            where U : Item
        {
            var itemsOfTypeU = _items.OfType<U>();
            return itemsOfTypeU.ToList();
        }

        /// <summary>
        /// Надеть предмет.
        /// </summary>
        public void EquipItem(T item)
        {
            _equipedItems.Add(item);
        }

        /// <summary>
        /// Снять предмет.
        /// </summary>
        public void UnequipItem(T item)
        {
            _equipedItems.Remove(item);
        }

        /// <summary>
        /// Вовращает список предметов используемые персонажем.
        /// </summary>
        public List<T> GetEquippedItems()
        {
            return _equipedItems;
        }
    }
}
