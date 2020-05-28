using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{
    class Controller
    {
        DataModel model = new DataModel();
        public void AddCustomer(string name, string address)
        {
            Customer c = new Customer();
            c.name = name;
            c.address = address;
            model.AddCustomer(c);
        }

        public void AddSupplier(string name, string address, string phone, string email)
        {
            Supplier s = new Supplier();
            s.name = name;
            s.address = address;
            s.phone = phone;
            s.email = email;
            model.AddSupplier(s);
        }

        public void AddBook(double money, DateTime date, int type, int customer, TimeSpan time)
        {
            TimeTable t = new TimeTable();
            t.customer_id = customer;
            t.date = date;
            t.haricut_id = type;
            t.price = money;
            t.time = time;

            model.AddBook(t);
        }

        public void AddWorker(string name, string id, string address)
        {
            Worker w = new Worker();
            w.name = name;
            w.identification = id;
            w.address = address;

            model.AddWorker(w);
        }

        public void AddProduct(string name, double price, string description, int supplier)
        {
            Product p = new Product();
            p.name = name;
            p.price = price;
            p.description = description;
            p.supplier_id = supplier;

            model.AddProduct(p);
        }

        public void AddWorkerHour(int worker, int hours, double salary, DateTime date)
        {
            WorkerHour w = new WorkerHour();
            w.worker_id = worker;
            w.hours = hours;
            w.salary = salary;
            w.date = date;

            model.AddWorkerHour(w);
        }

        public void EditBook(TimeTable t)
        {
            model.EditBook(t);
        }

        public void EditSupplier(Supplier s)
        {
            model.EditSupplier(s);
        }

        public void EditWorker(Worker w)
        {
            model.EditWorker(w);
        }

        public void EditCustomer(Customer c)
        {
            model.EditCustomer(c);
        }

        public void EditProduct(Product p)
        {
            model.EditProduct(p);
        }

        public void EditWorkerHour(WorkerHour w)
        {
            model.EditWorkerHour(w);
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


    }
}
