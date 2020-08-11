using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Midterm
{
    class LoginDetails
    {
        private int id;
        private string username;
        private string password;
        private int supuer;

        public LoginDetails(int id, string username, string password, int supuer)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Supuer = supuer;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Supuer { get => supuer; set => supuer = value; }
    }

    class LoginMethods
    {

        public List<LoginDetails> LodLogin(List<LoginDetails> loglist) {

            loglist.Add(new LoginDetails(1, "arjun", "arjun12345", 1));
            loglist.Add(new LoginDetails(2, "ruchi", "ruchi12345", 0));
            loglist.Add(new LoginDetails(3, "rob", "rob12345", 0));

            return loglist;
        }
        
        public Dictionary<string, string> LogDictionary(Dictionary<string, string> logdic, List<LoginDetails> loglist)
        {
            foreach (var log in loglist)
            {

                if (!logdic.ContainsKey(log.Username))
                {
                    logdic.Add(log.Username, log.Password);
                   
                
                }
            }



            return logdic;
        }

        public bool ValLogin(string user, string pass, Dictionary<string, string> logdic)
        {
            bool approve = false;

            
                if (logdic.ContainsKey(user) && logdic.ContainsValue(pass)) {

                    approve = true;
                } 
                
          
            return approve;


        }

        public bool ValSuper(string user, List<LoginDetails> loglsit) {
            int index=0;
                    bool approve = false;

            foreach (var use in loglsit) {

                if (use.Username.Equals(user)) {

                    index = use.Supuer;

                }
                if (index == 1)
                    approve = true;
                break;

              }
            return approve;
        
        }





    }
}
