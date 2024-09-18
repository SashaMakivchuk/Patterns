using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace patterns_lab_1 { 
// Варіант 7. Клас відстеження помилок, який повинна існувати в єдиному екземплярі. Реалізовувати методи:
//1) Фіксування помилки(Час, код, текст з описом помилки)
//2) Очищення історії помилок.
//3) Вивід інформації про всі помилки
//4) Збереження історії помилок до файлу.
    public class ErrTrack
    {
        private static ErrTrack _instance;
        private List<Error> _tracks;
        private ErrTrack()
        {
            _tracks = new List<Error>();
        }
        public static ErrTrack Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrTrack();
                }
                return _instance;
            }
        }
        public void LogErr(int code, string msg)
        {
            var err = new Error
            {
                Time = DateTime.Now,
                Code = code,
                Msg = msg
            };
            _tracks.Add(err);
            Console.WriteLine(err);
        }
        public void Print()
        {
            if( _tracks.Count == 0 )
            {
                Console.WriteLine("No err");
                return;
            }

            foreach( var err in _tracks )
            {
                Console.WriteLine($"{err.Time}- Code {err.Code}\n Message{err.Msg}");
            }
        }
        public void Clear()
        {
            _tracks.Clear();
            Console.WriteLine("Clear");
        }
        public void File(string path)
        {
            using (StreamWriter write = new StreamWriter(path,true))
            {
                foreach (var err in _tracks)
                {
                    write.WriteLine($"{err.Time}- Code {err.Code}\n Message{err.Msg}");
                }
                write.Close();
            }
            Console.WriteLine("Safe");
        }



        private class Error
        {
            public DateTime Time { get; set; }
            public int Code { get; set; }
            public string Msg { get; set; }
            public override string ToString()
            {
                return $"{Time}- Code {Code}\n Message{Msg}";
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var track = ErrTrack.Instance;
            track.LogErr(13, "somethidn");
            track.LogErr(13, "somethidn23");
            track.LogErr(13, "somethidn24");

            track.Print();
            string filePath = "C:\\Users\\MSI\\source\\lab Patterns\\patterns lab 1\\patterns lab 1\\log.txt";
            track.File(filePath);
            track.Clear();
            track.Print();
            
            Console.ReadLine();
        }
    }


    
}
