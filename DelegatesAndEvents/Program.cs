using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace DelegatesAndEvents
{
    class Program
    {
        static Dictionary<string, string> listOfProductIDAndPrice;

        // Declare the delegate
        public delegate void PrintProductsDelegate();
        public delegate int PrintPriceDelegate();

        //Declare an event
        public static event PrintProductsDelegate DisplayProductsEvent;
        public static event PrintPriceDelegate DisplayFinalPriceEvent;
        static void Main(string[] args)
        {
            listOfProductIDAndPrice = new Dictionary<string, string>();

            DisplayProductsEvent += DisplayProductsEventHandler;

            DisplayFinalPriceEvent += DisplayFinalPriceEventHandler;

            // Event responsible to display the products
            DisplayProductsEvent();

            Console.WriteLine(Environment.NewLine);

            // Event responsible to display the final price
            int finalPrice = DisplayFinalPriceEvent();

            Console.WriteLine(Environment.NewLine + "Price of Products after  discount is : " + finalPrice);

            Console.ReadKey();
        }

        /// <summary>
        /// EventHandler sould responsible to display the final price
        /// </summary>
        /// <returns></returns>
        private static int DisplayFinalPriceEventHandler()
        {
            int productIds;

            string userInput = Console.ReadLine();

            bool isNumeric = int.TryParse(userInput, out productIds);

            while (!isNumeric)
            {
                Console.WriteLine("Please enter a valid product id.");

                userInput = Console.ReadLine();

                isNumeric = int.TryParse(userInput, out productIds);
            }

            var listOfInputs = userInput.Select(x => Convert.ToInt32(x.ToString())).ToList();

            int priceOfProducts = CalculatePriceForProducts(listOfProductIDAndPrice, listOfInputs);

            Console.WriteLine(Environment.NewLine + "Price of Products before discount is : " + priceOfProducts);

            int discountPercent = CalculateDiscount();

            return CalculatePriceOnDiscount(priceOfProducts, discountPercent);
        }
        
        /// <summary>
        /// Event handler soul responsible to display the list of products
        /// </summary>
        public static void DisplayProductsEventHandler()
        {
            Console.WriteLine("Please input the product id to add products in your cart.");

            Console.WriteLine(Environment.NewLine + "INSTRUCTIONS:");
            Console.WriteLine(Environment.NewLine + "1. To Select just one product, type it's product id (Example :Type 2 to select product with id 2)");
            Console.WriteLine(Environment.NewLine + "2. To Select more than one product, type their product id (Example : Type 25 for products 2 and 5)");

            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            string dataSourcePath = Path.Combine(projectPath, "ShopCart.xml");

            Console.WriteLine(Environment.NewLine + "LIST OF PRODUCTS AVAILABLE IN SHOP:");

            using (var xmlReader = new StreamReader(dataSourcePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                var parentNode = xmlDoc.SelectNodes("//Shop//Products//Product");

                foreach (XmlNode subNode in parentNode)
                {
                    string productID = subNode["ProductID"].InnerText;
                    string productName = subNode["ProductName"].InnerText;
                    string price = subNode["Price"].InnerText;

                    Console.WriteLine(Environment.NewLine + "PRODUCT ID : " + productID + " ,"
                        + " PRODUCT NAME : " + productName + " ," + " PRICE : " + price);

                    listOfProductIDAndPrice.Add(productID, price);
                }
            }

        }

        /// <summary>
        /// Method that applies discount on the price and returns the final price
        /// </summary>
        /// <param name="priceOfProducts"></param>
        /// <param name="discountPercent"></param>
        /// <returns></returns>
        private static int CalculatePriceOnDiscount(int priceOfProducts, int discountPercent)
        {
            int discountedPrice = priceOfProducts * discountPercent / 100;

            int finalPrice = priceOfProducts - discountedPrice;

            return finalPrice;
        }

        /// <summary>
        /// Method that calculates the price from list of products
        /// </summary>
        /// <param name="listOfProductIDAndPrice"></param>
        /// <param name="listOfInputs"></param>
        /// <returns></returns>
        private static int CalculatePriceForProducts(Dictionary<string, string> listOfProductIDAndPrice, List<int> listOfInputs)
        {
            int priceResult = 0;
            foreach (var item in listOfInputs)
            {
                string price;
                listOfProductIDAndPrice.TryGetValue(item.ToString(), out price);
                priceResult = priceResult + Int32.Parse(price);
            }

            return priceResult;
        }


        /// <summary>
        /// Displays the Products
        /// </summary>
        private static void DisplayProducts()
        {
            Console.WriteLine("Please Select the Product ID to buy (Say '2') :");
            Console.WriteLine();
            Console.WriteLine("Product ID 1 :Haldiram Namkeen");
            Console.WriteLine("Product ID 2: Mi Redmi 7A");
            Console.WriteLine("Product ID 3: Godrej Washing Machine");
            Console.WriteLine("Product ID 4: Samsung Android TV");
            Console.WriteLine("Product ID 5: JBL Bluetooth speaker");
            Console.WriteLine("Product ID 6: Levis Jeans");
            Console.WriteLine("Product ID 7: Cadbury Jeans");
            Console.ReadLine();
        }

        /// <summary>
        /// The method is soul responsible to Calculate discount
        /// </summary>
        private static int CalculateDiscount()
        {
            int discount = 0;
            string festivalName = GetFestivalByDate();

            switch (festivalName)
            {
                case "Ramadan":
                    discount = 15;
                    Console.WriteLine(Environment.NewLine + "Ramadan festive season is ON. You are eligible for :" + discount + "%" + " discount.");
                    break;
                case "Christmas":
                    discount = 20;
                    Console.WriteLine(Environment.NewLine + "Christmas festive season is ON. You are eligible for :" + discount + "%" + " discount.");
                    break;
                case "New Year":
                    discount = 15;
                    Console.WriteLine(Environment.NewLine + "New year festive season is ON. You are eligible for :" + discount + "%" + " discount.");
                    break;
                case "Holi":
                    discount = 10;
                    Console.WriteLine(Environment.NewLine + "Holi festive season is ON. You are eligible for :" + discount + "%" + " discount.");
                    break;
                case "Diwali":
                    discount = 20;
                    Console.WriteLine(Environment.NewLine + "Diwali festive season is ON. You are eligible for :" + discount + "%" + " discount.");
                    break;
                default:
                    discount = 5;
                    Console.WriteLine(Environment.NewLine + "You are eligible for a default discount of " + discount + "%");
                    break;
            }

            return discount;
        }

        /// <summary>
        /// The method responsble to return the festival name by date
        /// </summary>
        /// <returns></returns>
        private static string GetFestivalByDate()
        {
            if (DateTime.Today >= new DateTime(2020, 4, 23) && DateTime.Today <= new DateTime(2020, 5, 23))
            {
                return "Ramadan";
            }

            if (DateTime.Today >= new DateTime(2020, 12, 10) && DateTime.Today <= new DateTime(2020, 12, 28))
            {
                return "Christmas";
            }

            if (DateTime.Today >= new DateTime(2020, 1, 1) && DateTime.Today <= new DateTime(2020, 1, 28))
            {
                return "New Year";
            }
            if (DateTime.Today >= new DateTime(2020, 11, 1) && DateTime.Today <= new DateTime(2020, 11, 28))
            {
                return "Diwali";
            }

            if (DateTime.Today >= new DateTime(2020, 03, 1) && DateTime.Today <= new DateTime(2020, 03, 20))
            {
                return "Holi";
            }
            return string.Empty;
        }
    }
}
