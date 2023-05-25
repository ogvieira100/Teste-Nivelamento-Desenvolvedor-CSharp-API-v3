using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Questao2;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

public class Program
{

    static HttpClient _httpClient;

    public static async Task Main(string[] args)
    {
        initHttp();

        string teamName = "Paris Saint-Germain";
        int year = 2013;

        var totalGoals = await getTotalScoredGoals(teamName, year);
        showResults(teamName, year, totalGoals);

        teamName = "Chelsea";
        year = 2014;

        totalGoals = await getTotalScoredGoals(teamName, year);
        showResults(teamName, year, totalGoals);

       //fiz a contagem na api esses valores estão errados

        // Output acept:
        // Team Paris Saint - Germain scored 109 goals in 2013 
        // Team Chelsea scored 92 goals in 2014
    }

    static void showResults(string teamName, int year, int totalGoals)
    => Console.WriteLine("Team " + teamName + " scored " + totalGoals + " goals in " + year);
        
    

    static void initHttp()
    {
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .BuildServiceProvider();

        var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        _httpClient = httpClientFactory.CreateClient();
    }

    async static Task<(Pagination<List<FootballMatches>>?, bool)> loopPagesFootballMatches(string url)
    {
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return (null, false);

        var content = await response.Content.ReadAsStringAsync();
        return (JsonConvert.DeserializeObject<Pagination<List<FootballMatches>>>(content), true);
    }
    public async static Task<int> getTotalScoredGoals(string team, int year, int page = 1)
    {

        var resp = await loopPagesFootballMatches($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}");
        var totalGoals = 0;
        if (resp.Item2)
        {
            var totalPages = resp.Item1.Total_Pages;
            totalPages = totalPages < 1 ? 1 : totalPages;
            totalGoals += resp.Item1.Data.Sum(x => x.Team1Goals );
            while (totalPages > 1)
            {
                resp = await loopPagesFootballMatches($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={totalPages}");
                if (resp.Item2)
                    totalGoals += resp.Item1.Data.Sum(x => x.Team1Goals );

                totalPages--;
            }
        }
        return totalGoals;
      }

}