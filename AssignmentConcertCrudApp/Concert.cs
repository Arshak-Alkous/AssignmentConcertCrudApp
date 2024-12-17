using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConcertCrudApp
{
    public class Concert
    {
        public int Id { get;private set; }
        public string Place { get; set; }
        public string Performer { get; set; }
        public string Capacity { get; set; }
        public string Date {  get; set; }
        public Concert(int id, string place, string performer, string capacity, string date)
        {
            Id = id;
            Place = place;
            Performer = performer;
            Capacity = capacity;
            Date = date;
                
        }
        public static List<string> GetConcertList() 
        {
            return new List<string> { "con1", "con2", "con3" };
        }
        /*public  Concert AddConcert(int id, string place, string performer, string capacity, string date)
        {
            Concert concert = new Concert(id, place, performer, capacity, date);           
            return concert;
        }*/

    }
}
