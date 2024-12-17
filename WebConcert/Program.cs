using AssignmentConcertCrudApp;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
ConcertManager concertManager = new ConcertManager();
app.MapGet("/favicon.ico", () => Results.NotFound());
app.MapPost("/adding concert", async(HttpRequest request) => 
{
    var form = await request.ReadFormAsync();
    int id;
    var place = form["place"];
    var performer = form["performer"];
    var capacity = form["capacity"];
    var date=form["date"].ToString();
    if (int.TryParse(form["number"],out id)) 
    {
        Concert newconcert = new Concert(id, place, performer, capacity, date);
       
        concertManager.AddConcertFromForm(newconcert);
        return $"Adding successful, place ={form["place"]}, performer = {form["performer"]}, capacity = {form["capacity"]} ,date={form["date"]}";
    }
       
    else return "something wrong";
});
app.MapGet("/concerts", () => 
{
    var concerts=Concert.GetConcertList();
    return JsonSerializer.Serialize(concerts);
});
//app.MapGet("/digit", () => 66); it doesn't work just when I view source page I can see 66

//app.MapGet("/digit", () => 54+12); it doesn't work just when I view source page I can see 66

//app.MapGet("/digit", () => 121); it work and shows in blue 

//app.MapGet("/{digit}", (int digit) => $"{digit}"); it work and shows normal in black 

//app.MapGet("/digit", (int digit) => $"{digit}"); // it doesn't work and gives me Exception 

//app.MapGet("/digit", (int digit) => { return $"{digit}"; });// it doesn't work and gives me Exception 

//app.MapGet("/digit", (int digit) => {digit = 54; return $"{digit}"; });// it doesn't work and gives me Exception 

//app.MapGet("/digit", () => { int digit = 54;  return $"{digit}"; }); // it work and shows normal in black whether the number is greater or less than 100

app.MapGet("/digit", () => { int digit1 = 54; int digit2 = 121; return $"{digit1}"+ "," + $"{digit2}"; } ); // it work and shows normal in black 
app.MapGet("/{number}", (int number) => 
{
    int x = 87;
    if (number < x)return $"the {number} is Too Loo";
    else if (number > x)return $"the {number} is Too High";
    return$"the {number} is Correct number";
});
app.MapGet("/", () => "Hello World!");

app.Run();
