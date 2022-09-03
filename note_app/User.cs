
//Tests.Test1();
//Tests.Test2();
class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
    public virtual void PrintUserData()
    {
        Console.WriteLine($"Login: {Login}\n");
    }
}

class Admin : User
{
    bool IsAdmin;
    public Admin(string login, string password) : base(login, password)
    {
        Login = login;
        Password = password;
        IsAdmin = true;
    }
    public override void PrintUserData()
    {
        Console.WriteLine($"Login: {Login} Admin: {IsAdmin}\n");
    }
}


