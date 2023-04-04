
People[] people = {new Mariya(), new Artem()};
CheckBithday(people);
void CheckBithday(People[] people)
{
    for (int human = people.Length -1; human >= 0; human--)
    {
        if(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) == people[human].Birthday)
        {
            People[] congratulators = people.Where((val, idx) => val != people[human]).ToArray();
            for (int congratulator = 0; congratulator < congratulators.Length; congratulator++)
            {
                congratulators[congratulator].BirthdayCongratulations += (string message) => Console.WriteLine(message);
                congratulators[congratulator].Congratulations(people[human].Name);
            }
        }
    }
}
public abstract class People
{
    public delegate void GreetingHandler(string name);
    public event GreetingHandler? BirthdayCongratulations;
    public string Name { get; set;} = null!;
    public DateTime Birthday { get; set; }
    public void ActionCongratulation(string name) => BirthdayCongratulations?.Invoke(name);
    public abstract void Congratulations(string name);
}
public class Mariya : People
{
    public Mariya()
    {
        Name = "Mariya";
        Birthday = new DateTime(DateTime.Now.Year, 4, 4);
    }
    public override void Congratulations(string name) => base.ActionCongratulation($"Happy birthday, {name}!");
}
public class Artem : People
{
    public Artem()
    {
        Name = "Artem";
        Birthday = new DateTime(DateTime.Now.Year, 1, 1);
    }
    public override void Congratulations(string name) => base.ActionCongratulation($"Congratulation, {name}, on your birthday!");
}