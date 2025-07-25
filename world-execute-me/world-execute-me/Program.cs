using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
Console.Write("WARNING: System is unstable! ");
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
TextTypingAnimation("Fill in my data, parameters, initialization", 3, false, ConsoleColor.Gray);
EraseText("Fill in my data, parameters, initialization".Length);
TextScatterAnimation(@".\\FillDataForObjects.ps1 -ObjectOne ""You"" -ObjectTwo ""Me""", 0.5, 10, ConsoleColor.Gray);
Console.WriteLine(@"Data for user ""You"":"); Thread.Sleep(10);
Console.WriteLine(@"""Username"": ""You"""); Thread.Sleep(10);
Console.WriteLine(@"""Email"": ""you.execute@me.com"""); Thread.Sleep(10);
Console.WriteLine(@"""Password"": **********"); Thread.Sleep(10);
Console.WriteLine(); Thread.Sleep(500);
Console.WriteLine(@"Data for user ""Me"":"); Thread.Sleep(10);

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Error: Object is inaccesble.");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Gray;


InsertPrompt();
TextTypingAnimation("Setup our new world", 2, false, ConsoleColor.Gray);
EraseText("Setup our new world".Length);
TextScatterAnimation(".\\SetupNewWorld --suppress-errors --force-creation", 0.5, 10, ConsoleColor.Gray);
Console.WriteLine();
Console.Write("Confirm setup for new virtual world using existing users? (y\\n): ");
Console.ForegroundColor = ConsoleColor.Red;
TextTypingAnimation("And let's begin the S I M U L A T I O N .", 3, true, ConsoleColor.Red); Thread.Sleep(100);
EraseText("And let's begin the S I M U L A T I O N .".Length);
TextScatterAnimation("y", 0.5, 10, ConsoleColor.Red);
Thread.Sleep(500);

Console.Clear();
AnimateWorldCreation();







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
        Console.SetCursorPosition(Console.CursorLeft - text.Length, Console.CursorTop);
        Console.Write(text);
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
    Console.WriteLine("Establishing Virtual Environment...");
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
    Console.WriteLine(@"Generating virtual environment using object/s: You, Me... "); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make user 'You'"); Thread.Sleep(10);
    Console.WriteLine(@"User 'You' has been created! Applying to Simulated World"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make user 'Me'"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make user 'Me' (2)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make user 'Me' (3)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make user 'Me' (4)"); Thread.Sleep(10);
    Console.WriteLine(@"Attempting to make user 'Me' (5)"); Thread.Sleep(10);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Unhandled Exception: System.IdentityNotFoundException: Cannot instantiate object 'Me'.");
    Console.WriteLine("Reason: 'Me' does not exist in the current conceptual layer.");
    Console.WriteLine("Details: Attempted to resolve existential reference to 'Me' from non-being.");
    Console.WriteLine("Suggestion: Ensure 'Me' is logically defined before invocation.");
    Console.WriteLine("Stack Trace:");
    Console.WriteLine("   at Simulation.CreateEntity(String name)");
    Console.WriteLine("   at Simulation.InitializeWorld()");
    Console.WriteLine("   at Simulation.Main()");
    Console.ForegroundColor = ConsoleColor.Gray;
    InsertPrompt(); Thread.Sleep(10);
    TextScatterAnimation(".\\CreateObjects.ps1 --suppress-errors --force-creation", 0.5, 10, ConsoleColor.Gray);
    Console.WriteLine();
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
}

void AnimateWorldCreation()
{
    string[] asciiArt = new string[]
    {
    ".    .    *  .   .  .   .  *     .  .        . .   .     .  *   .     .  .   .",
    "*  .    .    *  .     .         .    * .     .  *  .    .   .   *   . .    .",
    ". *      .   .    .  .     .  *      .      .        .     .-o--.   .    *  .",
    ".  .        .     .     .      .    .     *      *   .    :O o O :      .     .",
    "____   *   .    .      .   .           .  .   .      .    : O. Oo;    .   .",
    "`. ````.---...___      .      *    .      .       .   * .  `-.O-'  .     * . .",
    "\\_    ;   \\`.-'```--..__.       .    .      * .     .       .     .        .",
    ",'_,-' _,-'             ``--._    .   *   .   .  .       .   *   .     .  .",
    "-'  ,-'                       `-._ *     .       .   *  .           .    .",
    "    ,-'            _,-._          ,`-. .    .   .     .      .     *    .   .",
    "    '--.     _ _.._`-.  `-._       |   `_   .      *  .    .   .     .  .    .",
    "        ;  ,' ' _  `._`._   `.      `,-''  `-.     .    .     .    .      .  .",
    "    ,-'   \\    `;.   `. ;`   `._  _/\\___     `.       .    *     .    . *",
    "    \\      \\ ,  `-'    )        `':_  ; \\      `. . *     .        .    .    *",
    "    \\    _; `       ,;               __;        `. .           .   .     . .  .",
    "    '-.;        __,  `   _,-'-.--'''  \\-:        `.   *   .    .  .   *   . .",
    "        )`-..---'   `---''              \\ `.        . .   .  .       . .  .  ."
    };
    InsertPrompt(); TextScatterAnimation(".\\SetupNewWorld --suppress-errors --force-creation", 0.5, 10, ConsoleColor.Gray);
    Console.WriteLine();
    Console.WriteLine();
    TextTypingAnimation("******************************************************************************", 0.05, false, ConsoleColor.Gray);
    Console.WriteLine();
    foreach (string line in asciiArt)
    {
        Console.WriteLine(line);
        Thread.Sleep(20); 
    }
    TextTypingAnimation("******************************************************************************", 0.05, false, ConsoleColor.Gray);
    Thread.Sleep(20);
    Console.WriteLine();
    Thread.Sleep(20);
    Console.WriteLine("Creating New Virtual World...\n");
    Thread.Sleep(20);
    LoadingAnimation(15);
}

void LoadingAnimation (float duration)
{
    Console.CursorVisible = false;
    Stopwatch stopwatch = Stopwatch.StartNew();
    string[] genText = new string[]
    {
        "Generating Virtual World...                  ",
        "Supressing Unstable Error..                  ",
        "Binding Identities: You <-> Me..             ",
        "Entity 'You' found. Waiting for 'Me'...      ",
        "Entity 'Me' cannot be found. Trying Again... ",
        "Establishing Emotional Link Layer...         "
    };

    char[] spinner = new char[]
    {
        '|', '/', '-', '\\'
    };

    int i = 0;
    int spinnerFrame = 0;

    while (stopwatch.Elapsed.TotalSeconds < duration)
    {
        if (i >= 100)
        {
            Console.Write("Cleaning up...                               ");
        } 
        else if (i % 3 == 0)
        {
            Console.Write(genText[ran.Next(0, 5)]);
        } else
        {
            Console.SetCursorPosition(45, Console.CursorTop);
        }

        if (spinnerFrame > 3)
        {
            spinnerFrame = 0;
        }
        Console.WriteLine(spinner[spinnerFrame]);
        spinnerFrame++;

        Console.Write("Loading... [");

        for (int j = 0; j < 100; j++)
        {
            if (j <= i)
            {
                Console.Write("=");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.Write("]");
        if (i > 100)
        {
            i = 100;
        }
        Console.Write(" " + i + "%");
        Thread.Sleep((int)((duration/100)*900));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        i++;
    }

    Console.SetCursorPosition(0, Console.CursorTop + 1);
    Console.Write("Loading... [");
    for (int j = 0; j <= 100; j++)
    {
        if (j <= i)
        {
            Console.Write("=");
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.Write("]");
    Console.WriteLine(" 100% DONE!");

    // mfw when I'm too lazy to fix the desync issue, I just hardcode it lmao.

    Console.WriteLine("\n// Virtual World has been generated at W:\\Execute\\Me\\VirtualWorld");Thread.Sleep(10);
    Console.WriteLine("// NOTE: 1 object/s bas been unsafely created!"); Thread.Sleep(10);
    Console.WriteLine("// Proceed with Risk!\n"); Thread.Sleep(10);
    Console.WriteLine("Launcing Virtual World..."); Thread.Sleep(10);
    Console.Write("Welcome... You and "); Thread.Sleep(100);
    TextScatterAnimation("Me", 1, 10, ConsoleColor.Red);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("\n\n\n\n\n\n\n\n");
    Thread.Sleep(5000);

}