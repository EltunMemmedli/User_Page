using System.Collections;
using User_Page;


Users Admin = new Users("Eltun", "Memmedli", 18, "eltun.memmedli.06@gmail.com", "2006", UserRole.Admin);
Users user_1 = new Users("Cavid", "Memmedli", 15, "cavid.memmedli.09@gmail.com", "2009", UserRole.User);
Users user_2 = new Users("Ehmed", "Qurbanli", 25, "ehmed.qurbanli.99@gmail.com", "1999", UserRole.User);


UserController Users = new UserController();

Users.AddUsers(Admin);
Users.AddUsers(user_1);
Users.AddUsers(user_2);

Options:
Console.WriteLine($"Please, choose one:\n\n" +
                    $"1.Sign In,\n" +
                    $"2.Sign Up\n" +
                    $"===============");

string input = Console.ReadLine();
int choose;
Console.Clear();

if(int.TryParse(input, out choose) && choose > 0 && choose < 3)
{
    if(choose == 1)
    {
        Console.WriteLine("Please, enter your email");
        string email = Console.ReadLine();
        Console.Clear();

        Console.Write("Please, enter your password: ");
        string password = Console.ReadLine();
        Console.Clear();

        Users.SignIn(email, password);
    }

    else if(choose == 2)
    {
        Console.Clear();

        Console.WriteLine("Enter your name ");
        string name = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter your surname");
        string surname = Console.ReadLine();
        Console.Clear();
        Age:
        Console.WriteLine("Enter your age");
        string Age = Console.ReadLine();
        int age;

        if(int.TryParse(Age, out age) && age > 0)
        {
            Console.Clear();
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            
            Users.SignUp(name, surname, age, email, password,UserRole.User );
            
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid syntax!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Age;
        }
    }

}
else
{
    Console.Clear();
    Console.WriteLine("Invalid option! Please, try again.");
    Thread.Sleep(1000);
    Console.Clear();
    goto Options;
}









/*
 
 
        SignIn
        SignUP
 
 
        SignIn -> password, email

        SignUp -> name, surname, age, password, role



        users
            {
                simple users,
                admin
                }

        Admin -> Update, Delete, Create
        users -> show info
 */
