using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BarberShop
{
    class Controller
    {
        DataModel model = new DataModel();
        Regex r = new Regex(@"^[A-Z0-9a-z. ,@]{1,50}$");
        public void ValidateCustomer(string name, string address)
        {
            if (!r.IsMatch(name))
                throw new System.ArgumentException("Name is too long or invalid");

            if (!r.IsMatch(address))
                throw new System.ArgumentException("Address is too long or invalid");
        }

        public void ValidateSupplier(string name, string address, string phone, string email)
        {
            if (!r.IsMatch(name))
                throw new System.ArgumentException("Name is too long or invalid");

            if (!r.IsMatch(address))
                throw new System.ArgumentException("Address is too long or invalid");

            if (!r.IsMatch(phone))
                throw new System.ArgumentException("Phone is too long or invalid");

            if (!r.IsMatch(email))
                throw new System.ArgumentException("Email is too long or invalid");
        }

        public void ValidateWorker(string name, string id, string address)
        {
            if (!r.IsMatch(name))
                throw new System.ArgumentException("Name is too long or invalid");

            if (!r.IsMatch(id))
                throw new System.ArgumentException("ID is too long or invalid");

            if (!r.IsMatch(address))
                throw new System.ArgumentException("Address is too long or invalid");
        }

        public void ValidateBook(double money)
        {
            if (money < 0 || money > double.MaxValue)
                throw new System.ArgumentException("Money number is too large or negetive");
        }

        public void ValidateProduct(string name, double price, string description)
        {
            if (!r.IsMatch(name))
                throw new System.ArgumentException("Name is too long or invalid");

            if (price < 0 || price > double.MaxValue)
                throw new System.ArgumentException("Price number is too large or negetive");

            if (!r.IsMatch(description))
                throw new System.ArgumentException("Description is too long or invalid");
        }

        public void ValidateWorkerHours(double hours, double salary, double total)
        {
            if (hours < 0 || hours > double.MaxValue)
                throw new System.ArgumentException("Salary number is too large or negetive");

            if (salary < 0 || salary > double.MaxValue)
                throw new System.ArgumentException("Salary number is too large or negetive");

            if (total < 0 || total > double.MaxValue)
                throw new System.ArgumentException("Total Salary number is too large or negetive");
        }

        public void ValidateSupplierOrder(int amount, double price)
        {
            if (amount < 0 || amount > int.MaxValue)
                throw new System.ArgumentException("Amount number is too large or negetive");

            if (price < 0 || price > double.MaxValue)
                throw new System.ArgumentException("Price number is too large or negetive");
        }

        public void ValidateOrder(double price)
        {
            if (price < 0 || price > double.MaxValue)
                throw new System.ArgumentException("Price number is too large or negetive");
        }

        public void ValidateAdditionalCost(double cost, string description)
        {
            if (cost < 0 || cost > double.MaxValue)
                throw new System.ArgumentException("Cost number is too large or negetive");

            if (!r.IsMatch(description))
                throw new System.ArgumentException("Description is too long or invalid");
        }

        public void ValidateHaircut(string name, double price)
        {
            if (price < 0 || price > double.MaxValue)
                throw new System.ArgumentException("Cost number is too large or negetive");

            if (!r.IsMatch(name))
                throw new System.ArgumentException("Name is too long or invalid");
        }

        public void AddCustomer(string name, string address)
        {
            ValidateCustomer(name, address);

            Customer c = new Customer();
            c.name = name;
            c.address = address;
            model.AddCustomer(c);
        }

        public void AddSupplier(string name, string address, string phone, string email)
        {
            ValidateSupplier(name, address, phone, email);

            Supplier s = new Supplier();
            s.name = name;
            s.address = address;
            s.phone = phone;
            s.email = email;
            model.AddSupplier(s);
        }

        public void AddBook(double money, DateTime date, int type, int customer, TimeSpan time, int worker)
        {           
            ValidateBook(money);

            TimeTable t = new TimeTable();
            t.customer_id = customer;
            t.date = date;
            t.haricut_id = type;
            t.price = money;
            t.time = time;
            t.worker_id = worker;

            model.AddBook(t);
        }

        public void AddWorker(string name, string id, string address)
        {
            ValidateWorker(name, id, address);

            Worker w = new Worker();
            w.name = name;
            w.identification = id;
            w.address = address;

            model.AddWorker(w);
        }

        public void AddProduct(string name, double price, string description, int supplier)
        {
            ValidateProduct(name, price, description);

            Product p = new Product();
            p.name = name;
            p.price = price;
            p.description = description;
            p.supplier_id = supplier;

            model.AddProduct(p);
        }

        public void AddWorkerHour(int worker, double hours, double salary, DateTime date, double total)
        {
            ValidateWorkerHours(hours, salary, total);

            WorkerHour w = new WorkerHour();
            w.worker_id = worker;
            w.hours = hours;
            w.salary = salary;
            w.date = date;
            w.total = total;

            model.AddWorkerHour(w);
        }

        public void AddSupplierOrder(int supplier, int product, DateTime date, int amount, double price)
        {           
            ValidateSupplierOrder(amount, price);

            SupplierOrder s = new SupplierOrder();
            s.supplier_id = supplier;
            s.product_id = product;
            s.date = date;
            s.amount = amount;
            s.price = price;

            model.AddSupplierOrder(s);
        }

        public void AddOrder(int customer, int product, DateTime date, double price, int worker)
        {
            ValidateOrder(price);

            Order o = new Order();
            o.customer_id = customer;
            o.product_id = product;
            o.worker_id = worker;
            o.date = date;
            o.price = price;

            model.AddOrder(o);
        }

        public void AddAdditionalCost(double cost, string description, DateTime date)
        {
            ValidateAdditionalCost(cost, description);

            AdditionalCost a = new AdditionalCost();
            a.cost = cost;
            a.description = description;
            a.date = date;

            model.AddAdditionalCost(a);
        }

        public void AddHaircut(string name, double price)
        {
            ValidateHaircut(name, price);

            Haircut h = new Haircut();
            h.name = name;
            h.price = price;

            model.AddHaircut(h);
        }

        public void EditBook(TimeTable t)
        {
            ValidateBook(t.price);

            model.EditBook(t);
        }

        public void EditSupplier(Supplier s)
        {
            ValidateSupplier(s.name, s.address, s.phone, s.email);

            model.EditSupplier(s);
        }

        public void EditWorker(Worker w)
        {
            ValidateWorker(w.name, w.identification, w.address);

            model.EditWorker(w);
        }

        public void EditCustomer(Customer c)
        {
            ValidateCustomer(c.name, c.address);

            model.EditCustomer(c);
        }

        public void EditProduct(Product p)
        {
            ValidateProduct(p.name, p.price, p.description);

            model.EditProduct(p);
        }

        public void EditWorkerHour(WorkerHour w)
        {
            ValidateWorkerHours(w.hours, w.salary, w.total);

            model.EditWorkerHour(w);
        }

        public void EditSupplierOrder(SupplierOrder s)
        {
            ValidateSupplierOrder(s.amount, s.price);

            model.EditSupplierOrder(s);
        }

        public void EditOrder(Order o)
        {
            ValidateOrder(o.price);

            model.EditOrder(o);
        }

        public void EditAdditionalCost(AdditionalCost a)
        {
            ValidateAdditionalCost(a.cost, a.description);

            model.EditAdditionalCost(a);
        }

        public void EditHaircut(Haircut h)
        {
            ValidateHaircut(h.name, h.price);

            model.EditHaircut(h);
        }

        public List<Customer> GetCustomers()
        {
            return model.GetCustomers();
        }

        public List<TimeTable> GetTimeTable()
        {
            return model.GetTimeTable();
        }

        public List<Haircut> GetHaircuts()
        {
            return model.GetHaircuts();
        }

        public List<SupplierOrder> GetSupplierOrders()
        {
            return model.GetSupplierOrders();
        }

        public List<Supplier> GetSuppliers()
        {
            return model.GetSuppliers();
        }

        public List<Worker> GetWorkers()
        {
            return model.GetWorkers();
        }

        public List<Product> GetProducts()
        {
            return model.GetProducts();
        }

        public List<WorkerHour> GetWorkerHours()
        {
            return model.GetWorkerHours();
        }

        public List<Order> GetOrders()
        {
            return model.GetOrders();
        }

        public List<AdditionalCost> GetAdditionalCosts()
        {
            return model.GetAdditionalCosts();
        }

        public void DeleteCustomer(Customer c)
        {
            model.DeleteCustomer(c);
        }

        public void DeleteTimeTable(TimeTable t)
        {
            model.DeleteTimeTable(t);
        }

        public void DeleteSupplier(Supplier s)
        {
            model.DeleteSupplier(s);
        }
        public void DeleteWorker(Worker w)
        {
            model.DeleteWorker(w);
        }

        public void DeleteProduct(Product p)
        {
            model.DeleteProduct(p);
        }

        public void DeleteWorkerHour(WorkerHour w)
        {
            model.DeleteWorkerHour(w);
        }

        public void DeleteSupplierOrder(SupplierOrder s)
        {
            model.DeleteSupplierOrder(s);
        }

        public void DeleteOrder(Order o)
        {
            model.DeleteOrder(o);
        }

        public void DeleteAdditionalCosts(AdditionalCost a)
        {
            model.DeleteAdditionalCost(a);
        }

        public void DeleteHaircut(Haircut h)
        {
            model.DeleteHaircut(h);
        }

    }
}
