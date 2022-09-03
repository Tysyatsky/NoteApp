
//Tests.Test1();
//Tests.Test2();
class Menu
{
    Buffer innerBuffer = new Buffer(1);
    string log = "admin";
    string password = "admin";
    bool admin = false;

    public Menu()
    {
        Login();
    }
    public void Login()
    {
        Console.Write("Enter Login: ");
        string login = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();
        if (login == null || password == null) { admin = false; }
        if (login == log && password == this.password) { Console.WriteLine("Hello Admin!"); admin = true; }
        else { Console.WriteLine("Hello Guest!"); admin = false; }
    }
    public void Start()
    {
        Console.WriteLine("Note program by Tysyatsky");

        /*
         switch case with
        
        1. Add note
        2. Delete note
        3. Save note by name
        4. Save all
        5. ReadAll in buffer

        0. Exit
        */
        Console.WriteLine("Menu:\n1. Add note\n2. Delete note\n3. Edit note\n0. Save and quit");
        string tempChoose = Console.ReadLine();
        int choose = 0;

        if (int.TryParse(tempChoose, out choose)) { Console.WriteLine("---"); }
        else
        {
            Console.WriteLine("Enter number...");
            return;
        }
        switch (choose)
        {

            case 1:
                {
                    NewNote();
                    break;
                }
            case 2:
                {
                    DeleteNote();
                    break;
                }
            case 3:
                {
                    EditNote();
                    break;
                }
            case 0:
                {
                    FileAllExctractBuf();
                    return;
                }
            default:
                {
                    break;
                }
        }
        Start();
    }

    private void NewNote()
    {
        innerBuffer.CreateNote();
        Console.WriteLine("New note created!");
    }
    private void DeleteNote()
    {
        Console.WriteLine("All nodes is buffer: ");
        innerBuffer.ListAllNames(admin);
        Console.WriteLine("Enter name of the Note to delete: ");
        string name = Console.ReadLine();
        if (name == null) { Console.WriteLine("Error: Invalid name"); return; }
        if (innerBuffer.DeleteNote(name)) { Console.WriteLine("Deletion complete!"); }
        else { Console.WriteLine("Deletion is corrupted"); }

    }
    private void EditNote()
    {
        if (innerBuffer.BufSize == 0)
        {
            Console.WriteLine("No notes to edit\nCreate new? (y/n)");
            string perm = Console.ReadLine();
            if (perm == null) return;
            if (perm.ToLower() == "y")
            {
                NewNote();
                return;
            }
        }
        else
        {

            if (innerBuffer.ListAllNames(admin))
            {
                Console.WriteLine("Enter name of the Note to edit: ");
                string name = Console.ReadLine();
                if (name == null) return;
                if (innerBuffer.EditNote(name, admin)) { Console.WriteLine("Edit is succesful"); }
                else { Console.WriteLine("Edit is corrupted"); }
            }
            else
            {
                return;
            }
        }

    }
    private void FileAllExctractBuf()
    {
        innerBuffer.WriteAllBuffer();
    }
}
