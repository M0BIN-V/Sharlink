using Sharlink.Client.Cli.Data;
using Sharlink.Client.Cli.Models;
using Sharlink.Client.Hub.Models;
using static Sharlink.Client.Utilities.UiGenerator;

namespace Sharlink.Client.Utilities;

public class ConsoleViewer(string userName)
{
    public void ShowMessage(Message message)
    {
        Console.SetCursorPosition(0, 0);

        TmpDb.Messages.Add(message);

        Console.CursorVisible = false;

        Console.Clear();
        foreach (var msg in TmpDb.Messages)
        {
            if (!TmpDb.UserColors.Any(uc => uc.UserName == msg.UserName))
            {
                TmpDb.UserColors.Add(new UserColor { UserName = msg.UserName, Color = UserColorGenerator.GetNewColor() });
            }

            Console.ForegroundColor = TmpDb.UserColors.Single(uc => uc.UserName == msg.UserName).Color;

            Console.WriteLine(GenerateMessage(msg));

            Console.ResetColor();
        }

        Console.WriteLine("\n\n\n\n");

        Console.CursorVisible = true;

        ShowInput();
    }

    public void ShowInput()
    {
        var title = userName;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, Console.WindowHeight - 5);
        Console.WriteLine(GenerateInput(Console.WindowWidth - 1, title));
        Console.SetCursorPosition(left: 5 + title.Length, top: Console.WindowHeight - 4);
        Console.ResetColor();
    }
}
