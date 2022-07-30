







static class Extract 
{
    static string root_rep_path = @"D:\на збереження\git\test_c#\note_app\note_app\data";
    
    static public void AllFileExport(Note[] notes)
    {
        if (notes == null) return;
        else if (notes[0] == null) return;
        else
        {   
            for (int i = 0; i < notes.Length; i++)
            {
                if (notes[i] == null) continue;
                else
                {
                    FileExport(notes[i]);
                }
            }
        }
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
        //StreamReader sr = new StreamReader(root_rep_path);
    }
}
