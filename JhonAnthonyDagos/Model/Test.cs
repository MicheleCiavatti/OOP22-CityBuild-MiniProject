using ShopModel;
using System;
using MyNameSpace;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Test Shop");
            Controller controller = new Controller();
            Shop shop = new Shop(controller);

            System.Console.WriteLine("Player Resources: ");
            controller.printResource();

            System.Console.WriteLine(shop.generateResource());
            System.Console.WriteLine("1. Ok");
            System.Console.WriteLine("2. No");

            string val;
            val = System.Console.ReadLine();
            int x  = Convert.ToInt32(val);
            switch(x)
            {
                case 1:
                    controller = shop.getResource();
                    System.Console.WriteLine("Player Resource Updated..");
                    controller.printResource();
                    break;
                case 2:
                    System.Console.WriteLine("Closing shop...");
                    break;
            }

        }
    }
}

