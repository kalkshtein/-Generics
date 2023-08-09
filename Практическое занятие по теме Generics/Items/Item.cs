using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическое_занятие_по_теме_Generics.Items
{
    public class Item
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Тип предмета.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Используется персонажем.
        /// </summary>
        public bool Used { get; private set; }

        public Item(string name, string type, bool used) 
        {
            this.Name = name;
            this.Type = type;
            this.Used = used;
        }
    }
}

