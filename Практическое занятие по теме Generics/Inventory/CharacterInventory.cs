using System.Security.Cryptography;
using Практическое_занятие_по_теме_Generics.Items;

namespace Практическое_занятие_по_теме_Generics.Inventary
{
    public class CharacterInventory<T>
        where T : Item
    {
        private readonly List<T> _items = new();
        private readonly List<T> _equipedItems = new();

        /// <summary>
        /// Количество монет в инвентаре.
        /// </summary>
        private Money Money { get; set; }

        public CharacterInventory(Money money) 
        {
            if (money == null)
            {
                throw new ArgumentNullException(nameof(money));
            }

            this.Money = new Money(money.Amount);
        }

        public int GetNumberCoins()
        {
            return this.Money.Amount;
        }

        /// <summary>
        /// Делегат для проверки возможности покупки товара и списания денег из инвентаря.
        /// </summary>
        private delegate void BuyDelegate(T item, int price, string itemName, int quantity);

        /// <summary>
        /// Событие которое будет возникать при покупке товара.
        /// </summary>
        private event BuyDelegate? BuyEvent;

        /// <summary>
        /// Событие которое будет возникать при невозможности покупки товара.
        /// </summary>
        private event BuyDelegate? NotBuyEvent;

        private bool CanBuy(T item, int price, string itemName, int quantity)
        {
            return Money.Amount >= price * quantity;
        }

        private void OnBuyEvent(T item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Товар {itemName} в количестве {quantity} успешно куплен");
        }

        private void OnNotBuyEvent(T item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Невозможно купить товар {itemName} в количестве {quantity}, " +
                $"недостаточно денег в количестве { price * quantity - Money.Amount}");
        }

        public void BuyItem(T item, int price, string itemName, int quantity)
        {
            var buyDelegate = CanBuy;
            var canBuy = buyDelegate(item, price, itemName, quantity);
            if (BuyEvent == null) BuyEvent += OnBuyEvent;
            if (NotBuyEvent == null) NotBuyEvent += OnNotBuyEvent;

            var totalCost = price * quantity;

            if (canBuy)
            {
                Money.Amount -= totalCost;

                AddItem(item);
                BuyEvent?.Invoke(item, price, itemName, quantity);
            }
            if(!canBuy)
            {
                NotBuyEvent?.Invoke(item, price, itemName, quantity);
            }
        }

        /// <summary>
        /// Делегат для проверки возможности продажи товара и зачисления денег в инвентарь.
        /// </summary>
        private delegate void SellDelegate(T item, int price, string itemName, int quantity);

        /// <summary>
        /// Событие которое будет возникать при продаже товара.
        /// </summary>
        private event SellDelegate? SellEvent;

        private bool CanSell(T item, int price, string itemName, int quantity)
        {
            return item.Count >= quantity;
        }

        private void OnSellEvent(T item, int price, string itemName, int quantity)
        {
            var removedItemCount = 0;
            for (var i = _items.Count - 1; i >= 0; i--)
            {
                if (_items[i].Equals(item))
                {
                    _items.RemoveAt(i);
                    removedItemCount++;
                    if (removedItemCount >= quantity)
                    {
                        break;
                    }
                }
            }
            Money.Amount += price * quantity;
            Console.WriteLine($"Товар {itemName} в количестве {quantity} успешно продан");
        }

        public void SellItem(T item, int price, string itemName, int quantity)
        {
            var sellDelegate = CanSell;
            var canSell = sellDelegate(item, price, itemName, quantity);
            SellEvent += OnSellEvent;

            if (!canSell)
            {
                Console.WriteLine($"Недостаточно товара {itemName} в инвентаре");
                return;
            }

            SellEvent?.Invoke(item, price, itemName, quantity);
        }

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
            var count = _items.Sum(x => x.Count);
            return count;
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
