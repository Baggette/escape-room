
using System.ComponentModel.DataAnnotations.Schema;

namespace escape_room;

public class Program
{
    public static IDictionary<string, DateTime> time = new Dictionary<string, DateTime>() { {"time", DateTime.Now} };

    public string hours;
    public string minutes;
    public string seconds;
    public string milliseconds;

    public void Success()
    {
        DateTime end = DateTime.Now;
        TimeSpan elapsedTime = end - time["time"];
        //clear the console
        Console.Clear();

        //remove the decimal values from the time values and format them for use later
        milliseconds = elapsedTime.TotalMilliseconds.ToString();
        milliseconds = milliseconds.Substring(0, milliseconds.IndexOf(".") + 1).TrimEnd('.');

        //this will convert miliseconds to hours, minutes and seconds repesctivily 
        long hours = Convert.ToInt64(milliseconds) / 3600000;
        long minutes = (Convert.ToInt64(milliseconds) % 3600000) / 60000;
        long seconds = ((Convert.ToInt64(milliseconds) % 3600000) % 60000) / 1000;
        long milisecs = ((Convert.ToInt64(milliseconds) % 3600000) % 60000) % 1000;

        Console.WriteLine($@"**Congratulations!!!**
You have successfully completed all of the challenges and have escaped the escape room.

It took you:
{hours} hours
{minutes} minutes
{seconds} seconds 
and 
{milisecs} miliseconds

to complete all of the challenges.
");
    }
    public void Failure(string challenge)
    {
        DateTime end = DateTime.Now;
        TimeSpan elapsedTime = end - time["time"];
        //clear the console
        Console.Clear();

        //remove the decimal values from the time values and format them for use later
        milliseconds = elapsedTime.TotalMilliseconds.ToString();
        milliseconds = milliseconds.Substring(0, milliseconds.IndexOf(".") + 1).TrimEnd('.');

        //this will convert 
        long hours = Convert.ToInt64(milliseconds) / 3600000 ;
        long minutes = (Convert.ToInt64(milliseconds) % 3600000) / 60000;
        long seconds = ((Convert.ToInt64(milliseconds) % 3600000) % 60000) / 1000;
        long milisecs = ((Convert.ToInt64(milliseconds) % 3600000) % 60000) % 1000;

        //print to console how long the user spent trying
        Console.WriteLine("You failed to escape. You made it up to " + challenge + " and you spent " + hours + " Hours " + minutes + " Minutes " + seconds + " Seconds and " + milisecs + " Milliseconds inside of the escape room");
    }
    public static void Main(string[] args)
    {
        var ai = new api.Ai();
        //Console.WriteLine("temp just beacuse don't want to waste api requests");
        Console.WriteLine("If this program seems to be stuck here close an restart, press any key to continue \n");
        Console.ReadKey();
        Console.Clear();
       // Console.WriteLine(ai.Prompt("Generate a cool name for an escape room and welcome the user to it, do not use the word enigma, keep it short just a basic welcome, ensure you made up a name for the escape room and tell the user to press enter to continue"));
        Console.WriteLine();
        //wait for the user to press enter before continuing
        Console.ReadKey();

        //start the timer
        DateTime start = DateTime.Now;
        time["time"] = start;

        //execute the first challenge
        var challenge = new Challenges.Challenge_4();
        challenge.Challenge4();

    }
}
