







static class Extract 
{
    static string root_rep_path = @"D:\на збереження\git\test_c#\note_app\note_app\data";
    
    static public void AllFileExport(Note[] notes)
    {
        foreach (Note note in notes)
        {
            FileExport(note);
        }
        return;
    }
    static public void FileExport(Note temp){   
        string path = Path.Combine(root_rep_path, temp.Name);
        StreamWriter sw = File.CreateText(path);

        sw.Write(temp.Text);
        sw.Close();

        return;
    }
    static public void FileRead(Note temp)
    {
        // поки тут нічого не буде 
    }
}
