







class Buffer
{
    int buf_size;

    string root_rep_path;

    public Note[] inner_buffer;

    public int BufSize {
        get { return buf_size; }
        set { buf_size = value; }
    }

    public Buffer(int size)
    {
        inner_buffer = new Note[size];
        buf_size = size;
        root_rep_path = @"D:\на збереження\git\test_c#\note_app\note_app\data";
    }

    public void CreateNote()
    {
        Console.WriteLine("Enter name: ");
        string temp_name = Console.ReadLine() + ".txt";
        temp_name ??= "default" + Note.Note_count + ".txt";
        Console.WriteLine("Enter text in your file: ");
        string temp_text = Console.ReadLine();
        temp_text ??= "text";
        Console.WriteLine("Number of Notes: " + Note.Note_count);
        inner_buffer[Note.Note_count] = new Note(temp_name, temp_text, false);
        Console.WriteLine("Number of Notes: " + Note.Note_count);
        if (inner_buffer[Note.Note_count - 1] == null)
        {
            Console.WriteLine("Failed Note creation!");
            return;
        }
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
        foreach (Note note in inner_buffer) { 
            if (note.Name == name)
            {
                return note;
            }
        }
        return null;
    }

}
