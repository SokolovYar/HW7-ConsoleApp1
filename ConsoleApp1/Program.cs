using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
         public enum GANRE { COMEDY, HORROR, MUSICAL, CLASSIC }
        /*  public static class GANRE // Пытался перегрузить метод ToString() для ENUM, но не вышло..
          {

              public static string ToStr1(this GANRE it)
              {
                  switch (it)
                  {
                      case GANRE.COMEDY:
                          return "COMEDY";
                      case GANRE.HORROR:
                          return "HORROR";
                      case GANRE.MUSICAL:
                          return "MUSICAL";
                      case GANRE.CLASSIC:
                          return "CLASSIC";
                      default:
                          throw new ArgumentOutOfRangeException();
                  }
              }
          }*/

        internal class Play : IDisposable
        {
            
            private GANRE _ganre;
            public string Name { get; set; }
            public string Author { get; set; }
            public GANRE Ganre { get { return _ganre; } set { _ganre = value; } }
            public Play()
            {

            }
            public Play (string name, string author, GANRE ganre)
            {
                Name = name;
                Author = author;
                _ganre = ganre;
            }
            public override string ToString()
            {
                string temp = $"Name: {Name ?? "NoName"}, author: {Author ?? "NoData"}, ganre: ";
                switch (_ganre)
                    {
                      case GANRE.COMEDY :
                          temp += "COMEDY";
                    break;
                      case GANRE.HORROR:
                          temp += "HORROR";
                    break;
                      case GANRE.MUSICAL:
                          temp += "MUSICAL";
                    break;
                      case GANRE.CLASSIC:
                          temp += "CLASSIC";
                    break;
                    default:
                          temp += "NoData";
                    break;
                }
                return temp;
            }

            public void Dispose()
            {
                Console.WriteLine("Resources has been released");
            }
        }

        static void Main(string[] args)
        {
            Play[] Repertoire = new Play[10];
            for (int i = 0; i < 10; i++)
                using (Repertoire[i] = new Play())  //работа через using
                {
                    Console.WriteLine("Play has been created");
                }

            Console.WriteLine();        //очистка через прямой вызов
            Play OnTheBottom = new Play("On the bottom", "M. Gorkiy", GANRE.CLASSIC);
            Console.WriteLine(OnTheBottom);
            OnTheBottom.Dispose();
        }
    }
}
