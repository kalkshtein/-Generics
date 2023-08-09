using System;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using Практическое_занятие_по_теме_Generics.Inventary;
using Практическое_занятие_по_теме_Generics.Items;

public class Program
{
    public static void Main()
    {
        var characterInventory = new CharacterInventory<Item>();
        //Создадим предметы
        //Броня.
        var ArmorMasterHector = new Armor(509, 15, "Armor of Master Hector", "Body", true);
        var MasterEshionArmor = new Armor(203, 13, "Master Eshion's Armor", "Body", false);
        var MasterHectorGloves = new Armor(55, 5, "Master Hector's Gloves", "Hands", true);
        var MasterEshionGloves = new Armor(55, 4, "Master Eshion's Gloves", "Hands", false);
        var MasterHectorBoots = new Armor(59, 9, "Master Hector's Boots", "Legs", true);
        var MasterEshionBoots = new Armor(59, 8, "Master Eshion's Boots", "Legs", false);

        //Оружие.
        var KingValor = new Weapon(909, 14, "King's Valor", "Two-Handed Sword", true);
        var AncientStaffChaos = new Weapon(950, 15, "Ancient Staff of Chaos", "Two-Handed Staff", false);
        var FangDoom = new Weapon(1169, 14, "Fang of Doom", "Longbow", false);

        //Зелья.
        var RedPotion = new Potion("Heal", 3, "Red potion", "Heal potion", false);
        var WindPotion = new Potion("Buff", 15, "Wind Potion", "Buff potion", false);
        var PotionMagic = new Potion("Buff", 30, "Potion of Magic", "Buff potion", false);

        //Добавление предметов.
        characterInventory.AddItem(ArmorMasterHector);
        characterInventory.AddItem(MasterEshionArmor);
        characterInventory.AddItem(MasterHectorGloves);
        characterInventory.AddItem(MasterEshionGloves);
        characterInventory.AddItem(MasterHectorBoots);
        characterInventory.AddItem(MasterEshionBoots);

        characterInventory.AddItem(KingValor);
        characterInventory.AddItem(AncientStaffChaos);
        characterInventory.AddItem(FangDoom);

        characterInventory.AddItem(RedPotion);
        characterInventory.AddItem(WindPotion);

        //Удаление предметов.
        characterInventory.RemoveItem(AncientStaffChaos);
        characterInventory.RemoveItem(WindPotion);

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