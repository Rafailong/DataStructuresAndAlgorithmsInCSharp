using System;

namespace Module2
{
    public struct Reading
    {
        public DateTime now;
        public int value;

        public Reading(DateTime now, int v) : this()
        {
            this.now = now;
            this.value = v;
        }
    }

    public static class Gauge {

        private static Random R = new Random();

        public static Reading Read() {
            return new Reading(DateTime.Now, R.Next());
        }
    }

    static class ArraySyntax {

        public static Reading[] FillReading(int size) {
            Reading[] readings = new Reading[size];
            for (int i = 0; i < size; i++)
            {
                readings[i] = Gauge.Read();
            }
            return readings;
        }

        public static void Print(Reading[] readings) {
            for (int i = 0; i < readings.Length; i++)
            {
                Reading reading = readings[i];
                string msg = $"index={i} time={reading.now.ToString()} value={reading.value}";
                Console.WriteLine(msg);
            }
        }
    }
}