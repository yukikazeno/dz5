namespace Latypova
{
    public struct HospitalStruct
    {
        public string Name;
        public int Capacity;
        public HashSet<string> TreatableDiseases;
        public List<GrandmaStruct> Patients;

        public HospitalStruct(string name, int capacity, string[] diseases)
        {
            Name = name;
            Capacity = capacity;
            TreatableDiseases = new HashSet<string>(diseases, StringComparer.OrdinalIgnoreCase);
            Patients = new List<GrandmaStruct>();
        }
        public double FullnessPercentage => (double)Patients.Count / Capacity * 100;

    }
}
