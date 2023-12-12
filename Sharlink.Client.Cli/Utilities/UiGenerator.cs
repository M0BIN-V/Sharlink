using Sharlink.Client.Hub.Models;

namespace Sharlink.Client.Utilities;

internal static class UiGenerator
{
    public static string GenerateMessage(Message message)
    {
        var content = message.Content;
        var userName = message.UserName;
        var time = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";

        var result = "";

        var width = 7 + userName.Length + content.Length + time.Length;
        const int height = 3;

        for (int h = 1; h <= height; h++)
        {
            for (int w = 1; w <= width; w++)
            {
                if (h is 1)
                {
                    if (w is 1)
                    {
                        result += "╭";
                    }
                    else if (w is 2)
                    {
                        result += userName;
                        w += userName.Length;
                    }
                    else if (w == width)
                    {
                        result += "╮";
                        result += "\n";
                    }
                    else
                    {
                        result += "─";
                    }
                }
                else if (h is 2)
                {
                    if (w is 1)
                    {
                        result += "│";
                    }
                    else if (w == width)
                    {
                        result += "│\n";
                    }
                    else if (w < userName.Length + 4 || w > content.Length + userName.Length + 3)
                    {
                        result += " ";
                    }
                    else
                    {
                        result += content;
                        w += content.Length;
                    }
                }
                else if (h is 3)
                {
                    if (w is 1)
                    {
                        result += "╰";
                    }
                    else if (w == width)
                    {
                        result += "╯";
                    }
                    else if (w == width - time.Length - 1)
                    {
                        result += time;
                        w += time.Length;
                    }
                    else
                    {
                        result += "─";
                    }
                }
            }
        }
        return result;
    }

    public static string GenerateInput(int width, string title)
    {
        string result = "";

        var generatedTitle = $" {title} : ";

        for (int h = 0; h < 3; h++)
        {
            for (int w = 0; w < width; w++)
            {
                if (h is 0)
                {
                    if (w is 0)
                    {
                        result += "╭";
                    }
                    else if (w == width - 1)
                    {
                        result += "╮\n";
                    }
                    else
                    {
                        result += "─";
                    }
                }
                else if (h is 1)
                {
                    if (w is 0)
                    {
                        result += "│";
                    }
                    else if (w == width - 1)
                    {
                        result += "│\n";
                    }
                    else if (w is 1)
                    {
                        result += generatedTitle;
                        w += generatedTitle.Length - 1;
                    }
                    else
                    {
                        result += " ";
                    }
                }
                else if (h is 2)
                {
                    if (w is 0)
                    {
                        result += "╰";
                    }
                    else if (w == width - 1)
                    {
                        result += "╯\n";
                    }
                    else
                    {
                        result += "─";
                    }
                }
            }
        }

        return result;
    }
}
