using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class Helper
    {

        public List<Customer> customerList;


        public List<Customer> UpdateCustomerList(List<Customer> customerList)
        {

            this.customerList = customerList;


            return this.customerList;
        }


    }
}
