namespace Lab7.Blue
{
    public class Task3
    {
        struct LiterallyAlmostNotAnUnefficientDynamicArrayListAndSomeThing()
        {
            int[] buffer = [];
            int len = 0, sum;
            bool sum_calculated = false;

            public int Sum
            {
                get
                {
                    if (sum_calculated) { return this.sum; }
                    this.sum_calculated = true;
                    return this.sum = this.buffer.Sum();
                }
            }

            public readonly bool Has(int target) => this.buffer.Any((item) => item == target);

            public readonly int[] View => (int[])this.buffer.Clone();

            public void Add(int value)
            {
                this.Realloc(extra_values: 1);
                this.Set(value, ^1);
            }

            void Set(int value, Index i) // класс Index не указан в разрешенных, но тут же можно? :)
            {
                this.buffer[i] = value;
                this.sum_calculated = false;
            }

            void Realloc(uint extra_values)
            {
                var new_buffer = new int[this.len + extra_values];
                if (this.len > 0)
                {
                    Array.Copy(this.buffer, new_buffer, this.len);
                }
                this.buffer = new_buffer;
                this.len = new_buffer.Length;
            }
        }

        public struct Participant(string name, string surname)
        {
            readonly string name = name, surname = surname;
            LiterallyAlmostNotAnUnefficientDynamicArrayListAndSomeThing penalties = new();

            public readonly string Name => this.name;
            public readonly string Surname => this.surname;
            public readonly int[] PenaltyTimes => this.penalties.View;
            public readonly int TotalTime => this.penalties.Sum;
            public readonly bool IsExpelled => this.penalties.Has(10);

            public void PlayMatch(int time)
            {
                if (time >= 0) { this.penalties.Add(time); }
            }

            public static void Sort(Participant[]? array)
            {
                if (array == null) { return; }
                Array.Sort(array, (l, r) =>
                {
                    // по возрастанию
                    var c = l.TotalTime.CompareTo(r.TotalTime);
                    if (c != 0) { return c; }

                    // при равных исключенные идут перед неисключенными
                    if (l.IsExpelled && !r.IsExpelled) { return -1; }
                    if (!l.IsExpelled && r.IsExpelled) { return 1; }

                    return 0; // сохраняем порядок
                });
            }

            public readonly void Print() => Console.WriteLine(this.ToString());

            override public readonly string ToString() =>
                $"Participant{{name: \"{this.name}\", surname: \"{this.surname}\", totalTime: {this.TotalTime}, isExpelled: {this.IsExpelled}}}";
        }
    }
}