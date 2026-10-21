namespace Latypova
{
    public struct StudentStruct
    {
        public string LastName;
        public string FirstName;
        public int BirthYear;
        public string ExamName;
        public int Score;

        public StudentStruct(string lastName, string firstName, int birthYear, string examName, int score)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthYear = birthYear;
            ExamName = examName;
            Score = score;
        }
        public override string ToString()
        {
            return $"{LastName,-15} {FirstName,-10}  Год: {BirthYear}  Экзамен: {ExamName,-12}  Баллы: {Score,3}";
        }
    }
}
