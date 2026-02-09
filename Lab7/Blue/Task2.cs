namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant(string name, string surname) // Тривиальный конструктор потому что можем
        {
            const int JumpsTotal = 2;
            const int JudmentsTotal = 5;

            readonly string name = name, surname = surname;
            int[,] marks = new int[JumpsTotal, JudmentsTotal];
            int jumps_done = 0;

            public readonly string Name => name;
            public readonly string Surname => surname;
            public readonly int[,]? Marks => marks == null ? null : (int[,])marks.Clone();
            public readonly int TotalScore => (marks == null) ? 0 : marks.Cast<int>().Sum();

            public void Jump(int[] result)
            {
                if (IsResultDestinationValid(result) && CanJump)
                {
                    for (int i = 0; i < JudmentsTotal; i += 1) { this.marks[this.jumps_done, i] = result[i]; }
                    this.jumps_done += 1;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array != null) { Array.Sort(array, (l, r) => r.TotalScore.CompareTo(l.TotalScore)); }
            }

            public void Print() => Console.WriteLine($"Participant{{name: \"{name}\", surname: \"{surname}\", totalScore: {TotalScore}}}");

            bool IsResultDestinationValid(int[] result) => result != null && result.Length == JudmentsTotal;

            readonly bool CanJump => this.jumps_done < JumpsTotal && this.marks != null;
        }
    }
}