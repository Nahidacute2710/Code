using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Buổi_1
{

    class Bai1
    {
        private double[] grades;

        public Bai1(double[] scores)
        {
            grades = scores;
        }
        public double diemtrungbinh() 
        { 
            double sum = 0;
            foreach (double grade in grades)
            sum += grade;
            return grades.Length > 0 ? sum / grades.Length : 0;
            
        }
        public double diemcao()
        {
            return grades.Length > 0 ? grades.Max() : 0;
        }
        public double diemthap()
        {
            return grades.Length > 0 ? grades.Min() : 0;
        }
    }
    class Bai2
    {
        private Dictionary<string, double[]> subjects;
        public Bai2(Dictionary<string, double[]> scores)
        {
            subjects = scores;
        }
        public double diemtrungbinh(string subject)
        {
            return subjects.ContainsKey(subject) && subjects[subject].Length > 0 ? subjects[subject].Average() : 0;
        }
        public double diemcao(string subject)
        {
            return subjects.ContainsKey(subject) && subjects[subject].Length > 0 ? subjects[subject].Max() : 0;
        }
        public double diemthap(string subject)
        {
            return subjects.ContainsKey(subject) && subjects[subject].Length > 0 ? subjects[subject].Min() : 0;
        }
    }
    
        class Bai3
        {
            List<double> grades = new List<double>();
            public Bai3(List<double> scores)
            {
                grades = scores;
            }
            public double diemtrungbinh()
            {
                return grades.Count > 0 ? grades.Sum() / grades.Count : 0;
            }
            public double diemcao()
            {
                return grades.Count > 0 ? grades.Max() : 0;
            }
            public double diemthap()
            {
                return grades.Count > 0 ? grades.Min() : 0;
            }
        }
        class Bai4
        {
            private ArrayList grades = new ArrayList();
            public Bai4(ArrayList scores)
            {
                grades = new ArrayList();
                foreach (var item in scores)
                {
                    if (item is double || item is int)
                    {
                        grades.Add(Convert.ToDouble(item));
                    }
                }
            }
            public double diemtrungbinh()
            {
                if (grades.Count == 0) return 0;
                double sum = 0;
                foreach (double grade in grades)
                    sum += grade;
                return grades.Count > 0 ? sum / grades.Count : 0;
            }
            public double diemcao()
            {
                if (grades.Count == 0) return 0;
                double max = (double)grades[0];
                foreach (double grade in grades)
                    if (grade > max)
                        max = grade;
                return max;
            }
            public double diemthap()
            {
                if (grades.Count == 0) return 0;
                double min = (double)grades[0];
                foreach (double grade in grades)
                    if (grade < min)
                        min = grade;
                return min;
            }
        }
        class Program
        {
            static void dongho(Action action, string method)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();
                action();
                stopwatch.Stop();
                Console.WriteLine($"{method} thực thi trong {stopwatch.ElapsedMilliseconds}ms");
            }
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                double[] Toán = { 7, 8, 9, 10 };
                List<double> Văn = new List<double> { 7, 8, 9, 10 };
                ArrayList Anh = new ArrayList { 7, 8, 9, 10 };
                Console.WriteLine("============Array=============");
                dongho(() =>
                {
                    Bai1 tracker = new Bai1(Toán);
                    Console.WriteLine($"Điểm trung bình: {tracker.diemtrungbinh()}");
                    Console.WriteLine($"Điểm cao: {tracker.diemcao()}");
                    Console.WriteLine($"Điểm thấp: {tracker.diemthap()}");
                }, "Array");
                Console.WriteLine("============List===============");
                dongho(() =>
                {
                    Bai3 tracker = new Bai3(Văn);
                    Console.WriteLine($"Điểm trung bình: {tracker.diemtrungbinh()}");
                    Console.WriteLine($"Điểm cao: {tracker.diemcao()}");
                    Console.WriteLine($"Điểm thấp: {tracker.diemthap()}");
                }, "List");
                Console.WriteLine("=============ArrayList==========");
                dongho(() =>
                {
                    Bai4 tracker = new Bai4(Anh);
                    Console.WriteLine($"Điểm trung bình: {tracker.diemtrungbinh()}");
                    Console.WriteLine($"Điểm cao: {tracker.diemcao()}");
                    Console.WriteLine($"Điểm thấp: {tracker.diemthap()}");
                }, "ArrayList");
                Console.WriteLine("============Arrays==============");
                Dictionary<string, double[]> diem = new Dictionary<string, double[]>
                {
                    { "Toán", new double[] { 7, 8, 9, 10 }},
                    { "Văn" , new double[] { 7, 8, 9, 10 }},
                    { "Anh", new double[] { 7, 8, 9, 10 }}
                };
                
                foreach (var subject in diem.Keys)
                {
                    Bai2 tracker = new Bai2(diem);
                    Console.WriteLine($"Môn {subject}:");
                    Console.WriteLine($"- Điểm trung bình: {tracker.diemtrungbinh(subject)}");
                    Console.WriteLine($"- Điểm cao nhất: {tracker.diemcao(subject)}");
                    Console.WriteLine($"- Điểm thấp nhất: {tracker.diemthap(subject)}");
                    Console.WriteLine("----------------------");
                }
            }
        }
    
}
