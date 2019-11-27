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
            model.ValidateString(name);
            model.ValidateString(address);

            model.AddCustomer(name, address);
        }

        public List<Customer> GetCustomers()
        {
            return model.GetCustomers();
        }
    }
}
