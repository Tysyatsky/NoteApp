


static class ArrayManage
{   
    static void resize(ref Note[] temp_arr, int new_size)
    {

        Note[] buff = temp_arr;
        Note[] new_arr = new Note[new_size];

        for (int i = 0; i < buff.Length && i < new_arr.Length; i++)
        {
            new_arr[i] = buff[i];
        }
        temp_arr = new_arr;
    }

    static void InsertTop(ref Note[] temp_arr, Note item)
    {
        Note[] temp = new Note[temp_arr.Length + 1];
        Array.Copy(temp_arr, 0, temp, 1, temp_arr.Length - 1);
        temp[0] = item;
        temp_arr = temp;
    }

    static void InsertBottom(ref Note[] temp_arr, Note item)
    {
        resize(ref temp_arr, temp_arr.Length + 1);
        temp_arr[temp_arr.Length - 1] = item;
    }

    public static void InsertID(ref Note[] temp_arr, int id, Note item)
    {
        if (id < 0)
        {
            Console.WriteLine("Unknown id");
            return;
        }
        if (id == 0)
        {
            InsertTop(ref temp_arr, item);
            return;
        }
        if (id >= temp_arr.Length - 1)
        {
            InsertBottom(ref temp_arr, item);
            return;
        }
        Note[] temp = new Note[temp_arr.Length + 1];
        for (int i = 0, j = 0; i < temp_arr.Length; i++, j++)
        {
            if (i == id)
            {
                j--;
                continue;
            }
            temp[i] = temp_arr[j];
        }
        temp[id] = item;
        temp_arr = temp;
    }

    static void DeleteTop(ref Note[] temp_arr)
    {
        Note[] new_arr = new Note[temp_arr.Length - 1];
        Array.Copy(temp_arr, 1, new_arr, 0, temp_arr.Length - 1);
        temp_arr = new_arr;
    }

    static void DeleteBottom(ref Note[] temp_arr)
    {
        resize(ref temp_arr, temp_arr.Length - 1);
    }

    public static void DeleteID(ref Note[] temp_arr, int id)
    {
        if (id < 0)
        {
            Console.WriteLine("Unknown id");
            return;
        }
        if (id == 0)
        {
            DeleteTop(ref temp_arr);
            return;
        }
        if (id >= temp_arr.Length - 1)
        {
            DeleteBottom(ref temp_arr);
            return;
        }
        Note[] temp = new Note[temp_arr.Length - 1];
        for (int i = 0, j = 0; j < temp_arr.Length && i < temp.Length; i++, j++)
        {
            if (j == id)
            {
                i--;
                continue;
            }
            temp[i] = temp_arr[j];
        }
        temp_arr = temp;
    }
} 
