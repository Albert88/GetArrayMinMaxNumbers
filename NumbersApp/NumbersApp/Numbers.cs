using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersApp
{
    public class Numbers
    {
        private List<int> IntList { get; set; }
        private List<double> DoubleList { get; set; }
        private List<float> FloatList { get; set; }

        private Tuple<int, int> minMaxInt;
        private Tuple<float, float> minMaxFloat;
        private Tuple<double, double> minMaxDouble;

        public Numbers()
        {
            this.IntList = new List<int>();
            this.DoubleList = new List<double>();
            this.FloatList = new List<float>();
        }

        public void Start()
        {
            Get3Arrays();

            FindSmallestAndBiggestNumbersOfArrays();

            PrintSmallestAndBiggestNumbersOfArrays();

            Clear();
        }

        public static void StartProgram()
        {
            Numbers numbers = new Numbers();

            numbers.Start();
        }

        private void Clear()
        {
            this.IntList.Clear();
            this.DoubleList.Clear();
            this.FloatList.Clear();

            minMaxInt = null;
            minMaxFloat = null;
            minMaxDouble = null;

        }

        private void PrintSmallestAndBiggestNumbersOfArrays()
        {
            Console.WriteLine("Integers");
            if (this.IntList.Count > 0)
            {
                foreach (var num in this.IntList)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine($"Min {this.minMaxInt.Item1}, Max {this.minMaxInt.Item2}");
                Console.WriteLine("_________________________________");
            }
            else
            {
                Console.WriteLine("Integers array is empty");
                Console.WriteLine("_________________________________");
            }

            Console.WriteLine("Doubles");
            if (this.DoubleList.Count > 0)
            {
                foreach (var num in this.DoubleList)
                {
                    Console.Write(num + " ");
                }

                if (this.minMaxDouble != null)
                {

                    Console.WriteLine($"Min {this.minMaxDouble.Item1}, Max {this.minMaxDouble.Item2}");
                    Console.WriteLine("_________________________________");
                }
            }
            else
            {
                Console.WriteLine("Doubles array is empty");
                Console.WriteLine("_________________________________");
            }


            Console.WriteLine("Floats");
            if (this.FloatList.Count > 0)
            {
                foreach (var num in this.FloatList)
                {
                    Console.Write(num + " ");
                }

                Console.WriteLine($"Min {this.minMaxFloat.Item1}, Max {this.minMaxFloat.Item2}");
                Console.WriteLine("_________________________________");
            }
            else
            {
                Console.WriteLine("Floats array is empty");
                Console.WriteLine("_________________________________");
            }

            Console.ReadLine();
        }

        private void FindSmallestAndBiggestNumbersOfArrays()
        {
            this.minMaxInt = GetIntMinMax();
            this.minMaxDouble = GetDoubleMinMax();
            this.minMaxFloat = GetFloatMinMax();
        }

        private void Get3Arrays()
        {
            string[] strNumbers = ReadNumbers();
            
            CreateArrays(strNumbers);
        }

        private string[] ReadNumbers()
        {
            string[] numbers = new string[0];
            Console.WriteLine("Enter numbers integer (i) ,double (d), float (f). Space as delimeter.");
            Console.WriteLine("Example - 1i 2i 3i 5.6d 4.9f");            

            string input = Console.ReadLine();


            if (input != null && input.Length > 0)
            {
                numbers = input.Trim().Split(' ');
            }

            return numbers;
        }


        private Tuple<int, int> GetIntMinMax()
        {
            Tuple<int, int> iTuple = null;

            if (this.IntList.Count > 0)
            {
                int minNumber = this.IntList[0];
                int maxNumber = this.IntList[0];

                for (int i = 1; i < this.IntList.Count; i++)
                {
                    if (minNumber > this.IntList[i])
                    {
                        minNumber = this.IntList[i];
                    }
                    if (maxNumber < this.IntList[i])
                    {
                        maxNumber = this.IntList[i];
                    }
                }
                iTuple = new Tuple<int, int>(minNumber, maxNumber);
            }
            return iTuple;
        }

        private Tuple<double, double> GetDoubleMinMax()
        {
            Tuple<double, double> dTuple = null;

            if (this.DoubleList.Count > 0)
            {
                double minNumber = this.DoubleList[0];
                double maxNumber = this.DoubleList[0];

                for (int i = 1; i < this.DoubleList.Count; i++)
                {
                    if (minNumber > this.DoubleList[i])
                    {
                        minNumber = this.DoubleList[i];
                    }
                    if (maxNumber < this.DoubleList[i])
                    {
                        maxNumber = this.DoubleList[i];
                    }
                }

                dTuple = new Tuple<double, double>(minNumber, maxNumber);
            }

            return dTuple;
        }

        private Tuple<float, float> GetFloatMinMax()
        {

            Tuple<float, float> fTuple = null;

            if (this.FloatList.Count > 0)
            {
                float minNumber = this.FloatList[0];
                float maxNumber = this.FloatList[0];

                for (int i = 1; i < this.FloatList.Count; i++)
                {
                    if (minNumber > this.FloatList[i])
                    {
                        minNumber = this.FloatList[i];
                    }
                    if (maxNumber < this.FloatList[i])
                    {
                        maxNumber = this.FloatList[i];
                    }
                }
                fTuple = new Tuple<float, float>(minNumber, maxNumber);
            }

            return fTuple;
        }

        #region private methods
        private void CreateArrays(string[] strNumbers)
        {
            int numInt;
            float numFloat;
            double numDouble;

            foreach (string strNumber in strNumbers)
            {
                if (TryParseInteger(strNumber, out numInt))
                {
                    this.IntList.Add(numInt);
                }
                else if (TryParseDouble(strNumber, out numDouble))
                {
                    this.DoubleList.Add(numDouble);
                }
                else if (TryParseFloat(strNumber, out numFloat))
                {
                    this.FloatList.Add(numFloat);
                }
            }
        }

        private bool TryParseInteger(string number, out int value)
        {
            if (number[number.Length - 1] == 'i')
            {
                string str = number.Substring(0, number.Length - 1);
                return int.TryParse(str, out value);
            }
            value = 0;
            return false;
        }

        private bool TryParseDouble(string number, out double value)
        {
            if (number[number.Length - 1] == 'd')
            {
                string str = number.Substring(0, number.Length - 1);
                return double.TryParse(str, out value);
            }
            value = 0;
            return false;
        }

        private bool TryParseFloat(string number, out float value)
        {
            if (number[number.Length - 1] == 'f')
            {
                string str = number.Substring(0, number.Length - 1);
                return float.TryParse(str, out value);
            }
            value = 0;
            return false;
        }
        #endregion

    }
}
