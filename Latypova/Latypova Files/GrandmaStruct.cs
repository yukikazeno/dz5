namespace Latypova
{
    public struct GrandmaStruct
    {
        public string Name;
        public byte Age;
        public Dictionary<string, string> Diseases;

        public GrandmaStruct(string name, byte age, Dictionary<string, string> diseases)
        {
            Name = name;
            Age = age;
            Diseases = diseases ?? new Dictionary<string, string>();
        }
    }
}
