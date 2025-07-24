using System.Diagnostics;

Random ran = new Random();
TextTypingAnimation("Song: ", 0.4, false);
TextScatterAnimation("world.execute(me)", 0.5, 10, true);

Thread.Sleep(1000);
Console.WriteLine();

TextTypingAnimation("Artist: ", 0.5, false);
TextScatterAnimation("Mili", 0.5, 10, true);

Thread.Sleep(2000);
Console.Clear();

InsertPrompt();  
TextTypingAnimation("Switch on the power line: ", 0.4, false);
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("OFF");
Thread.Sleep(250);
EraseText(3);
TextScatterAnimation("ON", 0.5, 10, true);

DisplayAsciiIntro();

InsertPrompt();
TextTypingAnimation("Lay down your pieces: ", 0.4, false);






void TextScatterAnimation(string text, double duration, int animationSpeed, bool highlight)
{
    int stringLength = text.Length;
    Stopwatch stopwatch = Stopwatch.StartNew();

    while (stopwatch.Elapsed.TotalSeconds < duration) // duration is in seconds, animationSpeed is in miliseconds
    {     
        Console.Write(RandomAsciiString(stringLength));
        Console.CursorVisible = true;
        Thread.Sleep(animationSpeed);
        Console.CursorVisible = false;
        Console.SetCursorPosition(Console.CursorLeft - stringLength, Console.CursorTop);
    }

    Console.CursorVisible = true;

    if (highlight)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

void TextTypingAnimation(string text, double duration, bool highlight)
{
    int durationDivisor = 1;
    if (highlight)
    {
        durationDivisor = text.Length + 1;
    } else
    {
        durationDivisor = text.Length;
    }

    double animationSpeed = duration / durationDivisor;
    for (int i = 0; i < text.Length; i++)
    {
        Console.Write(text[i]);

        Thread.Sleep((int)(animationSpeed*1000));
    }

    Thread.Sleep((int)(animationSpeed * 1000));

    if (highlight)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\r" + text);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
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

void EraseText(int length)
{
    Console.SetCursorPosition(Console.CursorLeft - length, Console.CursorTop);
    for (int i = 0; i < length; i++)
    {
        Console.Write(" ");
    }
    Console.SetCursorPosition(Console.CursorLeft - length, Console.CursorTop);
}

void DisplayAsciiIntro()
{
    Console.WriteLine(); Thread.Sleep(10);
    Console.WriteLine("                    .__       .___                              .__  __              ___                  ___    ");
    Console.WriteLine("__  _  _____________|  |    __| _/    ____ ___  ___ ____   ____ |__|/  |_  ____     /  /   _____   ____   \\  \\   "); Thread.Sleep(10);
    Console.WriteLine("\\ \\/ \\/ /  _ \\_  __ \\  |   / __ |   _/ __ \\\\  \\/  // __ \\_/ ___\\|  \\   __\\/ __ \\   /  /   /     \\_/ __ \\   \\  \\  "); Thread.Sleep(10);
    Console.WriteLine(" \\     (  <_> )  | \\/  |__/ /_/ |   \\  ___/ >    <\\  ___/\\  \\___|  ||  | \\  ___/  (  (   |  Y Y  \\  ___/    )  ) "); Thread.Sleep(10);
    Console.WriteLine("  \\/\\_/ \\____/|__|  |____/\\____ | /\\ \\___  >__/\\_ \\\\___  >\\___  >__||__|  \\___  >  \\  \\  |__|_|  /\\___  >  /  /  "); Thread.Sleep(10);
    Console.WriteLine("                               \\/ \\/     \\/      \\/    \\/     \\/              \\/    \\__\\       \\/     \\/  /__/  "); Thread.Sleep(10);
    Console.WriteLine("Current Version: WorldExeMe v1.0.0-alpha");
    Console.WriteLine("Logged in as: ADMIN");
    Console.WriteLine("Song by: Mili"); Thread.Sleep(10);
    Console.WriteLine("Console Animation by: NiTzuA"); Thread.Sleep(10);
    Console.WriteLine("Welcome to WorldExeMe!\n"); Thread.Sleep(10);
}

void InsertPrompt()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("world@execute-me:~$ ");
    Console.ForegroundColor= ConsoleColor.Gray;
}