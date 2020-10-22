using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactInfo contactInfo = new ContactInfo();
            var contactList = new List<ContactInfo>();
            contactList.Add(new ContactInfo("Lars", "Carlstedt", "hemma hos sig", "000-00 000", "000-00 00 000"));
            contactList.Add(new ContactInfo("Oskar", "Vennerlund", "någonstans", "000-00 00 000", "000-00 00 000"));
            contactList.Add(new ContactInfo("Karin", "Mäki-kala", "på discord", "000-00 00 000", "000-00 00 000"));
            contactList.Add(new ContactInfo("Simon", "Karvonen", "i ett grupprum", "000-00 00 000", "000-00 00 000"));
            contactList.Add(new ContactInfo("Andreas", "Hideblad", "skriv in något", "000-00 00 000", "000-00 00 000"));
            contactList.Add(new ContactInfo("Emil", "Sevon", "Hemma", "000-00 00 000", "073-24 99 538"));

            Console.WriteLine("Welcome to your phonebook.");
            Console.WriteLine("Choose an option from the list:");
            Console.WriteLine("add\nremove\nlist\nsearch\nchange\nexit\n");

            string firstName;
            string surName;
            string address;
            string homeNumber;
            string phoneNumber;
            
            while (true)
            {
                var choice = Console.ReadLine();
                choice.ToLower();
                if (choice == "add")
                {
                    Console.Write("Please enter your first name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Please enter your surname: ");
                    surName = Console.ReadLine();
                    Console.Write("Please enter your address: ");
                    address = Console.ReadLine();
                    Console.Write("Please enter your home number: ");
                    homeNumber = Console.ReadLine();
                    Console.Write("Please enter your mobile number: ");
                    phoneNumber = Console.ReadLine();
                    contactList.Add(new ContactInfo(firstName, surName, address, homeNumber, phoneNumber));
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }
                else if (choice == "remove")
                {
                    contactList.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }
                else if (choice == "list")
                {
                    foreach (var index in contactList)
                    {
                        index.Contacts();
                    }
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }
                else if (choice == "search")
                {
                    //string findFirstName = Console.ReadLine();
                    //contactList.Find(x => x.FirstName.Contains(findFirstName));

                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }
                else if (choice == "change")
                {
                    Console.WriteLine("\nWhich contact would you like to change?\n");
                    foreach (var item in contactList)
                    {
                        item.Contacts();
                    }
                    int user_Index = Convert.ToInt32(Console.ReadLine());
                    contactList.ElementAt(user_Index - 1);

                    Console.WriteLine("What do you want to change? \n'first name', 'surname', 'address', 'home number', 'mobile number' or 'exit' to save changes");
                    var choice2 = Console.ReadLine();
                    choice2.ToLower();
                    if (choice2 == "first name" || choice2 == "firstname")
                    {
                        var newFirstName = Console.ReadLine();
                        //ContactInfo. = newFirstName;
                    }
                    else if (choice2 == "surname")
                    {
                        var newSurName = Console.ReadLine();
                        //ContactInfo. = newSurName;
                    }
                    else if (choice2 == "address")
                    {
                        var newAddress = Console.ReadLine();
                        //ContactInfo. = newAddress;
                    }
                    else if (choice2 == "home number" || choice2 == "homenumber")
                    {
                        var newHomeNumber = Console.ReadLine();
                        //ContactInfo. = newHomeNumber;
                    }
                    else if (choice2 == "mobile number" || choice2 == "mobilenumber")
                    {
                        var newPhoneNumber = Console.ReadLine();
                        //ContactInfo.= newPhoneNumber;
                    }
                    else
                    {
                        Console.WriteLine("You did not enter a valid option: choose an item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    }
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                }
                else if (choice == "exit")
                {
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid option, choose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }
            }
            //contactInfo.Contacts();
        }
    }
}
