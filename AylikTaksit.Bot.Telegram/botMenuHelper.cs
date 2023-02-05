using AylikTaksit.Bot.Telegram.Extensions;

namespace AylikTaksit.Bot.Telegram;

public class BotMenuHelper
{
    public static string Menu(string message,int chatId)
    {
        if (message.SW("/start"))
        {
            return CmdStart.HandleMessage(message);
        }
        else if (message.SW("/help"))
        {
            return "I can't help you";
        }
        else if(message.SW("/add"))
        {
            return  CmdAdd.Handle(message);
        }

        return "Geçersiz komut.";
    }
}