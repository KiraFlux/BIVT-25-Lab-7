namespace Lab7.Blue
{
    public class Task4
    {
        struct AlmostListOfInts
        {
            int[] buffer = [];
            int len = 0, sum;
            bool sum_calculated = false;

            public AlmostListOfInts() { }

            public int Sum
            {
                get
                {
                    if (sum_calculated) { return sum; }
                    sum_calculated = true;
                    return sum = buffer.Sum();
                }
            }

            public readonly bool Has(int target) => buffer.Contains(target);
            public readonly int[] View
            {
                get
                {
                    var copy = new int[len];
                    Array.Copy(buffer, copy, len);
                    return copy;
                }
            }
            public void Add(int value)
            {
                Realloc(1);
                buffer[len - 1] = value;
                sum_calculated = false;
            }

            void Realloc(uint extra)
            {
                var new_buffer = new int[len + extra];
                if (len > 0) { Array.Copy(buffer, new_buffer, len); }
                buffer = new_buffer;
                len = buffer.Length;
            }
        }

        public struct Team(string name)
        {
            readonly string name = name;
            AlmostListOfInts scores = new();

            public readonly string Name => name;
            public readonly int[] Scores => scores.View;
            public readonly int TotalScore => scores.Sum;

            public void PlayMatch(int result) => scores.Add(result);
            public readonly void Print() => Console.WriteLine(ToString());
            public override readonly string ToString() =>
                $"Team{{Name: \"{name}\", Scores: [{string.Join(", ", Scores)}], TotalScore: {TotalScore}}}";
        }

        public struct Group(string name)
        {
            readonly string name = name;
            readonly Team[] teams = new Team[12];
            int count = 0;

            public readonly string Name => name;
            public readonly Team[] Teams => (Team[])teams.Clone();

            public void Add(Team t)
            {
                if (count >= 12) { return; }
                teams[count] = t;
                count += 1;
            }

            public void Add(Team[]? ts)
            {
                if (ts == null) { return; }

                for (int i = 0; i < ts.Length && count < 12; i += 1)
                {
                    teams[count] = ts[i];
                    count += 1;
                }
            }

            public readonly void Sort() => Array.Sort(teams, (l, r) => r.TotalScore.CompareTo(l.TotalScore));

            public readonly void Print() => Console.WriteLine(ToString());

            public override readonly string ToString() =>
                $"Group{{Name: \"{name}\", Teams: [{string.Join(", ", Teams.Select(t => t.Name))}]}}";

            public static Group Merge(Group a, Group b, int size)
            {
                var combined = new Team[12];
                int idx = 0;
                for (int i = 0; i < 6; i++) { combined[idx++] = a.teams[i]; }
                for (int i = 0; i < 6; i++) { combined[idx++] = b.teams[i]; }

                Array.Sort(combined, (l, r) => r.TotalScore.CompareTo(l.TotalScore));

                var ret = new Group("Финалисты");
                for (int i = 0; i < idx && ret.count < size; i++) { ret.Add(combined[i]); }
                return ret;
            }
        }
    }
}