namespace Sharlink.Client.Maui.Utilities;

public static class UserColorGenerator
{
    static readonly List<Color> Colors =
        [
            Color.FromArgb("#70BF44"),
            Color.FromArgb("#AB509E"),
            Color.FromArgb("#F9ED24"),
            Color.FromArgb("#FF6971"),
            Microsoft.Maui.Graphics.Colors.Aqua,
        ];
    static int CurrentColorIndex = 0;

    public static Color GetNewColor()
    {
        if (CurrentColorIndex <= Colors.Count - 1)
        {
            CurrentColorIndex++;
        }
        else
        {
            CurrentColorIndex = 0;
        }

        return Colors[CurrentColorIndex];
    }
}
