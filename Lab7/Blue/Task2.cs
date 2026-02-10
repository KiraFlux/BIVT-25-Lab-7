namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant(string name, string surname) // Тривиальный конструктор потому что можем
        {
            const int JumpsTotal = 2;
            const int JudmentsTotal = 5;

            readonly string name = name, surname = surname;
            readonly int[,] marks = new int[JumpsTotal, JudmentsTotal];
            int jumps_done = 0;

            public readonly string Name => this.name;
            public readonly string Surname => this.surname;
            public readonly int[,] Marks => (int[,])this.marks.Clone();
            public readonly int TotalScore => this.marks.Cast<int>().Sum();

            public void Jump(int[] result)
            {
                if (!IsResultDestinationValid(result) || !this.CanJump) { return; }
                for (int i = 0; i < JudmentsTotal; i += 1) { this.marks[this.jumps_done, i] = result[i]; }
                this.jumps_done += 1;
            }

            public static void Sort(Participant[] array)
            {
                if (array != null) { Array.Sort(array, (l, r) => r.TotalScore.CompareTo(l.TotalScore)); }
            }

            public readonly void Print() => Console.WriteLine(this.ToString());

            override public readonly string ToString() =>
                $"Participant{{name: \"{name}\", surname: \"{surname}\", TotalScore: {TotalScore}, CanJump: {CanJump}}}";

            static bool IsResultDestinationValid(int[] result) => result != null && result.Length == JudmentsTotal;

            readonly bool CanJump => this.jumps_done < JumpsTotal;
        }
    }
}