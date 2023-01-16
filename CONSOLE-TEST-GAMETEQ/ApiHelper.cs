using System.Globalization;
using System.Net.Http.Headers;
using DB_TEST_GAMETEQ.Entity;

namespace CONSOLE_TEST_GAMETEQ;

public class ApiHelper
{
    private HttpClient _client;
    private const string Eos = "\n";
    private const string Separator = "|";

    public ApiHelper(string url)
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(url);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Rate[]> GetRates(int startYear, int finishYear)
    {
        var rates = new List<Rate>();
        var format = new CultureInfo("en-US");
        foreach (var year in Enumerable.Range(startYear, finishYear - startYear + 1))
        {
            var response = await _client.GetAsync($"financial_markets/foreign_exchange_market/exchange_rate_fixing/year.txt?year={year}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rows = content.Split(Eos).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                var firstRowItems = GetHeaderRow(rows[0]);
                foreach (var row in rows.Skip(1))
                {
                    if (row.StartsWith("Date"))
                    {
                        firstRowItems = GetHeaderRow(row);
                        continue;
                    }

                    var items = row.Split(Separator);
                    var curDate = DateTime.Parse(items[0]);
                    int count = 0;
                    foreach (var item in items.Skip(1))
                    {
                        rates.Add(new Rate
                        {
                            Currency = firstRowItems[count].Currency,
                            Value = (Convert.ToDecimal(item, format) * firstRowItems[count].Coef).ToString(),
                            Date = curDate
                        });
                        count++;
                    }
                }
            }
        }

        return rates.ToArray();
    }

    private HeaderRowItem[] GetHeaderRow(string row)
    {
        return row.Split().Skip(1).Select(x => new HeaderRowItem()
        {
            Currency = x.Split(Separator)[0], 
            Coef = x.Contains(Separator) ? Convert.ToInt32(x.Split(Separator)[1]) : 1
        }).ToArray();
    }
    
    private class HeaderRowItem
    {
        public string Currency { get; set; }
        public int Coef { get; set; }
    }
}