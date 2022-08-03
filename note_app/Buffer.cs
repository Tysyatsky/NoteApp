

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

    public void ListAllNames()
    {
        Console.WriteLine("All names listed under: ");
        
        foreach (Note note in inner_list)
        {
            Console.WriteLine(note.Name);
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
        inner_list.Add(new Note(temp_name, temp_text, false));
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
