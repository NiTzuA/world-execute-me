using System.Diagnostics;

Random ran = new Random();
TextTypingAnimation("Song: ", 0.4, false, ConsoleColor.Gray);
TextScatterAnimation("world.execute(me)", 0.5, 10, ConsoleColor.Green);

Thread.Sleep(1000);
Console.WriteLine();

TextTypingAnimation("Artist: ", 0.5, false, ConsoleColor.Gray);
TextScatterAnimation("Mili", 0.5, 10, ConsoleColor.Green);

Thread.Sleep(2000);
Console.Clear();

TextTypingAnimation("Switch on the power line: ", 1.5, false, ConsoleColor.Gray);
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("OFF");
Thread.Sleep(250);
EraseText(3);
TextScatterAnimation("ON", 0.5, 10, ConsoleColor.Green);

DisplayAsciiIntro();

Console.ForegroundColor = ConsoleColor.Red;
Console.Write("WARNING: Object is unstable! ");
Console.ForegroundColor = ConsoleColor.Gray;
TextTypingAnimation("Remember to put on ", 1.5, false, ConsoleColor.Gray);
TextScatterAnimation("Protection", 0.5, 10, ConsoleColor.Yellow);
Console.WriteLine("\n");

InsertPrompt();
TextTypingAnimation("Lay down your pieces: ", 2, false, ConsoleColor.Gray);
EraseText("Lay down your pieces: ".Length);
TextScatterAnimation(".\\SetPieces.ps1", 0.5, 10, ConsoleColor.Gray);
Console.WriteLine();
Console.WriteLine("Currently Selected Piece/s: ");
Console.WriteLine(@"
    Piece you = new Piece 
    {
        Name = ""You"";
        Age = 100;
        Sex = 'M'; 
    }
        
    Piece me = new Piece 
    {
        Name = ""Me"";
        Age = 0;
        Sex = 'F'; 
    }

");

InsertPrompt();
TextTypingAnimation("And let's begin object creation", 2, false, ConsoleColor.Gray);
EraseText("And let's begin object creation".Length);
TextScatterAnimation(".\\CreateObjects.ps1", 0.5, 10, ConsoleColor.Gray);
AnimateCreateObjects();
InsertPrompt();
TextTypingAnimation("Fill in my data, parameters, initialization", 2, false, ConsoleColor.Gray);
EraseText("Fill in my data, parameters, initialization".Length);
TextScatterAnimation(@".\\FillDataForObjects.ps1 -ObjectOne ""You"" -ObjectTwo ""Me""", 0.5, 10, ConsoleColor.Gray);
Console.Write(@"
Data for Object 'You':
  ""HeightCm"": 175.4,
  ""WeightKg"": 68.2,
  ""EyeColor"": ""Gray"",
  ""HairColor"": ""Black"",
  ""BloodType"": ""AB-"",
  ""Ethnicity"": ""Mixed"",
  ""Nationality"": ""Unknown"",
  ""BiologicalAge"": 24.9,
  ""DNAHash"": ""X51T-91AC-GC14-2Z7Y""

Data for Object 'Me':
");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Error: Object is inaccesble.");
Console.ForegroundColor = ConsoleColor.White;






Thread.Sleep(2500);
void TextScatterAnimation(string text, double duration, int animationSpeed, ConsoleColor color)
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

    Console.ForegroundColor = color;
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.Gray;
}

void TextTypingAnimation(string text, double duration, bool highlight, ConsoleColor color)
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
        Console.ForegroundColor = color;
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
    Console.Write("PS W:\\Execute\\Me> ");
    Console.ForegroundColor= ConsoleColor.Gray;
}

void AnimateCreateObjects()
{
    Console.WriteLine(@"
Creating objects from Piece/s: 'You', 'Me'..."); Thread.Sleep(10);
    Console.WriteLine(@"Generating simulated world using object/s: You, Me... "); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'You'"); Thread.Sleep(10);
    Console.WriteLine(@"Object 'You' has been created! Applying to Simulated World"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me'"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (2)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (3)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (4)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (5)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (6)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (7)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (8)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make object 'Me' (9)"); Thread.Sleep(10);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(@"Unhandled Exception: System.IdentityNotFoundException: Cannot instantiate object 'Me'.");
    Console.WriteLine("Reason: 'Me' does not exist in the current conceptual layer.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Warning: Object creation completed with errors.");
    Console.WriteLine("Status: All objects initialized.");
    Console.WriteLine("Note: 1 object/s may be corrupted.");
    Console.WriteLine("Cause: Undefined referential origin in identity chain.");
    Console.WriteLine("Stack Trace:");
    Console.WriteLine("   at Simulation.ObjectRegistry.Register(Entity e)");
    Console.WriteLine("   at Simulation.World.Construct()");
    Console.WriteLine("   at Main()\n");
    Console.ForegroundColor = ConsoleColor.Gray;
}
