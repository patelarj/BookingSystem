using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class Customer
    {
        private int id;
        private string name;
        private string address;
        private string email;
        private string phone;

        public Customer(int id, string name, string address, string email, string phone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
    }

    class CustMethod {

        public List<Customer> LoadCustomer(List<Customer> custlist)
        {

            custlist.Add(new Customer(0, "arjun", "20, brampton ON l5b6u7", "arjun@sheridan.com", "4168285555"));
            custlist.Add(new Customer(1, "ruchi", "26, Mississauag ON l5b6u7", "ruchi@sheridan.com", "416886555"));
            custlist.Add(new Customer(2, "roni", "88, Scarborough ON l5b6u7", "roni@sheridan.com", "4168288989"));
            custlist.Add(new Customer(3, "shila", "99, richmand ON l5b6u7", "shila@sheridan.com", "5168285855"));
            custlist.Add(new Customer(4, "deep", "66, brampton ON l5b6u7", "deep@sheridan.com", "4168285856"));
            return custlist;
            
        }






    }
}
