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
        public void ValidateString(string str)
        {
            if (str.Length > 100)
            {
                throw new ArgumentException("String is too long", "str");
            }

            if (str == "")
            {
                throw new ArgumentException("String is empty", "str");
            }
        }

        public void AddCustomer(string name, string address)
        {

            Customer c = new Customer();
            c.name = name;
            c.address = address;

            db.Customers.Add(c);

            db.SaveChanges();
        }

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

        public void DeleteCustomer(Customer c)
        {
            db.Customers.Remove(c);

            db.SaveChanges();
        }
    }
}
