







static class Extract 
{
    static string root_rep_path = @"D:\на збереження\git\test_c#\note_app\note_app\data";
    
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

        foreach (string file in Directory.EnumerateFiles(root_rep_path, "*.txt"))
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
        string[] files = Directory.GetFiles(root_rep_path);
        foreach (string file in files)
        {
            File.Delete(file);
        }
    }
    static public void FileExport(Note temp)
    {   
        string path = Path.Combine(root_rep_path, temp.Name);
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
}
