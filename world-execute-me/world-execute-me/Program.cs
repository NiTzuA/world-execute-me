using System.Diagnostics;

Random ran = new Random();
TextAnimationRandomized(5, "Hello World!", 100);

void TextAnimationRandomized(int duration, string text, int animationSpeed)
{
    int stringLength = text.Length;
    Stopwatch stopwatch = Stopwatch.StartNew();

    while (stopwatch.Elapsed.TotalSeconds < duration) // duration is in seconds, animationSpeed is in miliseconds
    {
        RandomAsciiString(stringLength);
        Console.Write("\r" + RandomAsciiString(stringLength));
        Thread.Sleep(animationSpeed);
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\r" + text);
    Console.ForegroundColor = ConsoleColor.White;
}

string RandomAsciiString(int length)
{
    char[] chars = new char[length];
    for (int i = 0; i < length; i++)
    {
        chars[i] = (char)ran.Next(32, 127);
    }
    return new string(chars);
}