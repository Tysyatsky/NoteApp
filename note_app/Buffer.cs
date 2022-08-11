

class Buffer
{
    int buf_size;
    List<Note> inner_list;
    public int BufSize {
        get { return buf_size; }
        set { buf_size = value; }
    }

    public Buffer(int size)
    {
        buf_size = size;
        inner_list = new List<Note>();
        ReadBuffer();
    }

    public bool ListAllNames(bool admin)
    {
        //Console.WriteLine("All names listed under: ");
        
        if (!admin)
        {
            List<Note> notesWithPerm = new List<Note>();
            notesWithPerm = inner_list.Where(note => note.WritePerm == true).ToList();
            if (notesWithPerm.Count == 0)
            {
                Console.WriteLine("No notes for Guest permission");
                return false;
            }
            foreach (Note note in notesWithPerm)
            {
                Console.WriteLine(note.Name);
            }
            return true;
        }
        else
        {   
            foreach (Note note in inner_list)
            {
                Console.WriteLine(note.Name);
            }
            return true;
        }


    } 
    public void CreateNote()
    {
        Console.WriteLine("Enter name: ");
        string temp_name = Console.ReadLine() + ".txt";
        temp_name ??= "default.txt";
        Console.WriteLine("Enter text in your file: ");
        string temp_text = Console.ReadLine();
        temp_text ??= "text";
        Console.WriteLine("Enter 1 for editing or 0 for not editing:");
        string permisionW = Console.ReadLine();
        bool permW;
        if (permisionW == "1") permW = true;
        else permW = false;
        Console.WriteLine("Enter 1 for reading or 0 for not reading:\n Note: applies only for guest reading!");
        string permisionR = Console.ReadLine();
        bool permR;
        if (permisionR == "1") permR = true;
        else permR = false;

        inner_list.Add(new Note(temp_name, temp_text, permR, permW));
        BufSize = inner_list.Count;

    }
    public Note FindNote(string name)
    {
        foreach (Note note in inner_list)
        {   
            if (note.Name == name) return note;
        }
        return null;
    }
    public bool DeleteNote(string name)
    {
        if (name == null) return false;
        Note IDtoDelete = FindNote(name);
        if (IDtoDelete == null) return false;
        inner_list.Remove(IDtoDelete);
        BufSize = inner_list.Count;

        return true;
    }
    public bool EditNote(string name, bool admin)
    {
        if (name == null) return false;
        Note ToEdit = FindNote(name);
        if (ToEdit == null) return false;
        if (admin)
        {
            Console.WriteLine("\nAdmin permission succeed!");
        }
        else if (ToEdit.WritePerm == false)
        {
            Console.WriteLine("\nPermission denied...");
            return false;
        }
        Console.WriteLine("Do you like to change name, text or both?\n1. Name\n2. Text\n3. Both");
        string choose = Console.ReadLine();
        if (choose == null) return false;
        int edit = 0;
        if (!int.TryParse(choose, out edit))
        {
            return false;
        }
        switch (edit)
        {
            case 1:
                {
                    Console.WriteLine("Enter new name: ");
                    string newName = Console.ReadLine();
                    if (newName == null) return false;
                    if (newName.Length == 0) return false;
                    ToEdit.Name = newName;
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Enter new text: ");
                    string newText = Console.ReadLine();
                    if (newText == null) return false;
                    if (newText.Length == 0) return false;
                    ToEdit.Text = newText;
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Enter new name: ");
                    string newName = Console.ReadLine();
                    if (newName == null) return false;
                    if (newName.Length == 0) return false;
                    ToEdit.Name = newName;
                    Console.WriteLine("Enter new text: ");
                    string newText = Console.ReadLine();
                    if (newText == null) return false;
                    if (newText.Length == 0) return false;
                    ToEdit.Text = newText;
                    break;
                }
        }
        return true;
    }
    public bool ReadBuffer()
    {
        inner_list.Clear();
        Extract.AllFileImport(inner_list);
        return true;
    }
    public bool WriteBuffer(string tName)
    {

        Note tNote = FindNote(tName);
        if (tNote == null)
        {
            return false;
        }
        try
        {
            Extract.FileExport(tNote);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        DeleteNote(tNote.Name);
        return true;
    }
    public bool WriteAllBuffer()
    {   
        if (inner_list != null)
        {
            Extract.AllFileExport(inner_list);
            inner_list.Clear();
            return true;
        }
        else return false;
    }
}
