namespace Sharlink.Client.Maui.Utilities;

public static class UserColorGenerator
{
    static readonly List<Color> Colors =
        [
            Color.FromArgb("#49A0DB"),
            Color.FromArgb("#E1B875"),
            Color.FromArgb("#E06C75"),
            Color.FromArgb("#98C379"),
            Color.FromArgb("#C076D9"),
        ];

    static int CurrentColorIndex;

    public static Color GetNewColor()
    {
        if (CurrentColorIndex < Colors.Count - 1)
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
