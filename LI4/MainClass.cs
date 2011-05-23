using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class MainClass
    {
        static void Main()
        {

            User u = new User("Miguel", "Miguel@mail.um", "83");
            Console.WriteLine("Nome: "+u.Username);
            Console.WriteLine("Email: "+u.Email);
            Console.WriteLine("Password: " + u.Password);

            u.Username = "Miguel";
            u.Email = "email2";
            u.Password = "p2";

            User u2 = new User(u);
            u2.Password = "qualquer coisa";

            Console.WriteLine("Nome: " + u2.Username);
            Console.WriteLine("Email: " + u2.Email);
            Console.WriteLine("Password: " + u2.Password);

            Console.WriteLine("User: "+u2.equals(u));
        }
    }
}
