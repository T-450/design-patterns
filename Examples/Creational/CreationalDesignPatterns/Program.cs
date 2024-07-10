using System.Runtime.InteropServices;
using CreationalDesignPatterns.FactoryMethod;


FactoryMethodExample();
Console.WriteLine("Press any key to exit...");

/// <summary>
/// Factory Method Usage Example
/// The program will ask for the file path. Enter star.wav as the name of the file. When the program stops execution, press any key to return to the terminal.
/// </summary>
static void FactoryMethodExample()
{
    PlayerCreator? playerFactory = default;

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
        playerFactory = new WindowsPlayerCreator();
    } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
        playerFactory = new LinuxPlayerCreator();
    } else {
        // throw new Exception($"Only Linux and Windows operating systems are supported.");
        Console.WriteLine($"Only Linux and Windows operating systems are supported.");
    }

    Console.WriteLine("Please specify the path to the file to play");
    string filePath = Console.ReadLine() ?? string.Empty;
    playerFactory?.CreatePlayer().Play(filePath);
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}