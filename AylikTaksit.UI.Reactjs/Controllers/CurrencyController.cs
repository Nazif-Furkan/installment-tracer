using AylikTaksit.Api;
using AylikTaksit.Api.Currecies;
using AylikTaksit.Api.Models.Transaction;
using AylikTaksit.Business;
using Microsoft.AspNetCore.Mvc;

namespace AylikTaksit.UI.Reactjs.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CurrencyController : ControllerBase
{
    [HttpGet(Name = nameof(Gold))]
    public async Task<GoldCurrency> Gold()
    {
        return await GoldCurrency.GetGoldCurrency();
    }
    
    [HttpGet(Name = nameof(Dollar))]
    public decimal Dollar()
    {
        return Helper.DovizGoster().Dolar;
    }
}