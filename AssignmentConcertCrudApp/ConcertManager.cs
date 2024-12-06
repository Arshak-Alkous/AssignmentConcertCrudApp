using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentConcertCrudApp
{
    public class ConcertManager
    {
       private List<Concert> concerts = new List<Concert>();
     private ConcertFile concertFile=new ConcertFile();
        
        public ConcertManager()
        {
            //Concert concert1 = new Concert(1, "malmoConcert", "Memo", "300", "24Aug2024");
            // Concert concert2 = new Concert(2, "stockholmConcert", "jjj", "250", "20Sept2024");
            // concerts.Add(concert1);
            // concerts.Add(concert2);
            // concertFile.WriteConcertToFile(concerts);
            try { concerts = concertFile.ReadConcertFromFile(); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public void AddConcert()
        {
            int id; string place; string performer; string capacity; string date;
            Console.WriteLine("Pleas enter the Id of concert \n");
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Pleas enter the place of concert \n");
                place = Console.ReadLine() ?? "Almhult";
                Console.WriteLine("Pleas enter the performer of concert \n");
                performer = Console.ReadLine() ?? "empty";
                Console.WriteLine("Pleas enter the capacity of concert \n");
                capacity = Console.ReadLine() ?? "100";
                Console.WriteLine("Pleas enter the date of concert \n");
                date = Console.ReadLine() ?? "";
                Concert concert = new Concert(id, place, performer, capacity, date);
                concerts.Add(concert);
                //Add to file 
                concertFile.WriteConcertToFile(concerts);
                Console.WriteLine("Adding successful");
            }
            else { Console.WriteLine("pleas enter numeric value");}
            
        }
        public void ShowConcert()
        {
            Console.WriteLine("Concerts available :");
            foreach (Concert item in concerts) 
                Console.WriteLine(Convert.ToString(item.Id) + " , Place: " + item.Place + ", Performer: " + item.Performer + ", Capacity: " + item.Capacity + ", Date: " + item.Date);
        }

        public void EditConcert()
        {
            Console.WriteLine("Pleas enter the Id of concert that would you like edit \n");
            string input1 = Console.ReadLine();
            if (int.TryParse(input1, out int inputIdToedit))
            {
                Concert concertToEdit = concerts.Find(x => x.Id == inputIdToedit);
                if (concertToEdit != null)
                {
                    Console.WriteLine(" Press 1 to edit place  \n Press 2 to edit performer \n press 3 to edit capacity \n press 4 to edit date \n ");
                    string choice2 = Console.ReadLine();
                    switch (choice2)
                    {
                        case "1":
                            Console.WriteLine(" Enter new Place: ");
                            concertToEdit.Place = Console.ReadLine() ?? "";
                            Console.WriteLine("Place updated successfully.");
                            break;
                        case "2":
                            Console.WriteLine(" Enter new Performer: ");
                            concertToEdit.Performer = Console.ReadLine() ?? "";
                            Console.WriteLine("Performer updated successfully.");
                            break;
                        case "3":
                            Console.WriteLine(" Enter new Capacity: ");
                            concertToEdit.Capacity = Console.ReadLine() ?? "";
                            Console.WriteLine("Capacity updated successfully.");
                            break;
                        case "4":
                            Console.WriteLine(" Enter new Date: ");
                            concertToEdit.Date = Console.ReadLine() ?? "";
                            Console.WriteLine(" Date updated successfully.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. No changes were made.");
                            break;
                    }
                }
                else Console.WriteLine("Concert with this id  not found");
            }
            else Console.WriteLine("Please enter valid id  to edit.");
            //edit file 
            concertFile.WriteConcertToFile(concerts);
        }
        public void RemoveConcert()
        {
            Console.WriteLine("Pleas enter the Id of concert that would you like delet from list \n");
            string input2 = Console.ReadLine();
            if (int.TryParse(input2, out int inputIdToDelet))
            {
                Concert concertToDelet = concerts.Find(x => x.Id == inputIdToDelet);
                if (concertToDelet != null)
                {
                    concerts.Remove(concertToDelet);
                    Console.WriteLine("Concert deleted");
                }
                else Console.WriteLine("Concert with this id  not found");
            }
            else Console.WriteLine("Please enter valid id to delete.");
            // remove from file 
            concertFile.WriteConcertToFile(concerts);
        }
    }
}
