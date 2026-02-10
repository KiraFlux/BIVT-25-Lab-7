namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            readonly string name, surname;
            int[] penalties_buffer;
            int penalties_len;

            public readonly string Name => name;
            public readonly string Surname => surname;
            public readonly int[] PenaltyTimes => ListView;

            readonly int[] ListView => (int[])penalties_buffer.Clone();

            public readonly int TotalTime
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < penalties_len; i += 1)
                    {
                        sum += penalties_buffer[i];
                    }

                    return sum;
                }
            }

            public readonly bool IsExpelled
            {
                get
                {
                    for (int i = 0; i < penalties_len; i += 1)
                    {
                        if (penalties_buffer[i] == 10)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penalties_buffer = []; // пустой массив, будет расширяться
                this.penalties_len = 0;
            }

            public void PlayMatch(int time)
            {
                if (time < 0)
                {
                    return;
                }

                // Расширяем массив на 1 элемент
                var new_len = penalties_len + 1;
                var new_buffer = new int[new_len];
                if (penalties_len > 0)
                {
                    Array.Copy(penalties_buffer, new_buffer, penalties_len);
                }

                new_buffer[penalties_len] = time;
                penalties_buffer = new_buffer;
                penalties_len += 1;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }
                Array.Sort(array, (l, r) =>
                {
                    // Сначала по возрастанию
                    int timeCompare = l.TotalTime.CompareTo(r.TotalTime);
                    if (timeCompare != 0)
                    {
                        return timeCompare;
                    }

                    // При равных исключенные идут перед неисключенными
                    if (l.IsExpelled && !r.IsExpelled)
                    {
                        return -1;
                    }

                    if (!l.IsExpelled && r.IsExpelled)
                    {
                        return 1;
                    }

                    // В остальных случаях сохраняем порядок
                    return 0;
                });
            }

            public readonly void Print() =>
                Console.WriteLine($"Participant{{name: \"{name}\", surname: \"{surname}\", totalTime: {TotalTime}, isExpelled: {IsExpelled}}}");
        }
    }
}