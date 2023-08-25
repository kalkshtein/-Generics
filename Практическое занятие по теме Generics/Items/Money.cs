namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Money
    {
        /// <summary>
        /// Количество монет.
        /// </summary>
        public int Amount { get; set; } = 0;

        public Money(int amount)
        {
            this.Amount = amount;
        }


    }
}
