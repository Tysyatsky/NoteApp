


class Note
{
    public string Text { get; set; }
    public string Name { get; set; }

    public static int Note_count = 0;

    private bool Edit_per;

    public Note()
    {
        Text = String.Empty;
        Name = String.Empty;
        Edit_per = true;
        Note_count++;
    }

    public Note(string name_, string text_, bool perm)
    {
        Name = name_;
        Text = text_;
        Edit_per = perm;
        Note_count++;
    }

    public bool Perm
    {
        get { return Edit_per; }
        set { Edit_per = value; }
    }
}