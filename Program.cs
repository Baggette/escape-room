
namespace escape_room;

internal class Program
{

    static void Main(string[] args)
    {
        var ai = new Ai();
        //Console.WriteLine("temp just beacuse don't want to waste api requests");
        Console.WriteLine(ai.Prompt("Generate a cool name for an escape room and welcome the user to it, do not use the word enigma, keep it short just a basic welcome, ensure you made up a name for the escape room"));
        Console.WriteLine();

        var challenge = new challenge_1();
        challenge.Challenge1();
        //print to console what the output was

    }
}
