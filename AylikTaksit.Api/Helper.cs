using System.Xml;

namespace AylikTaksit.Api;

public class Helper
{
    public static TcmbDovizResponse DovizGoster()
    {
        try
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ',')); //TODO: değeri cultureinfo ile parse et, virgül nokta değişimine gerek kalmasın
            decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
            decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

            return
            new TcmbDovizResponse()
            {
                IsUpdated = true,
                Dolar = dolar,
                Euro = euro,
                Sterlin = sterlin,
            };
        }
        catch (XmlException xml)
        {
            return new TcmbDovizResponse()
            {
                IsUpdated = false
            };
        }
    }
}

public class TcmbDovizResponse
{
    public bool IsUpdated { get; set; }
    public decimal Dolar { get; set; }
    public decimal Euro { get; set; }
    public decimal Sterlin { get; set; }
}