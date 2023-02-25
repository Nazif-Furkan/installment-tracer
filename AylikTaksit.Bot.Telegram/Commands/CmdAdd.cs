namespace AylikTaksit.Bot.Telegram;

public static class CmdAdd
{
    /// <summary>
    /// Add komutu taksit bilgisi gibi bilgileri eklemeye yarar.
    /// /add taksitBaşlığı;taksitTutarı;kaç taksit olacağı
    /// /add taksitBaşlığı;(aylık taksit tutarı)x(kaç taksit olacağı)
    ///
    /// 2. kullanım şeklindeki x ile geçmişe yönelik eklemelerin daha kolay olacağı varsayılmıştır.
    ///
    /// taksit bildirimleri basitçe böyle oluşacak,
    /// sonrasında addDetail komutu ile ilgili başlığın iD'sini girilerek ya da
    /// başlık adı girilerek(başlık adı unique olacak gibi) detay eklenebilir.
    /// 
    /// </summary>
    /// <param name="message">add komutu içeren kullıcının verdiği komuttur.</param>
    /// <returns>add komutunun cevabını döner.</returns>
    public static string Handle(string message)
    {
        var _message = message.Trim().Remove(0, 4).Trim();

        string title;
        string firstPart; 
        title = firstPart =_message.Split(';')[0];

        //secondPart oluştururken 1. kısmındaki başlığı temizleyip
        var secondPart = _message.Remove(0, 1 + firstPart.Length);

        if (secondPart.Contains('x') || secondPart.Contains('X'))
        {
            return HandleSecondPartMonthlyAmountXInstallmentCount(secondPart);
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// tutarXKalanTaksitSayısı senaryosunu yönetir.
    /// </summary>
    /// <param name="secondPart">add komutu senaryosunda başlık ayıklandıktan sonraki ikinci kısımı temsil eder.</param>
    /// <returns></returns>
    private static string HandleSecondPartMonthlyAmountXInstallmentCount(string secondPart)
    {
        var splitParameters = secondPart.Replace('X', 'x').Split('x');

        var amount = double.Parse(splitParameters[0]);
        var monthCount = int.Parse(splitParameters[1]);
        
        
        throw new NotImplementedException();
    }
}