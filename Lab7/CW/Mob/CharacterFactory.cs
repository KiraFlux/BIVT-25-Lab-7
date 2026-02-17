namespace Lab7.CW.Mob
{
    struct CharacterFactory(string biome)
    {
        readonly string biome = biome;

        uint created = 0;

        public Character Dummy(string spec = "homeless")
        {
            this.created += 1;
            return new($"{spec} from {this.biome}", $"npc#{this.created}");
        }
    }

}