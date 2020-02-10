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
            var shoppingCart = new ShoppingCart(10);//shopping cart for user number 10
            var bd = new BillingDepartment(shoppingCart);
            var md = new MailingDepartment(shoppingCart);
            shoppingCart.Add(75458);
            shoppingCart.Add(54693);
            shoppingCart.Add(52145);
            shoppingCart.Submit();

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
