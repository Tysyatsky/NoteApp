

class Buffer
{
    int buf_size;

    Note[] inner_buffer;

    public int BufSize {
        get { return buf_size; }
        set { buf_size = value; }
    }

    public Buffer(int size)
    {
        inner_buffer = new Note[size];
        buf_size = size;
    }
    public void ListAllNames()
    {
        Console.WriteLine("All names listed under: ");
        
        for (int i = 0; i < Note.Note_count; i++)
        {
            Console.WriteLine(inner_buffer[i].Name);
        }
    } 
    public void CreateNote()
    {
        Console.WriteLine("Enter name: ");
        string temp_name = Console.ReadLine() + ".txt";
        temp_name ??= "default" + Note.Note_count + ".txt";
        Console.WriteLine("Enter text in your file: ");
        string temp_text = Console.ReadLine();
        temp_text ??= "text";

        ArrayManage.InsertID(ref inner_buffer, Note.Note_count, new Note(temp_name, temp_text, false));
    }
    public int FindID(string name)
    {
        for (int i = 0; i < inner_buffer.Length; i++)
        {
            if (inner_buffer[i].Name == name) return i;
        }
        return -1;
    }
    public Note FindNote(string name)
    {
        for (int i = 0; i < inner_buffer.Length; i++)
        {
            if (inner_buffer[i].Name == name) return inner_buffer[i];
        }
        return null;
    }
    public bool DeleteNote(string name)
    {
        if (name == null) return false;
        int IDtoDelete = FindID(name);
        if (IDtoDelete == -1) return false;
        ArrayManage.DeleteID(ref inner_buffer, IDtoDelete);
        return true;
    }

}
