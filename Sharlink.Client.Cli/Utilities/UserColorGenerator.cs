namespace Sharlink.Client.Utilities;

public static class UserColorGenerator
{
    static readonly List<int> Colors = [9, 10, 11, 12, 14];
    static int CurrentColorIndex = 0;

    public static ConsoleColor GetNewColor()
    {
        if (CurrentColorIndex <= Colors.Count - 1)
        {
            CurrentColorIndex++;
        }
        else
        {
            CurrentColorIndex = 0;
        }

        return (ConsoleColor)Colors[CurrentColorIndex];
    }
}
