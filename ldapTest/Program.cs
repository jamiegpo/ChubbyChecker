using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myClassLibrary;

namespace ldapTest
{
    class Program
    {
        static void Main(string[] args)
        {

            
            LdapUser testUser = new LdapUser("Bskyb.com", "jmh10");

            Console.WriteLine("Querying AD...");
            var test2 = testUser.GroupDetails();

            Console.WriteLine(test2[0].GroupName);
            Console.ReadLine();

        }
    }
}
