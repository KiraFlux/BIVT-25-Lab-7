using Lab7.CW.Mob;

var less_land_factory = new CharacterFactory("LessLand");
var miner_factory = new CharacterFactory("Mines");

Character[] c = [
    less_land_factory.Dummy(),
    less_land_factory.Dummy("picklesser"),
    miner_factory.Dummy("pickaxer1"),
    miner_factory.Dummy("pickaxer0"),
];

foreach (var i in c)
{
    Console.WriteLine(i);
}