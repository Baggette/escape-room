
namespace escape_room;

public class Program
{
    public static IDictionary<string, DateTime> time = new Dictionary<string, DateTime>() { {"time", DateTime.Now} };

    public void Failure(string challenge)
    { 
        DateTime end = DateTime.Now;
        TimeSpan elapsedTime = end - time["time"];
        //clear the console
        Console.Clear();

        Console.WriteLine("You failed to escape. You made it up to " + challenge + " and you spent " + elapsedTime.TotalHours + "H " + elapsedTime.TotalMinutes + "M " + elapsedTime.TotalSeconds + "S ");
    }
    public static void Main(string[] args)
    {
        var ai = new api.Ai();
        //Console.WriteLine("temp just beacuse don't want to waste api requests");
        Console.WriteLine(ai.Prompt("Generate a cool name for an escape room and welcome the user to it, do not use the word enigma, keep it short just a basic welcome, ensure you made up a name for the escape room and tell the user to press enter to continue"));
        Console.WriteLine();
        //wait for the user to press enter before continuing
        Console.ReadKey();

        //start the timer
        DateTime start = DateTime.Now;
        time["time"] = start;

        var challenge = new Challenges.challenge_1();
        challenge.Challenge1();
        //print to console what the output was

    }
}
