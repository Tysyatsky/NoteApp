
string customSize = Console.ReadLine();

int size = 0;

if (int.TryParse(customSize, out size)) Console.WriteLine("Size of the buffer: " + size);
else { Console.WriteLine("Error!");
    return;
}


Buffer myBuf = new Buffer(size);


myBuf.CreateNote();

Console.WriteLine(myBuf.inner_buffer[0].Name);
