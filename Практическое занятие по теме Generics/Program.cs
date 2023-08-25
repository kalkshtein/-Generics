using System;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using Практическое_занятие_по_теме_Generics.Inventary;
using Практическое_занятие_по_теме_Generics.Items;
using Практическое_занятие_по_теме_Generics.ItemTypes;

public class Program
{
    public static void Main()
    {
        var characterInventory = new CharacterInventory<Item>();
        //Создадим предметы
        //Броня.
        var armorMasterHector = new Armor(509, 15, ArmorTypes.Body ,"Armor of Master Hector");
        var masterEshionArmor = new Armor(203, 13, ArmorTypes.Body ,"Master Eshion's Armor");
        var masterHectorGloves = new Armor(55, 5, ArmorTypes.Hands, "Master Hector's Gloves");
        var masterEshionGloves = new Armor(55, 4, ArmorTypes.Hands, "Master Eshion's Gloves");
        var masterHectorBoots = new Armor(59, 9, ArmorTypes.Legs, "Master Hector's Boots");
        var masterEshionBoots = new Armor(59, 8, ArmorTypes.Legs, "Master Eshion's Boots");

        //Оружие.
        var kingValor = new Weapon(909, 14, WeaponTypes.Sword, "King's Valor");
        var ancientStaffChaos = new Weapon(950, 15, WeaponTypes.Staff, "Ancient Staff of Chaos");
        var fangDoom = new Weapon(1169, 14, WeaponTypes.Bow, "Fang of Doom");

        //Зелья.
        var redPotion = new Potion("Heal", 3, PotionTypes.Heal, "Red potion");
        var windPotion = new Potion("Buff", 15, PotionTypes.Buff, "Wind Potion");
        var potionMagic = new Potion("Buff", 30, PotionTypes.Buff, "Potion of Magic");

        //Добавление предметов.
        characterInventory.AddItem(armorMasterHector);
        characterInventory.AddItem(masterEshionArmor);
        characterInventory.AddItem(masterHectorGloves);
        characterInventory.AddItem(masterEshionGloves);
        characterInventory.AddItem(masterHectorBoots);
        characterInventory.AddItem(masterEshionBoots);

        characterInventory.AddItem(kingValor);
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
        Console.WriteLine("Количество предметов в инвентаре = " + characterInventory.GetItemCount());

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
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("\n" + "Предметы типа Potion: ");
        foreach (var item in characterInventory.GetItemsOfType<Potion>())
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("\n" + "Предметы типа Armor: ");
        foreach (var item in characterInventory.GetItemsOfType<Armor>())
        {
            Console.WriteLine(item.Name);
        }
    }
}