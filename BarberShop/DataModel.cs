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

        public void ValidateTimeTable(double money, DateTime date, Haircut type, Customer customer)
        {
            
        }

        public void AddTimeTable(double money, DateTime date, int type, int customer)
        {
            TimeTable t = new TimeTable();
            t.customer_id = customer;
            t.date = date;
            t.haricut_id = type;
            t.price = money;

            db.TimeTables.Add(t);
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

        #endregion

        public void AddCustomer(Customer c)
        {
            db.Customers.Add(c);

            db.SaveChanges();
        }

        public void DeleteCustomer(Customer c)
        {
            db.Customers.Remove(c);

            db.SaveChanges();
        }


    }
}
