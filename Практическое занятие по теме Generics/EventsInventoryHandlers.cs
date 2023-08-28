using Практическое_занятие_по_теме_Generics.Inventary;
using Практическое_занятие_по_теме_Generics.Items;

namespace Практическое_занятие_по_теме_Generics
{
    public class EventsInventoryHandlers<T>
        where T : Item
    {
        private readonly CharacterInventory<T> _characterInventory;
        /// <summary>
        /// Обработчик события успешной покупки
        /// </summary>
        public void OnBuyEventMessage(Item item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Товар {itemName} в количестве {quantity} успешно куплен");
        }

        /// <summary>
        /// Обработчик события неуспешной покупки
        /// </summary>
        public void OnNotBuyEventMessage(Item item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Невозможно купить товар {itemName} в количестве {quantity}, " +
                $"недостаточно денег в количестве {price * quantity - _characterInventory.GetNumberCoins()}");
        }

        /// <summary>
        /// Обработчик события успешной продажи
        /// </summary>
        public void OnSellEventMessage(Item item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Товар {itemName} в количестве {quantity} успешно продан");
        }

        /// <summary>
        /// Обработчик события неуспешной продажи
        /// </summary>
        public void OnNotsellEventMessage(Item item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Недостаточно товара {itemName} в инвентаре");
        }

        /// <summary>
        /// Обработчик сообщающий о балансе монет в инвентаре
        /// </summary>
        public void BalanceMessage(Item item, int price, string itemName, int quantity)
        {
            Console.WriteLine($"Кол-во монет в инвентаре: {_characterInventory.GetNumberCoins()}");
        }

        public EventsInventoryHandlers(CharacterInventory<T> characterInventory)
        {
            this._characterInventory = characterInventory;
        }
    }
}
