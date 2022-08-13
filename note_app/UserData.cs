
//Tests.Test1();
//Tests.Test2();


class UserData
{
    List<User> users = new List<User>();

    public List<User> Users { get { return users; } }

    public void ListAllUsers()
    {
        Console.WriteLine("---List of registered users---");
        foreach (var user in users)
        {
            user.PrintUserData();
        }
    }

    public void SaveUserData()
    {
        Extract.WriteUserData(users);
    }
}
