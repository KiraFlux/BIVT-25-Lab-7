namespace Lab7.CW.Mob
{
    struct Character(string spec, string name)
    {

        public enum Color
        {
            Color0, Color1, Color2, Color3, Default
        }

        public readonly string spec = spec, name = name;
        public Color color = Color.Default;

        override public readonly string ToString() => $"{typeof(Character)}{{ name: {this.name}, biome: {this.spec} }}";
    }
}