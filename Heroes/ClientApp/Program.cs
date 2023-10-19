using ServerApp.Models;
using System.Net;

var client = new HttpClient { BaseAddress = new Uri("http://localhost:44348/") };

await DisplayAllHeroes();
await DisplayHeroesByUniverse("DC");
await DisplayStrongestHero();

async Task DisplayAllHeroes()
{
    Console.WriteLine("1. Все герои:");
    var heroes = await GetHeroesFromApi("api/heroes");
    foreach (var hero in heroes)
    {
        Console.WriteLine(hero);
    }
}

async Task DisplayHeroesByUniverse(string universeName)
{
    Console.WriteLine($"\n2. Герои вселенной {universeName}:");
    var heroes = await GetHeroesFromApi($"api/heroes/universe/{universeName}");
    foreach (var hero in heroes)
    {
        Console.WriteLine(hero);
    }
}

async Task DisplayStrongestHero()
{
    Console.WriteLine("\n3. Самый сильный герой вселенной:");
    var hero = await GetStringFromApi("api/heroes/strongest");
    Console.WriteLine(hero);
}

async Task<Superhero[]> GetHeroesFromApi(string endpoint)
{
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
    var response = await client.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();
    var responseBody = await response.Content.ReadAsStringAsync();
    return JsonSerializer.Deserialize<Superhero[]>(responseBody);
}

async Task<string> GetStringFromApi(string endpoint)
{
    var response = await client.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsStringAsync();
}
