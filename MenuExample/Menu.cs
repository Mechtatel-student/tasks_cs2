using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuExample
{
    class Menu
    {
        public struct ItemAction
        {
            public string Text;
            public Action MyAction;
        }
        public struct ItemIntCode
        {
            public int Code;
            public string Text;
        }

        private struct Item
        {
            public int? Code;
            public string Text;
            public Action MyAction;
        }

        private Item[] items;

        private static Item TestConvert(ItemAction itemActionToConvert)
        {
            Item result = new Item();
            result.Code = null;
            result.Text = itemActionToConvert.Text;
            result.MyAction = itemActionToConvert.MyAction;
            return result;
        }

        public Menu(ItemAction[] itemsWithActions)
        {
            this.items = Array.ConvertAll(
                itemsWithActions, 
                new Converter<ItemAction,Item>(
                    TestConvert
                //(ia)=>{ return new Item { Code = null, Text = ia.Text, MyAction = ia.MyAction }; }
                )
            );
        }

        public Menu(ItemIntCode[] itemsWithIntCodes)
        {
            this.items = Array.ConvertAll(
                itemsWithIntCodes,
                new Converter<ItemIntCode, Item>(
                    (ic) => { return new Item { Code = ic.Code, Text = ic.Text, MyAction = null }; }
                )
            );
        }

        private bool ValidateInput(int choice, int maxValue)
        { 
            bool result = false;
            bool areCodesAvailable = Array.TrueForAll(this.items, (item) => { return item.Code.HasValue; });
            if(areCodesAvailable)
            {
                result = Array.FindIndex(this.items,
                            (item) => { return choice == item.Code.Value; }) > -1;
            }
            else
            {
                result = choice > 0 && choice <= maxValue;
            }
            return result;
        }

        private void PrintMenu()
        {
            bool areCodesAvailable = Array.TrueForAll(this.items, (item) => { return item.Code.HasValue; });
            for (int index = 0; index < items.Length; index++)
            {
                Console.WriteLine("[{0}] {1}", 
                    areCodesAvailable ? items[index].Code : index + 1,
                    items[index].Text);
            }
        }

        private int GetCorrectUserInput()
        {
            string input;
            int number;
            do
            {
                Console.WriteLine("Enter your choice: ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out number) && ValidateInput(number, items.Length)));
            return number;
        }

        public void Show()
        {
            Action currentAction = null;
            do
            {
                PrintMenu();
                currentAction = items[GetCorrectUserInput()- 1].MyAction;
                if (currentAction != null)
                {
                    currentAction();
                }
            }
            while ( currentAction != null );
        }

        public int GetChoice()
        {
            PrintMenu();
            return GetCorrectUserInput();
        }
    }
}
