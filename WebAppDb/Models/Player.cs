public class Player {
    public Guid Id {get;set;}
    public string Name {get;set;}
    public int Level {get;set;}
    public Weapon Weapon {get;set;}

    public Player(Guid id, string name, int level, Weapon w)
    {
        Id = id;
        Name = name;
        Level = level;
        Weapon = w;
    }
}