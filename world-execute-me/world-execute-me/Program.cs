using System.Diagnostics;

Random ran = new Random();
// TextAnimationRandomized(2, "Hello World!", 100);
TextTypingAnimation("Hello there, ", 0.5, false);
TextScatterAnimation("Austin", 1, 10, true);

void TextScatterAnimation(string text, int duration, int animationSpeed, bool highlight)
{
    int stringLength = text.Length;
    Stopwatch stopwatch = Stopwatch.StartNew();

    while (stopwatch.Elapsed.TotalSeconds < duration) // duration is in seconds, animationSpeed is in miliseconds
    {
        Console.Write(RandomAsciiString(stringLength));
        Thread.Sleep(animationSpeed);
        Console.SetCursorPosition(Console.CursorLeft - stringLength, Console.CursorTop);
    }

    Console.CursorVisible = true;

    if (highlight)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.White;
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
        Console.ForegroundColor = ConsoleColor.White;
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