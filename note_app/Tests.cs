


static class Tests
{
    public static void Test1()
    {
        Buffer myBuf = new Buffer(2);

        myBuf.CreateNote();
        myBuf.CreateNote();
        myBuf.CreateNote();
        
        myBuf.ListAllNames(true);
        
    }
    public static void Test2()
    {
        Buffer myBuf = new Buffer(1);
        Menu mainMenu = new Menu();
        mainMenu.Start();
        if (myBuf == null) { Console.WriteLine("Error on creation"); return; }
        else { Console.WriteLine("All good"); }
        //mainMenu.NewNote(); // commented due to new protection level
      //  myBuf.ListAllNames();
    }
    public static void Test3()
    {
        UserData DataBase = new UserData();

        DataBase.Users.Add(new User("tysyatsky01", "01"));
        DataBase.Users.Add(new Admin("tysyatsky_admin", "00"));
        //list all users added
        DataBase.ListAllUsers();
        //save user info
        DataBase.SaveUserData();
    }
}