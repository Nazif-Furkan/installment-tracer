using Newtonsoft.Json;

namespace AylikTaksit.Api.Currecies;

public class GoldCurrency
{
    public  static async Task<GoldCurrency> GetGoldCurrency()
    {
        var client = new HttpClient();
        var json = await (await client.GetAsync("https://api.genelpara.com/embed/altin.json"))
            .Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GoldCurrency>(json);
        return result;
    }
    public GramAltinDto GA { get; set; }
}

public class GramAltinDto
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}