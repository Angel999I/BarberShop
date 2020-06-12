using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{

    class DataModel
    {
        DatabaseEntities db = new DatabaseEntities();

        public void EditBook(TimeTable t)
        {
            var update = db.TimeTables.Where(o => o.Id == t.Id).FirstOrDefault();
            if (update != null)
            {
                update.price = t.price;
                update.date = t.date;
                update.haricut_id = t.haricut_id;
                update.customer_id = t.customer_id;
                update.time = t.time;
                update.Customer = t.Customer;
                update.Haircut = t.Haircut;
                update.worker_id = t.worker_id;
                update.Worker = t.Worker;
            }


            db.SaveChanges();
        }

        public void EditSupplier(Supplier s)
        {
            var update = db.Suppliers.Where(o => o.Id == s.Id).FirstOrDefault();
            if (update != null)
            {
                update.name = s.name;
                update.address = s.address;
                update.phone = s.phone;
                update.email = s.email;
            }

            db.SaveChanges();
        }

        public void EditWorker(Worker w)
        {
            var update = db.Workers.Where(o => o.Id == w.Id).FirstOrDefault();
            if (update != null)
            {
                update.name = w.name;
                update.identification = w.identification;
                update.address = w.address;
            }

            db.SaveChanges();
        }

        public void EditCustomer(Customer c)
        {
            var update = db.Customers.Where(o => o.Id == c.Id).FirstOrDefault();
            if (update != null)
            {
                update.name = c.name;
                update.address = c.address;
            }

            db.SaveChanges();
        }

        public void EditProduct(Product p)
        {
            var update = db.Products.Where(o => o.Id == p.Id).FirstOrDefault();
            if (update != null)
            {
                update.supplier_id = p.supplier_id;
                update.Supplier = p.Supplier;
                update.price = p.price;
                update.name = p.name;
                update.description = p.description;
            }

            db.SaveChanges();
        }

        public void EditWorkerHour(WorkerHour w)
        {
            var update = db.WorkerHours.Where(o => o.Id == w.Id).FirstOrDefault();
            if (update != null)
            {
                update.worker_id = w.worker_id;
                update.Worker = w.Worker;
                update.hours = w.hours;
                update.salary = w.salary;
                update.date = w.date;
                update.total = w.total;
            }

            db.SaveChanges();
        }

        public void EditSupplierOrder(SupplierOrder s)
        {
            var update = db.SupplierOrders.Where(o => o.Id == s.Id).FirstOrDefault();
            if (update != null)
            {
                update.supplier_id = s.supplier_id;
                update.product_id = s.product_id;
                update.date = s.date;
                update.amount = s.amount;
                update.price = s.price;
                update.Supplier = s.Supplier;
                update.Product = s.Product;
            }

            db.SaveChanges();
        }

        public void EditOrder(Order r)
        {
            var update = db.Orders.Where(o => o.Id == r.Id).FirstOrDefault();
            if (update != null)
            {
                update.customer_id = r.customer_id;
                update.product_id = r.product_id;
                update.worker_id = r.worker_id;
                update.Customer = r.Customer;
                update.Product = r.Product;
                update.Worker = r.Worker;
                update.date = r.date;
                update.price = r.price;
            }

            db.SaveChanges();
        }

        public void EditAdditionalCost(AdditionalCost a)
        {
            var update = db.AdditionalCosts.Where(o => o.Id == a.Id).FirstOrDefault();
            if (update != null)
            {
                update.cost = a.cost;
                update.description = a.description;
                update.date = a.date;               
            }

            db.SaveChanges();
        }

        public void EditHaircut(Haircut h)
        {
            var update = db.Haircuts.Where(o => o.Id == h.Id).FirstOrDefault();
            if (update != null)
            {
                update.name = h.name;
                update.price = h.price;
            }

            db.SaveChanges();
        }

        public void AddBook(TimeTable t)
        {
            db.TimeTables.Add(t);

            db.SaveChanges();
        }

        public void AddCustomer(Customer c)
        {
            db.Customers.Add(c);

            db.SaveChanges();
        }

        public void AddSupplier(Supplier s)
        {
            db.Suppliers.Add(s);

            db.SaveChanges();
        }

        public void AddWorker(Worker w)
        {
            db.Workers.Add(w);

            db.SaveChanges();
        }

        public void AddProduct(Product p)
        {
            db.Products.Add(p);

            db.SaveChanges();
        }

        public void AddWorkerHour(WorkerHour w)
        {
            db.WorkerHours.Add(w);

            db.SaveChanges();
        }

        public void AddSupplierOrder(SupplierOrder s)
        {
            db.SupplierOrders.Add(s);

            db.SaveChanges();
        }

        public void AddOrder(Order o)
        {
            db.Orders.Add(o);

            db.SaveChanges();
        }

        public void AddAdditionalCost(AdditionalCost a)
        {
            db.AdditionalCosts.Add(a);

            db.SaveChanges();
        }

        public void AddHaircut(Haircut h)
        {
            db.Haircuts.Add(h);

            db.SaveChanges();
        }

        #region Get DB Tables as list

        public List<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        public List<TimeTable> GetTimeTable()
        {
            return db.TimeTables.ToList();           
        }

        public List<Haircut> GetHaircuts()
        {
            return db.Haircuts.ToList();
        }

        public List<Supplier> GetSuppliers()
        {
            return db.Suppliers.ToList();
        }

        public List<SupplierOrder> GetSupplierOrders()
        {
            return db.SupplierOrders.ToList();
        }

        public List<Worker> GetWorkers()
        {
            return db.Workers.ToList();
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public List<WorkerHour> GetWorkerHours()
        {
            return db.WorkerHours.ToList();
        }

        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }

        public List<AdditionalCost> GetAdditionalCosts()
        {
            return db.AdditionalCosts.ToList();
        }

        #endregion

        public void DeleteCustomer(Customer c)
        {
            db.Customers.Remove(c);

            db.SaveChanges();
        }

        public void DeleteTimeTable(TimeTable t)
        {
            db.TimeTables.Remove(t);

            db.SaveChanges();
        }

        public void DeleteSupplier(Supplier s)
        {
            db.Suppliers.Remove(s);

            db.SaveChanges();
        }

        public void DeleteWorker(Worker w)
        {
            db.Workers.Remove(w);

            db.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            db.Products.Remove(p);

            db.SaveChanges();
        }

        public void DeleteWorkerHour(WorkerHour w)
        {
            db.WorkerHours.Remove(w);

            db.SaveChanges();
        }

        public void DeleteSupplierOrder(SupplierOrder s)
        {
            db.SupplierOrders.Remove(s);

            db.SaveChanges();
        }

        public void DeleteOrder(Order o)
        {
            db.Orders.Remove(o);

            db.SaveChanges();
        }

        public void DeleteAdditionalCost(AdditionalCost a)
        {
            db.AdditionalCosts.Remove(a);

            db.SaveChanges();
        }

        public void DeleteHaircut(Haircut h)
        {
            db.Haircuts.Remove(h);

            db.SaveChanges();
        }
    }
}
