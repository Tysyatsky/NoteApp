
Tests.Test1();
Tests.Test2();


class Menu
{
    Buffer innerBuffer = new Buffer(1);
    public void Start()
    {
        Console.WriteLine("Note program by Tysyatsky");
        /*
         switch case with
        1. Reserve space in buffer
        2. Add note
        3. Delete note
        4. Export by name
        5. Export all
        */
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

        Console.WriteLine("Enter name of the Note: ");
        string name = Console.ReadLine();
        if (name == null) { Console.WriteLine("Error: Invalid name"); return; }
        
        
    }
}
