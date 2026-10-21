namespace Latypova
{
    public struct GrandmaStruct
    {
        public string Name { get; }
        public int Age { get; }
        public Dictionary<string, string> Diseases { get; }

        public GrandmaStruct(string name, int age, Dictionary<string, string> diseases)
        {
            Name = name;
            Age = age;
            Diseases = diseases ?? new Dictionary<string, string>();
        }
    }
}
