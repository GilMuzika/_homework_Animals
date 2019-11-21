using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._11._19_homework_dogs_and_horses
{
    class ComboItem
    {
        public Object Item { get; set; } = default;
        public Type ItemType { get; set; } = default;
        public string ItemTypeName { get; set; } = default;

        public ComboItem(Object item, Type itemType)
        {
            Item = item; ItemType = itemType;
        }

        public override string ToString()
        {
            return ItemType.Name;
        }
    }
}
