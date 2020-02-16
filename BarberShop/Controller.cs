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
        public void AddCustomer(Customer c)
        {
            model.AddCustomer(c);
        }

        public void AddSupplier(Supplier s)
        {
            model.AddSupplier(s);
        }

        public void AddTimeTable(double money, DateTime date, int type, int customer)
        {
            model.AddTimeTable(money, date, type, customer);
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

        public List<Supplier> GetSuppliers()
        {
            return model.GetSuppliers();
        }

        public void DeleteCustomer(Customer c)
        {
            model.DeleteCustomer(c);
        }


    }
}
