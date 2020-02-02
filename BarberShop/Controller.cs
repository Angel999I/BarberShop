﻿using System;
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

        public void DeleteCustomer(Customer c)
        {
            model.DeleteCustomer(c);
        }


    }
}
