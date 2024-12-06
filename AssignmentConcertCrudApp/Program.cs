// See https://aka.ms/new-console-template for more information
using AssignmentConcertCrudApp;

Console.WriteLine("Welcome to Concert Manager");
UseConcertManager();
void UseConcertManager()
{
    ConcertManager concertManager = new ConcertManager();
    bool run=true;
    while (run)
    {
    
    Console.WriteLine(" Press 1 to Add Concert \n Press 2 to get list of all concerts \n press 3 to edit a value for an individual concert \n press 4 to delet a certain concert \n press 5 to finish \n  ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":concertManager.AddConcert();break;
        case "2":concertManager.ShowConcert();break;
        case "3":concertManager.EditConcert();break;
        case "4":concertManager.RemoveConcert();break;
        case "5":  run = false;break;
        default:Console.WriteLine("Invalid number");break;
        }
    }
    Console.WriteLine("The Program is finished");
}