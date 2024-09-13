using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace User_Page
{
    internal class UserController
    {

        ArrayList Users;

        public UserController()
        {
            Users = new ArrayList();
        }

        public void AddUsers(Users user)
        {
            Users.Add(user);
        }


        public ArrayList GetUsers()
        {
            return Users;
        }


        public void SignIn(string email, string password)
        {
            ArrayList user = (ArrayList)Users;

            foreach (Users allUser in user)
            {
                if (email == allUser.Email && password == allUser.Password)
                {

                    if (allUser.UserRole == UserRole.Admin)
                    {
                    Info:
                        Console.WriteLine($"Welcome {allUser.Name}\n\n" +
                                          $"Your info:\n" +
                                          $"Name: {allUser.Name},\n" +
                                          $"Surname: {allUser.Surname},\n" +
                                          $"Age: {allUser.Age},\n" +
                                          $"Email: {allUser.Email},\n" +
                                          $"Role: {allUser.UserRole}");

                        Thread.Sleep(1000);
                    Add:
                        Console.WriteLine("\nSelect the option: \n" +
                                                "1.Add user,\n" +
                                                "2.Delete user,\n" +
                                                "3.Update user profile,\n" +
                                                "4.Update profil\n" +
                                                "====================");
                        string input = Console.ReadLine();
                        int Secim;

                        if (int.TryParse(input, out Secim) && Secim > 0 && Secim < 5)
                        {

                            if (Secim == 1)
                            {
                                Console.Clear();

                                Console.WriteLine("Enter the user's name");
                                string name = Console.ReadLine();
                                Console.Clear();

                                Console.WriteLine("Enter the user's surname");
                                string surname = Console.ReadLine();
                                Console.Clear();
                            Age:
                                Console.WriteLine("Enter the user's age");
                                string inputAge = Console.ReadLine();
                                int age;
                                Console.Clear();

                                if (int.TryParse(inputAge, out age) && age >= 0)
                                {
                                    Console.WriteLine("Enter the user's email");
                                    string email_1 = Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine("Enter the user's password");
                                    string password_1 = Console.ReadLine();
                                    Console.Clear();

                                    Users newUser = new Users
                                    (
                                        name = name,
                                        surname = surname,
                                        age = age,
                                        email = email_1,
                                        password = password_1,
                                        UserRole.User
                                    );

                                    Users.Add(newUser);
                                    int counter = 1;
                                    foreach (Users allusers in Users)
                                    {

                                        if (allusers.UserRole == UserRole.User)
                                        {


                                            Console.WriteLine($"\nUser-ID: {counter++}\n" +
                                                                $"Name: {allusers.Name},\n" +
                                                                $"Surname: {allusers.Surname},\n" +
                                                                $"Age: {allusers.Age},\n" +
                                                                $"Email: {allusers.Email},\n" +
                                                                $"Role: {allusers.UserRole}");


                                        }

                                    }

                                Kec:
                                    Thread.Sleep(1000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                    string Kec = Console.ReadLine().ToLower();

                                    if (Kec == "f".ToLower())
                                    {
                                        Console.Clear();
                                        goto Add;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press the right button!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Kec;
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid age! Try again.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Age;
                                }


                            }

                            else if (Secim == 2)
                            {
                            Nomre:
                                Console.Clear();
                                int Say = Users.Count;

                                int counter = 1;
                                foreach (Users allusers in Users)
                                {

                                    if (allusers.UserRole == UserRole.User)
                                    {


                                        Console.WriteLine($"\nUser-ID: {counter++}\n" +
                                                            $"Name: {allusers.Name},\n" +
                                                            $"Surname: {allusers.Surname},\n" +
                                                            $"Age: {allusers.Age},\n" +
                                                            $"Email: {allusers.Email},\n" +
                                                            $"Role: {allusers.UserRole}");


                                    }

                                }

                                Console.Write("\nEnter the ID of the user: ");
                                string id = Console.ReadLine();
                                int ID;
                                Console.Clear();

                                if (int.TryParse(id, out ID) && ID <= Say && ID > 0)
                                {
                                    Users.RemoveAt(ID);

                                    int counter_1 = 1;
                                    foreach (Users allusers in Users)
                                    {

                                        if (allusers.UserRole == UserRole.User)
                                        {


                                            Console.WriteLine($"\nUser-ID: {counter_1++}\n" +
                                                                $"Name: {allusers.Name},\n" +
                                                                $"Surname: {allusers.Surname},\n" +
                                                                $"Age: {allusers.Age},\n" +
                                                                $"Email: {allusers.Email},\n" +
                                                                $"Role: {allusers.UserRole}");


                                        }

                                    }
                                Kec:
                                    Thread.Sleep(1000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                    string Kec = Console.ReadLine().ToLower();

                                    if (Kec == "f".ToLower())
                                    {
                                        Console.Clear();
                                        goto Add;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Press the right button!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Kec;
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("Please try again!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Nomre;
                                }

                            }

                            else if (Secim == 3)
                            {
                            ID:
                                Console.Clear();
                                int Say = Users.Count;

                                int counter = 1;
                                foreach (Users allusers in Users)
                                {

                                    if (allusers.UserRole == UserRole.User)
                                    {


                                        Console.WriteLine($"\nUser-ID: {counter++}\n" +
                                                            $"Name: {allusers.Name},\n" +
                                                            $"Surname: {allusers.Surname},\n" +
                                                            $"Age: {allusers.Age},\n" +
                                                            $"Email: {allusers.Email},\n" +
                                                            $"Role: {allusers.UserRole}");


                                    }

                                }

                                Console.Write("\nEnter the ID of the user: ");
                                string id = Console.ReadLine();
                                int ID;


                                if (int.TryParse(id, out ID) && ID > 0 && ID <= Say)
                                {
                                    Users Account = (Users)Users[ID];

                                    Console.Clear();
                                UserPassword:
                                    Console.WriteLine("Enter the password of the user");
                                    string Password = Console.ReadLine();

                                    if (Password == Account.Password)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter the user's new name");
                                        string name = Console.ReadLine();
                                        Console.Clear();

                                        Console.WriteLine("Enter the user's new surname");
                                        string surname = Console.ReadLine();
                                        Console.Clear();
                                    Age:
                                        Console.WriteLine("Enter the user's new age");
                                        string inputAge = Console.ReadLine();
                                        int age;
                                        Console.Clear();

                                        if (int.TryParse(inputAge, out age) && age >= 0)
                                        {
                                            Console.WriteLine("Enter the user's new email");
                                            string email_1 = Console.ReadLine();
                                            Console.Clear();

                                            Console.WriteLine("Enter the user's new password");
                                            string password_1 = Console.ReadLine();
                                            Console.Clear();



                                            Users Updated = new Users
                                            (
                                                name = name,
                                                surname = surname,
                                                age = age,
                                                email = email_1,
                                                password = password_1,
                                                UserRole.User
                                            );

                                            Users[ID] = Updated;
                                            int counter_1 = 1;
                                            foreach (Users allusers in Users)
                                            {

                                                if (allusers.UserRole == UserRole.User)
                                                {


                                                    Console.WriteLine($"\nUser-ID: {counter_1++}\n" +
                                                                        $"Name: {allusers.Name},\n" +
                                                                        $"Surname: {allusers.Surname},\n" +
                                                                        $"Age: {allusers.Age},\n" +
                                                                        $"Email: {allusers.Email},\n" +
                                                                        $"Role: {allusers.UserRole}");


                                                }

                                            }
                                        Kec:
                                            Thread.Sleep(1000);
                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                            string Kec = Console.ReadLine().ToLower();

                                            if (Kec == "f".ToLower())
                                            {
                                                Console.Clear();
                                                goto Add;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Press the right button!");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                goto Kec;
                                            }

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please try again!");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            goto Age;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Incorrect password!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto UserPassword;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please try again!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto ID;
                                }

                            }

                            else if (Secim == 4)
                            {
                                Console.Clear();
                                foreach (Users admin in Users)
                                {
                                    ArrayList Admin = new ArrayList();
                                    if (admin.UserRole == UserRole.Admin)
                                    {
                                        Admin.Add(admin.Name);
                                        Admin.Add(admin.Surname);
                                        Admin.Add(admin.Age);
                                        Admin.Add(admin.Email);
                                        Admin.Add(admin.UserRole);


                                        int count = Admin.Count;
                                        Console.WriteLine(
                                                    $"Your info:\n\n" +
                                                    $"Name: {allUser.Name},\n" +
                                                    $"Surname: {allUser.Surname},\n" +
                                                    $"Age: {allUser.Age},\n" +
                                                    $"Email: {allUser.Email},\n" +
                                                    $"Role: {allUser.UserRole}");

                                        Thread.Sleep(1000);
                                    Property:
                                        Console.Write("\nPlease, enter the property ID: ");
                                        string Input = Console.ReadLine();
                                        int PropID;

                                        if (int.TryParse(Input, out PropID) && PropID > 0 && PropID <= count)
                                        {
                                            Console.Clear();
                                        password:
                                            Console.Write("Enter your password: ");
                                            string UserPass = Console.ReadLine();

                                            if (UserPass == admin.Password)
                                            {
                                                var oldProp = Admin[PropID - 1];
                                                Console.Clear();
                                            newPROPERTY:
                                                Console.WriteLine("Write new property");
                                                string newProp = Console.ReadLine();
                                                int newproperty;
                                                if (oldProp is string)
                                                {
                                                    Admin[PropID - 1] = newProp;
                                                    Console.WriteLine("Property has succesfully changed!");
                                                    admin.Name = (string)Admin[0];
                                                    admin.Surname = (string)Admin[1];
                                                    admin.Age = (int)Admin[2];
                                                    admin.Email = (string)Admin[3];
                                                    admin.UserRole = (UserRole)Admin[4];
                                                Kec:
                                                    Thread.Sleep(1000);
                                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                                    string Kec = Console.ReadLine().ToLower();

                                                    if (Kec == "f".ToLower())
                                                    {
                                                        Console.Clear();
                                                        goto Info;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Press the right button!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        goto Kec;
                                                    }

                                                }
                                                else if (oldProp is int)
                                                {
                                                    if (int.TryParse(newProp, out newproperty) && newproperty > 0)
                                                    {
                                                        Admin[PropID - 1] = int.Parse(newProp);
                                                        Console.WriteLine("Property has succesfully changed!");



                                                    Kec:
                                                        Thread.Sleep(1000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                                        string Kec = Console.ReadLine().ToLower();

                                                        admin.Name = (string)Admin[0];
                                                        admin.Surname = (string)Admin[1];
                                                        admin.Age = (int)Admin[2];
                                                        admin.Email = (string)Admin[3];
                                                        admin.UserRole = (UserRole)Admin[4];

                                                        if (Kec == "f".ToLower())
                                                        {
                                                            Console.Clear();
                                                            goto Info;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Press the right button!");
                                                            Thread.Sleep(1000);
                                                            Console.Clear();
                                                            goto Kec;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Try again!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        goto newPROPERTY;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Incorrect password!");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                goto password;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please try again!");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            goto Property;

                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please try again!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Add;
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Welcome {allUser.Name}\n\n" +
                                          $"Your info:\n" +
                                          $"Name: {allUser.Name},\n" +
                                          $"Surname: {allUser.Surname},\n" +
                                          $"Age: {allUser.Age},\n" +
                                          $"Email: {allUser.Email},\n" +
                                          $"Role: {allUser.UserRole}");

                        Thread.Sleep(1000);
                    Select:
                        Console.WriteLine("\n\nSelect the option:\n" +
                                                "1.Update account,\n" +
                                                "=====================");

                        string choose = Console.ReadLine();
                        int Choose;

                        if (int.TryParse(choose, out Choose) && Choose > 0 && Choose < 2)
                        {

                            if (Choose == 1)
                            {
                                Console.Clear();
                                foreach (Users users in Users)
                                {
                                    ArrayList user_1 = new ArrayList();

                                    if (users.UserRole == UserRole.User)
                                    {
                                        user_1.Add(users.Name);
                                        user_1.Add(users.Surname);
                                        user_1.Add(users.Age);
                                        user_1.Add(users.Email);
                                        user_1.Add(users.UserRole);


                                        int say = user_1.Count;
                                    Secmek:
                                        Console.WriteLine(
                                                     $"Your info:\n" +
                                                     $"Name: {users.Name},\n" +
                                                     $"Surname: {users.Surname},\n" +
                                                     $"Age: {users.Age},\n" +
                                                     $"Email: {users.Email},\n" +
                                                     $"Role: {users.UserRole}");

                                        Console.Write("\nEnter the property ID: ");
                                        string ID = Console.ReadLine();
                                        int id;

                                        if (int.TryParse(ID, out id) && id > 0 && id <= say)
                                        {
                                            Console.Clear();
                                        Password:
                                            Console.WriteLine("Enter your password: ");
                                            string Password = Console.ReadLine();

                                            if (Password == users.Password)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Enter the new property");
                                                string newProperty = Console.ReadLine();
                                                int property;

                                                var Oldproperty = user_1[id - 1];

                                                if (Oldproperty is string)
                                                {
                                                    user_1[id - 1] = newProperty;

                                                    users.Name = (string)user_1[0];
                                                    users.Surname = (string)user_1[1];
                                                    users.Age = (int)user_1[2];
                                                    users.Email = (string)user_1[3];
                                                    users.UserRole = (UserRole)user_1[4];

                                                    Console.WriteLine("Property has succesfully changed!");

                                                    Thread.Sleep(1000);

                                                Kec:
                                                    Thread.Sleep(1000);
                                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                                    string Kec = Console.ReadLine().ToLower();

                                                    if (Kec == "f".ToLower())
                                                    {
                                                        Console.Clear();
                                                        goto Secmek;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Press the right button!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        goto Kec;
                                                    }

                                                }
                                                else if (Oldproperty is int)
                                                {
                                                    if (int.TryParse(newProperty, out property) && property > 0)
                                                    {
                                                        user_1[id - 1] = property;

                                                        users.Name = (string)user_1[0];
                                                        users.Surname = (string)user_1[1];
                                                        users.Age = (int)user_1[2];
                                                        users.Email = (string)user_1[3];
                                                        users.UserRole = (UserRole)user_1[4];

                                                        Console.WriteLine("Property has succesfully changed!");

                                                        Thread.Sleep(1000);

                                                    Kec:
                                                        Thread.Sleep(1000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");
                                                        string Kec = Console.ReadLine().ToLower();

                                                        if (Kec == "f".ToLower())
                                                        {
                                                            Console.Clear();
                                                            goto Secmek;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Press the right button!");
                                                            Thread.Sleep(1000);
                                                            Console.Clear();
                                                            goto Kec;
                                                        }
                                                    }
                                                }


                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Incorrect password!");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                goto Password;
                                            }
                                        }
                                    }
                                }
                            }

   

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Choose right option!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Select;
                        }

                    }
                    return;
                }
                Console.WriteLine("Email or password is not correct!");

            }


        }

        public void SignUp(string name, string surname, int age, string email, string password, UserRole userrole)
        {
            Users newUser = new Users(name, surname, age, email, password, userrole);
            Users.Add(newUser);

            foreach (Users allUsers in Users)
            {
                if(allUsers.UserRole == UserRole.User)
                {
                    Console.WriteLine($"\n\nYour info:\n\n" +
                                        $"Name: {allUsers.Name},\n" +
                                        $"Surname: {allUsers.Surname},\n" +
                                        $"Age: {allUsers.Age},\n" +
                                        $"Email: {allUsers.Email},\n" +
                                        $"Role: {allUsers.UserRole}");
                }
            }
        }
    }

}
