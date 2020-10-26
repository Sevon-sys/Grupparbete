using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboration_2
{
    class Program
    {
        //En list med klass-scope
        public static List<ContactInfo> People = new List<ContactInfo>();

        static void Main()
        {
            //Förbestämda instanser av listan för att enkelt kunna använda sig utav funktionerna i programmet
            People.Add(new ContactInfo("Lars", "Carlstedt", "hemma hos sig", "000-00 000", "000-00 00 000"));
            People.Add(new ContactInfo("Oskar", "Vennerlund", "någonstans", "000-00 00 000", "000-00 00 000"));
            People.Add(new ContactInfo("Karin", "Mäki-kala", "på discord", "000-00 00 000", "000-00 00 000"));
            People.Add(new ContactInfo("Simon", "Karvonen", "i ett grupprum", "000-00 00 000", "000-00 00 000"));
            People.Add(new ContactInfo("Andreas", "Hideblad", "Lillebovägen 13", "000-00 00 000", "000-00 00 000"));
            People.Add(new ContactInfo("Emil", "Sevon", "Hemma", "000-00 00 000", "073-24 99 538"));

            Console.WriteLine("Welcome to your phonebook.");
            Console.WriteLine("Choose an option from the list:");
            Console.WriteLine("add\nremove\nlist\nsearch\nchange\nexit");
            
            //Variabler för att skapa en ny kontakt
            string firstName;
            string surName;
            string address;
            string homeNumber;
            string phoneNumber;
            
            //Loop som gör att programmet håller igång
            while (true)
            {
                var choice = Console.ReadLine();
                choice.ToLower();

                //En funktion för att lägga till en kontakt i listan
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
                    People.Add(new ContactInfo(firstName, surName, address, homeNumber, phoneNumber));
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }

                //En funktion för att ta bort en kontakt från listan
                else if (choice == "remove")
                {
                    int i = 1;
                    foreach (var item in People)
                    {
                        Console.WriteLine($"{i++}");
                        item.Contacts();
                    }
                    Console.WriteLine("Choose a number on the list to remove that contact: ");
                    string removechoice = Console.ReadLine();
                    var success = int.TryParse(removechoice, out int removePerson);
                    removePerson = removePerson - 1;
                    if (success == true)
                    {
                        if (removePerson < People.Count && removePerson >= 0)
                        {
                            People.RemoveAt(removePerson);
                        }
                        else
                        {
                            Console.WriteLine("You have written a number that is not on the list;");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }

                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }

                //En funktion för att visa kontakter i listan
                else if (choice == "list")
                {
                    int i = 1;
                    foreach (var index in People)
                    {
                        Console.WriteLine(i++);
                        index.Contacts();
                    }
                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }

                //En funktion för att söka i listan
                else if (choice == "search")
                {
                    Console.WriteLine("What do you want to search for? \n1. First name\n2. LastName\n3. Address\n4. Phone home\n5. Phone mobile");
                    choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        SearchFirstName();
                    }
                    else if (choice == "2")
                    {
                        SearchSurName();
                    }
                    else if (choice == "3")
                    {
                        SearchAddress();
                    }
                    else if (choice == "4")
                    {
                        SearchPhoneHome();
                    }
                    else if (choice == "5")
                    {
                        SearchPhoneMob();
                    }


                    Console.WriteLine("\nChoose a new item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }

                //En funktion för att ändra användaruppgifter i listan
                else if (choice == "change")
                {
                    int i = 1;
                    foreach (var item in People)
                    {
                        Console.WriteLine($"{i++}.");
                        item.Contacts();
                    }

                    //Console.WriteLine("\nWhich contact would you like to change?\n");
                    //string input_String = Console.ReadLine();
                    //var success = int.TryParse(input_String, out int user_Index);
                    while (true)
                    {
                        Console.WriteLine("\nWhich contact would you like to change?\n");
                        string input_String = Console.ReadLine();
                        var success = int.TryParse(input_String, out int user_Index);
                        if (success == true)
                        {
                            user_Index = user_Index - 1;
                            if (user_Index < People.Count && user_Index >= 0)
                            {
                                Console.WriteLine("What do you want to change? \n'first name', 'surname', 'address', 'home number', 'mobile number' or 'exit' to save changes");
                                var choice2 = Console.ReadLine();
                                choice2.ToLower();

                                if (choice2 == "first name" || choice2 == "firstname")
                                {
                                    Console.WriteLine("Please enter a new first name: ");
                                    var newFirstName = Console.ReadLine();
                                    var firstname = People[user_Index].FirstName;
                                    People[user_Index].FirstName = newFirstName;
                                    Console.WriteLine($"The first name: '{firstname}' was changed to '{newFirstName}'");
                                    break;
                                }

                                else if (choice2 == "surname")
                                {
                                    Console.WriteLine("Please enter a new surname: ");
                                    var newSurName = Console.ReadLine();
                                    var surname = People[user_Index].SurName;
                                    People[user_Index].SurName = newSurName;
                                    Console.WriteLine($"The surname: '{surname}' was changed to '{newSurName}'");
                                    break;
                                }

                                else if (choice2 == "address")
                                {
                                    Console.WriteLine("Please enter a new address: ");
                                    var newAddress = Console.ReadLine();
                                    var choice_address = People[user_Index].Address;
                                    People[user_Index].Address = newAddress;
                                    Console.WriteLine($"The address: '{choice_address}' was changed to '{newAddress}'");
                                    break;
                                }

                                else if (choice2 == "home number" || choice2 == "homenumber" || choice2 == "home")
                                {
                                    Console.WriteLine("Please enter a new home number: ");
                                    var newHomeNumber = Console.ReadLine();
                                    var homenumber = People[user_Index].PhoneHome;
                                    People[user_Index].PhoneHome = newHomeNumber;
                                    Console.WriteLine($"The home number: '{homenumber}' was changed to '{newHomeNumber}'");
                                    break;
                                }

                                else if (choice2 == "mobile number" || choice2 == "mobilenumber" || choice2 == "mobile")
                                {
                                    Console.WriteLine("Please enter a new mobile phone number: ");
                                    var newPhoneNumber = Console.ReadLine();
                                    var phonenumber = People[user_Index].PhoneMob;
                                    People[user_Index].PhoneMob = newPhoneNumber;
                                    Console.WriteLine($"The mobile phone number: '{phonenumber}' was changed to '{newPhoneNumber}'");
                                    break;
                                }

                                else if (choice2 == "exit")
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You did not enter a valid option, choose an item in the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You did not enter a number.");
                            continue;
                        }
                    }
                }

                //En funktion för att avsluta programmet
                else if (choice == "exit")
                {
                    break;
                }

                //Ett felmeddelande-verktyg
                else
                {
                    Console.WriteLine("Invalid option. Choose an option from the list: \nadd\nremove\nlist\nsearch\nchange\nexit\n");
                    continue;
                }
            }
        }

        //Metod för att söka efter förnamn
        private static void SearchFirstName()
        {
            List<ContactInfo> people = FirstNameSearch();
            if(people.Count == 0)
            {
                Console.WriteLine("Could not find a person in the list with that first name");
                return;
            }
            foreach(var index in people)
            {
                index.Contacts();
            }
        }

        //Metod för att söka efter efternamn
        private static void SearchSurName()
        {
            List<ContactInfo> people = SurNameSearch();
            if (people.Count == 0)
            {
                Console.WriteLine("Could not find a person in the list with the surname");
                return;
            }
            foreach (var index in people)
            {
                index.Contacts();
            }
        }
        
        //Metod för att söka efter address
        private static void SearchAddress()
        {
            List<ContactInfo> people = AdressSearch();
            if (people.Count == 0)
            {
                Console.WriteLine("Could not find a person in the list with that address");
                return;
            }
            foreach (var index in people)
            {
                index.Contacts();
            }
        }

        //Metod för att söka efter hemnummer
        private static void SearchPhoneHome()
        {
            List<ContactInfo> people = PhoneHomeSearch();
            if (people.Count == 0)
            {
                Console.WriteLine("Could not find a person in the list with that home number");
                return;
            }
            foreach (var index in people)
            {
                index.Contacts();
            }
        }

        //Metod för att söka efter mobilnummer
        private static void SearchPhoneMob()
        {
            List<ContactInfo> people = PhoneMobSearch();
            if (people.Count == 0)
            {
                Console.WriteLine("Could not find a person in the list with that mobile number");
                return;
            }
            foreach (var index in people)
            {
                index.Contacts();
            }
        }

        //Söker igenom i listan efter förnamnet som angavs i sökmetod-parametern
        private static List<ContactInfo> FirstNameSearch()
        {
            Console.WriteLine("Who do you want to find?");
            string firstName = Console.ReadLine();
            return People.Where(x => x.FirstName.ToLower() == firstName.ToLower()).ToList();
        }

        //Söker igenom i listan efter efternamnet som angavs i sökmetod-parametern
        private static List<ContactInfo> SurNameSearch()
        {
            Console.WriteLine("Who do you want to find?");
            string surName = Console.ReadLine();
            return People.Where(x => x.SurName.ToLower() == surName.ToLower()).ToList();
        }

        //Söker igenom i listan efter addressen som angavs i sökmetod-parametern
        private static List<ContactInfo> AdressSearch()
        {
            Console.WriteLine("Who do you want to find?");
            string address = Console.ReadLine();
            return People.Where(x => x.Address.ToLower() == address.ToLower()).ToList();
        }

        //Söker igenom i listan efter hemnummret som angavs i sökmetod-parametern
        private static List<ContactInfo> PhoneHomeSearch()
        {
            Console.WriteLine("Who do you want to find?");
            string phoneHome = Console.ReadLine();
            return People.Where(x => x.PhoneHome.ToLower() == phoneHome.ToLower()).ToList();
        }

        //Söker igenom i listan efter mobilnummret som angavs i sökmetod-parametern
        private static List<ContactInfo> PhoneMobSearch()
        {
            Console.WriteLine("Who do you want to find?");
            string phoneMob = Console.ReadLine();
            return People.Where(x => x.PhoneMob.ToLower() == phoneMob.ToLower()).ToList();
        }

    }
}
