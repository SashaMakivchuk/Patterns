using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    //Дано клас Товар(назва, ціна) та Замовлення - клас що містить список пар
    //    товар - кількість.Розробити систему продаж.Система повинна вміти 
    //    продавати 1 товар а також замовлення.Система повинна вміти приймати 
    //        оплату кредитною карткою (вивід в консоль повідомлення про суму оплати)
    //    та оплату в кредит(вивід в консоль графіку щомісячних оплат) % та
    //    термін кредиту вказується додатково.Передбачити можливість розширення
    //    функціоналу системи в майбутньому, наприклад, акційне замовлення:
    //    список товарів із вказаною знижкою у % та
    //    нових способів оплати, наприклад, оплата частинами без %.
    interface IProduct //interface for every prod that is made/going to be made
    {
        string Name { get; }
        double Price { get; }
    }

    class Phone : IProduct
    {
        public string Name { get; } = "Phone";
        public double Price { get; } = 100;
    }

    class Laptop : IProduct
    {
        public string Name { get; } = "Laptop";
        public double Price { get; } = 300;
    }
    interface IPay //interface for payment methods
    {
        void Pay(double amount);
    }
    class CardPayment : IPay
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Card: {amount}$");
        }
    }

    class Loan : IPay //class for loan payment
    {
        private int _months;
        private double _Rate;

        public Loan(int months, double Rate) 
        {
            _months = months;
            _Rate = Rate; //how much to pay per month
        }

        public void Pay(double amount)
        {
            double monthlyPayment = (amount * (1 + _Rate / 100)) / _months; //calculate payment per month
            Console.WriteLine($"Credit for: {amount}$. Month pay: {monthlyPayment}$ for {_months} month(s).");
        }
    }
    abstract class ProductFactory //abstract makes it easier to makenew prod
    {
        public abstract IProduct CreateProduct();
    }

    class PhoneFactory : ProductFactory
    {
        public override IProduct CreateProduct()
        {
            return new Phone();
        }
    }
    class LaptopFactory : ProductFactory
    {
        public override IProduct CreateProduct()
        {
            return new Laptop();
        }
    }

    abstract class PaymentFactory //same as abst for prod but for pauments
    {
        public abstract IPay CreatePayment();
    }

    class CardFactory : PaymentFactory
    {
        public override IPay CreatePayment()
        {
            return new CardPayment();
        }
    }

    class LoanFactory : PaymentFactory
    {
        private int _months;
        private double _Rate;

        public LoanFactory(int months, double Rate)
        {
            _months = months;
            _Rate = Rate;
        }

        public override IPay CreatePayment()
        {
            return new Loan(_months, _Rate);
        }
    }

    class SaleSystem //class for making sales
    {
        public void SellProduct(IProduct product, int quantity, IPay payment)
        {
            double total = product.Price * quantity; //total price
            payment.Pay(total);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory phoneFactory = new PhoneFactory();
            ProductFactory laptopFactory = new LaptopFactory();

            IProduct phone = phoneFactory.CreateProduct();
            IProduct laptop = laptopFactory.CreateProduct();

            PaymentFactory cardFactory = new CardFactory();
            PaymentFactory loanFactory = new LoanFactory(12, 10); 

            IPay CardPayment = cardFactory.CreatePayment();
            IPay loanPayment = loanFactory.CreatePayment();

            SaleSystem saleSystem = new SaleSystem();

            saleSystem.SellProduct(phone, 1, CardPayment);

            saleSystem.SellProduct(laptop, 1, loanPayment);
            Console.ReadLine();
        }
    }
}
