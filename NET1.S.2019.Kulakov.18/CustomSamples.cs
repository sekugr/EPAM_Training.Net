using SampleSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using SampleQueries;

namespace SampleQueries//QuerySamples
{
    [Title("LINQ Query Samples")]
    [Prefix("Linq")]
    class CustomSamples : SampleHarness
    {
        [Category("Tasks")]
        [Title("Task 01")]
        [Description("Получить список всех клиентов, сумма всех заказов которых превосходит некоторую заданную величину.")]
        public void LinqQuery01()
        {
            var customers = new LinqSamples().GetCustomerList();
            decimal rangesum = 5000;
            var sel_customer = customers.Where(x => x.Orders.Sum(s => s.Total) < rangesum);


            foreach (var item in sel_customer)
            {
                Console.WriteLine($"Company: \"{item.CompanyName.ToUpper()}\", Orders Sum = {item.Orders.Sum(s => s.Total)}");
                ObjectDumper.Write(item, 1);


            }
            ObjectDumper.Write(sel_customer, 1);
        }

        [Category("Tasks")]
        [Title("Task 02.1")]
        [Description("Для каждого клиента получить список поставщиков, находящихся в той же стране и том же городе. Задание выполнить, как используя операцию группировки, так и без нее.")]
        public void LinqQuery02_1()
        {
            var ls = new LinqSamples();
            var customers = ls.GetCustomerList();
            var supplier = ls.GetSupplierList();

            var result = from s in supplier
                         from c in customers
                         where s.Country == c.Country
                         where s.City == c.City
                         select new { Custumer = c, Suplier = s };
            ObjectDumper.Write(result, 1);
        }

        [Category("Tasks")]
        [Title("Task 02.2")]
        [Description("Для каждого клиента получить список поставщиков, находящихся в той же стране и том же городе. Задание выполнить, как используя операцию группировки, так и без нее.")]
        public void LinqQuery02_2()
        {
            var ls = new LinqSamples();
            var customers = ls.GetCustomerList();
            var supplier = ls.GetSupplierList();

            var sup_country = from s in supplier
                              from c in customers
                              where s.Country == c.Country
                              where s.City == c.City
                              select new { Custumer = c, Suplier = s };
            var result = from s in sup_country
                         group s by s.Suplier.City into suplierGroup
                         select new { Customer = suplierGroup.Key, Suplier = suplierGroup };
            ObjectDumper.Write(result, 2);
        }

        [Category("Tasks")]
        [Title("Task 03")]
        [Description("Получить список тех клиентов, заказы которых превосходят по сумме заданную величину.")]
        public void LinqQuery03()
        {
            int valSum = 300;
            var customers = new LinqSamples().GetCustomerList();
            var result = customers.Where(c => c.Orders.All(o => o.Total > valSum)).Where(o => o.Orders.Count() > 0);
            ObjectDumper.Write(result, 5);
        }

        [Category("Tasks")]
        [Title("Task 04")]
        [Description("Получить список всех клиентов в отсортированном виде по году, месяцу певого заказа клиента, оборотам клиента (от максимального к минимальному) и имени клиента.")]
        public void LinqQuery04()
        {
            var customers = new LinqSamples().GetCustomerList();
            var result = customers.Where(c => c.Orders.Count() > 0).OrderBy(y => y.Orders.First().OrderDate.Year).ThenBy(m => m.Orders.First().OrderDate.Month).ThenByDescending(s => s.Orders.Sum(cust => cust.Total)).ThenBy(name => name.CompanyName);
            var result2 = from c in customers
                          where c.Orders.Count() > 0
                          orderby c.Orders.First().OrderDate.Year, c.Orders.First().OrderDate.Month, c.Orders.Sum(s => s.Total) descending, c.CompanyName
                          select c;

            foreach (var item in result)
            {
                Console.WriteLine(item.Orders.First().OrderDate.Year + " month " + item.Orders.First().OrderDate.Month + " sum " + item.Orders.Sum(s => s.Total) + " Name " + item.CompanyName);
            }
        }

        [Category("Tasks")]
        [Title("Task 05")]
        [Description("Получить список тех клиентов, у которых указан нецифровой почтовый код или не заполнен регион или в телефоне не указан код оператора(что равнозначно «нет круглых скобок в начале»).")]
        public void LinqQuery05()
        {
            var customers = new LinqSamples().GetCustomerList();
            var result = from c in customers
                         where (!string.IsNullOrEmpty(c.PostalCode) && (char.IsLetter(c.PostalCode.ToString()[0]))) || string.IsNullOrEmpty(c.Region) || (!c.Phone.Contains("("))
                         select c;
            ObjectDumper.Write(result, 0);
        }

        [Category("Tasks")]
        [Title("Task 06")]
        [Description("Сгруппировать все продукты по категориям, внутри – по наличию на складе, внутри последней группы - по стоимости.")]
        public void LinqQuery06()
        {
            var products = new LinqSamples().GetProductList();
            var result = products.GroupBy(p => p.Category).Select(CategoryGroup => new { Category = CategoryGroup.Key, CatGroup = CategoryGroup.GroupBy(s => s.UnitsInStock).Select(StockGroup => new { CountStock = StockGroup.Key, CountStockGroup = StockGroup.GroupBy(cost => cost.UnitPrice).Select(CostGroup => new { Cost = CostGroup.Key, CostGroup }) }) });
            ObjectDumper.Write(result, 5);
            var result2 = from p in products
                          group p by p.Category into CategoryGroup
                          select new
                          {
                              Category = CategoryGroup.Key,
                              CategoryGroup =
                          from s in CategoryGroup
                          group s by s.UnitsInStock into CountStockGroup
                          select new
                          {
                              CountStock = CountStockGroup.Key,
                              CountStockGroup =
                          from c in CountStockGroup
                          group c by c.UnitPrice into CostGroup
                          select new { Cost = CostGroup.Key, CostGroup }
                          }
                          };

            ObjectDumper.Write(result2, 5);
        }

        [Category("Tasks")]
        [Title("Task 07")]
        [Description("Сгруппировать все товары по группам «дешевые», «средняя цена», «дорогие», определив границы каждой группы произвольным образом.")]
        public void LinqQuery07()
        {
            decimal lowPrice = 30;
            decimal highPrice = 80;
            var products = new LinqSamples().GetProductList();
            var GroupProd = products.GroupBy(
                p =>
                {
                    if (p.UnitPrice > highPrice) return "High";
                    if (p.UnitPrice > lowPrice) return "Middle";
                    return "Low";
                });
            ObjectDumper.Write(GroupProd, 5);
        }
        [Category("Tasks")]
        [Title("Task 08")]
        [Description("Рассчитать среднюю сумму заказа по всем клиентам из данного города и среднее количество заказов, приходящееся на клиента из каждого города.")]
        public void LinqQuery08()
        {
            var customers = new LinqSamples().GetCustomerList();
            var result =
                from c in customers
                from order in c.Orders
                group new { c.CustomerID, order } by c.City into CityGroup
                select new
                {
                    City = CityGroup.Key,
                    AverageOrderPrice = CityGroup.Average(cg => cg.order.Total),
                    AverageOrdersCountCustomers = (double)CityGroup.Count() / CityGroup.Select(cg => cg.CustomerID).Distinct().Count()
                };
            ObjectDumper.Write(result, 5);
        }

        [Category("Tasks")]
        [Title("Task 09")]
        [Description("Для каждого клиента сумма заказов в месяц, сгруппированная по годам и месяцам.")]
        public void LinqQuery09()
        {
            var customers = new LinqSamples().GetCustomerList();
            var res = from c in customers
                      group c by c.CustomerID into custID
                      select new
                      {
                          Customer = custID.Key,
                          custID =
                      from y in custID
                      from o in y.Orders
                      group o by o.OrderDate.Year into oYear
                      select new
                      {
                          Year = oYear.Key,
                          oYear =
                      from m in oYear
                      group m by m.OrderDate.Month into oMonth
                      select new { Month = oMonth.Key, Sum = oMonth.Sum(order => order.Total) }
                      }
                      };

            ObjectDumper.Write(res, 5);
        }
    }
}