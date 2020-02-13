using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your User ID ?");

            int userID = Convert.ToInt32(Console.ReadLine());

            var shoppingCart = new ShoppingCart(userID);

            DisplayProducts();

            string userInput = Console.ReadLine();

            shoppingCart.Add(Convert.ToInt32(userInput));

            int discount = CalculateDiscount(userInput);

            CalculatePrice();
            
            var bd = new BillingDepartment(shoppingCart);

            var md = new MailingDepartment(shoppingCart);
                     
            shoppingCart.Submit();

        }

        /// <summary>
        /// Calculates the Price of the product
        /// </summary>
        private static int CalculatePrice()
        {
            return 20;
        }

        /// <summary>
        /// The method is soul responsible to Calculate discount
        /// </summary>
        private static int CalculateDiscount(string userInput)
        {
            int discount = 0;

            string festivalName = GetFestivalByDate();

            switch (userInput)
            {
                case "1":
                    discount = festivalName == "Diwali" ? 20 : 5;                    
                    break;
                case "5":
                    discount = festivalName == "Diwali" ? 20 : 5;
                    break;
                default:
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

            if (DateTime.Today == new DateTime(2020, 12, 25))
            {
                return "Christmas";
            }

            if (DateTime.Today == new DateTime(2020, 1, 1))
            {
                return "New Year";
            }
            if (DateTime.Today == new DateTime(2020, 11, 14))
            {
                return "Diwali";
            }
            return string.Empty;
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
            Console.ReadLine();
        }
    }

    public class ShoppingCart
    {
        private int _userId;
        private List<int> _orders = new List<int>();
        public delegate void OrderSubmitted(OrderDetails orderDetails);
        public event OrderSubmitted OrderSubmittedEvent;


        public ShoppingCart(int userId)
        {
            _userId = userId;
        }
        public void Add(int itemNumber)
        {
            _orders.Add(itemNumber);
        }

        public void Submit()
        {
            OrderSubmittedEvent.Invoke(new OrderDetails { ItemCodes = _orders, UserId = _userId });

            Console.WriteLine("The Price of the Product is : " 20); 
        }

    }

    public class OrderDetails
    {
        public List<int> ItemCodes { get; set; }
        public int UserId { get; set; }
    }

    public class BillingDepartment
    {
        public BillingDepartment(ShoppingCart sc)
        {
            sc.OrderSubmittedEvent += OrderSubmittedHandler;
        }

        public void OrderSubmittedHandler(OrderDetails orderDetails)
        {
            foreach (var item in orderDetails.ItemCodes)
            {
                Console.WriteLine("Billing user " + orderDetails.UserId + " for the order " + item.ToString());
            }
        }

    }

    public class MailingDepartment
    {
        public MailingDepartment(ShoppingCart sc)
        {
            sc.OrderSubmittedEvent += OrderSubmittedHandler;
        }
        public void OrderSubmittedHandler(OrderDetails orderDetails)
        {
            foreach (var item in orderDetails.ItemCodes)
            {
                Console.WriteLine("Mailing user " + orderDetails.UserId + " the order " + item.ToString());
            }
        }

    }
}
