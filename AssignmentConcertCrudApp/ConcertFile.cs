using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConcertCrudApp
{
    public class ConcertFile
    {
        public void WriteConcertToFile(List<Concert> concerts)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("Concert.txt"))
                {
                    foreach (Concert concert in concerts)
                    {
                        writer.WriteLine(concert.Id + "," + concert.Place + "," + concert.Performer + "," + concert.Capacity + "," + concert.Date);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }
        public List<Concert> ReadConcertFromFile()
        {
            List<Concert> concerts = new List<Concert>();
            if (File.Exists("Concert.txt"))
            {
                string[] lines = File.ReadAllLines("Concert.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    if (parts.Length == 5)
                    {
                        int id = int.Parse(parts[0]);
                        string place = parts[1];
                        string performer = parts[2];
                        string capacity = parts[3];
                        string date = parts[4];
                        concerts.Add(new Concert(id, place, performer, capacity, date));
                    }
                }
            }
            return concerts;
        }
    }
}
