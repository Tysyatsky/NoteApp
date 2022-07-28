
//Tests.Test1();
//Tests.Test2();
Menu mainMenu = new Menu();
mainMenu.Start();

class Menu
{
    Buffer innerBuffer = new Buffer(1);
    public void Start()
    {
        Console.WriteLine("Note program by Tysyatsky");
        /*
         switch case with
        
        1. Add note
        2. Delete note
        3. Export by name
        4. Export all
        */
        Console.WriteLine("Menu:\n1. Add note\n2. Delete note\n3. Export by name\n4. Export all");
        string tempChoose = Console.ReadLine();
        int choose = 0;

        if (int.TryParse(tempChoose, out choose)) { Console.WriteLine("Proceding");}
        else
        {
            Console.WriteLine("Enter number...");
            return;
        }
        switch(choose)
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
                    string tName = Console.ReadLine();
                    tName ??= "def.txt";
                    Note tNote = innerBuffer.FindNote(tName);
                    try
                    {
                        Extract.FileExport(tNote);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    break;
                }
            case 4:
                {
                    // none
                    break;
                }
            default:
                {
                    break;
                }
        }
        Start();
    }
    public void ChangeBufSize()
    {
        Console.WriteLine("Enter size of the buffer: ");
        string customSize = Console.ReadLine();

        int size = 0;

        if (int.TryParse(customSize, out size)) Console.WriteLine("Size of the buffer: " + size);
        else
        {
            Console.WriteLine("Error: Size parse");
            return;
        }
        innerBuffer = new Buffer(size);
    }
    public void NewNote() 
    {
        innerBuffer.CreateNote();
        Console.WriteLine("New note created!");
    }
    public void DeleteNote()
    {
        Console.WriteLine("All nodes is buffer: ");
        innerBuffer.ListAllNames();
        Console.WriteLine("Enter name of the Note to delete: ");
        string name = Console.ReadLine();
        if (name == null) { Console.WriteLine("Error: Invalid name"); return; }
        if (innerBuffer.DeleteNote(name)) { Console.WriteLine("Deletion complete!"); }
        else { Console.WriteLine("Deletion is corrupted"); }
        
    }
}
