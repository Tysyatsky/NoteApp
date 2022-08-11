


class Note
{
    public string Text { get; set; }
    public string Name { get; set; }

    //public static int Note_count = 0;

    //private bool Edit_per;
    private bool Read_per;
    private bool Write_per;

    public Note()
    {
        Text = String.Empty;
        Name = String.Empty;
        //Edit_per = true;
        Read_per = true;
        Write_per = true;
    }

    public Note(string name_, string text_, bool permR, bool permW)
    {
        Name = name_;
        Text = text_;
        ReadPerm = permR;
        Write_per = permW;
    }

    public bool WritePerm
    {
        get { return Write_per; }
        set { Write_per = value; }
    }
    public bool ReadPerm
    {
        get { return Read_per; }
        set { Read_per = value; }
    }
}