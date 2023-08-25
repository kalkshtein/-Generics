using Практическое_занятие_по_теме_Generics.Inventary;
using Практическое_занятие_по_теме_Generics.Items;
using Практическое_занятие_по_теме_Generics.ItemTypes;

public class Program
{
    public static void Main()
    {
        var characterInventory = new CharacterInventory<Item>(new Money(100));
        //Создадим предметы
        //Броня.
        var armorMasterHector = new Armor(509, 15, ArmorTypes.Body, "Armor of Master Hector", 1);
        var masterEshionArmor = new Armor(203, 13, ArmorTypes.Body, "Master Eshion's Armor", 1);
        var masterHectorGloves = new Armor(55, 5, ArmorTypes.Hands, "Master Hector's Gloves", 1);
        var masterEshionGloves = new Armor(55, 4, ArmorTypes.Hands, "Master Eshion's Gloves", 1);
        var masterHectorBoots = new Armor(59, 9, ArmorTypes.Legs, "Master Hector's Boots", 1);
        var masterEshionBoots = new Armor(59, 8, ArmorTypes.Legs, "Master Eshion's Boots", 1);

        //Оружие.
        var kingValor = new Weapon(909, 14, WeaponTypes.Sword, "King's Valor", 1);
        var kingValorControl = new Weapon(909, 14, WeaponTypes.Sword, "King's Valor", 3);
        var ancientStaffChaos = new Weapon(950, 15, WeaponTypes.Staff, "Ancient Staff of Chaos", 1);
        var fangDoom = new Weapon(1169, 14, WeaponTypes.Bow, "Fang of Doom", 1);

        //Зелья.
        var redPotion = new Potion("Heal", 3, PotionTypes.Heal, "Red potion", 1);
        var windPotion = new Potion("Buff", 15, PotionTypes.Buff, "Wind Potion", 1);
        var potionMagic = new Potion("Buff", 30, PotionTypes.Buff, "Potion of Magic", 1);

        //Добавление предметов.
        characterInventory.AddItem(armorMasterHector);
        characterInventory.AddItem(masterEshionArmor);
        characterInventory.AddItem(masterHectorGloves);
        characterInventory.AddItem(masterEshionGloves);
        characterInventory.AddItem(masterHectorBoots);
        characterInventory.AddItem(masterEshionBoots);

        characterInventory.AddItem(kingValor);
        characterInventory.AddItem(kingValorControl);
        characterInventory.AddItem(ancientStaffChaos);
        characterInventory.AddItem(fangDoom);

        characterInventory.AddItem(redPotion);
        characterInventory.AddItem(windPotion);

        //Экипировать предметы.
        characterInventory.EquipItem(armorMasterHector);
        characterInventory.EquipItem(masterHectorGloves);
        characterInventory.EquipItem(masterHectorBoots);
        characterInventory.EquipItem(masterEshionBoots);

        //Снять предметы.
        characterInventory.UnequipItem(masterEshionBoots);

        //Удаление предметов.
        characterInventory.RemoveItem(ancientStaffChaos);
        //characterInventory.RemoveItem(potionMagic);   //Удаление неиспользуемого предмета

        //Количество предметов.
        Console.WriteLine($"Количество предметов в инвентаре = {characterInventory.GetItemCount()}");

        //Используемые предметы.
        Console.WriteLine("\n" + "Сейчас надеты следующие предметы: ");
        foreach (var item in characterInventory.GetEquippedItems())
        {
            Console.WriteLine(item.Name);
        }

        //Предметы определенного типа
        Console.WriteLine("\n" + "Предметы типа Weapon: ");
        foreach (var item in characterInventory.GetItemsOfType<Weapon>())
        {
            Console.WriteLine($"{item.Name} в количестве {item.Count}");
        }

        Console.WriteLine("\n" + "Предметы типа Potion: ");
        foreach (var item in characterInventory.GetItemsOfType<Potion>())
        {
            Console.WriteLine($"{item.Name} в количестве {item.Count}");
        }

        Console.WriteLine("\n" + "Предметы типа Armor: ");
        foreach (var item in characterInventory.GetItemsOfType<Armor>())
        {
            Console.WriteLine($"{item.Name} в количестве {item.Count}");
        }

        Console.WriteLine("\n" + "Пришли к торговцу: ");

        Console.WriteLine($"\n Начальное кол-во монет в инвентаре: {characterInventory.GetNumberCoins()}");

        //Продадим нафармленый лишний шмот, дабы обогатиться
        characterInventory.SellItem(kingValorControl, 10000, "King's Valor", 2);

        Console.WriteLine($"\n Кол-во монет в инвентаре: {characterInventory.GetNumberCoins()}");

        //Купим то что действительно нужно
        characterInventory.BuyItem(fangDoom, 5000, "Fang of Doom", 2);
        characterInventory.BuyItem(redPotion, 100, "Red potion", 30);

        Console.WriteLine($"\n Кол-во монет в инвентаре: {characterInventory.GetNumberCoins()}");

        //Попробуем купить что то сверх бюджета
        characterInventory.BuyItem(new Weapon(5000, 300, WeaponTypes.Sword, "Big Sword of Barbarian", 1), 35000, "Big Sword of Barbarian", 1);

        Console.WriteLine($"\n Кол-во монет в инвентаре: {characterInventory.GetNumberCoins()}");

        //Попробуем продать что то чего нет
        characterInventory.SellItem(masterHectorGloves, 2000, "Master Hector's Gloves", 5);
        
        Console.WriteLine($"\n Кол-во монет в инвентаре: {characterInventory.GetNumberCoins()}");
    }
}