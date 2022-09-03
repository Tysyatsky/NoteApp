







static class Extract
{
    //static string root_rep_path = @"..\..\..\data";

    static string getRelativePath()
    {
        // string newPath;
        string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string userFile = Path.Combine(CurrentDirectory, @"..\..\..\data");
        string userFilePath = Path.GetFullPath(userFile);
        return userFilePath;
    }

    static public void AllFileExport(List<Note> notes)
    {

        if (notes == null) return;
        else
        {
            foreach (Note note in notes)
            {
                if (note == null) continue;
                else
                {
                    FileExport(note);
                }
            }
        }
    }
    static public void AllFileImport(List<Note> notes)
    {

        foreach (string file in Directory.EnumerateFiles(getRelativePath(), " *.txt"))
        {
            string contents = File.ReadAllText(file);
            string name = Path.GetFileName(file);
            Note note = FileImport(name, contents);
            if (note == null) return;
            else
            {
                notes.Add(note);
            }
        }
        string[] files = Directory.GetFiles(getRelativePath());
        foreach (string file in files)
        {
            File.Delete(file);
        }
    }
    static public void FileExport(Note temp)
    {
        string path = Path.Combine(getRelativePath(), temp.Name);
        StreamWriter sw = File.CreateText(path);

        sw.Write(temp.Text);
        sw.Close();

        return;
    }
    static public Note FileImport(string name, string contents)
    {
        Note temp = new Note(name, contents, true, false);
        return temp;
    }
    static public void WriteUserData(List<User> userData)
    {

        string userFile = Path.Combine(getRelativePath(), "userdatabase.txt");
        string userFilePath = Path.GetFullPath(userFile);

        StreamWriter sw = File.CreateText(userFilePath);

        foreach (User user in userData)
        {
            sw.WriteLine(user.Login);
            sw.WriteLine(user.Password);
        }
        sw.Close();
    }

}
