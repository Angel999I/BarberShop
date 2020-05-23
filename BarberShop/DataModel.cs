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

        public void ValidateTimeTable(double money, DateTime date, Haircut type, Customer customer)
        {
            
        }

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


    }
}
