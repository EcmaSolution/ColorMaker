using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    private readonly Random _rnd = new();
    private bool _isRandom = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (_isRandom)
            return;
            
        var red = SldRed.Value;
        var green = SldGreen.Value;
        var blue = SldBlue.Value;

        Color color = Color.FromRgb(red, green, blue);

        SetColor(color);
    }

    private void SetColor(Color color)
    {
        LblHex.Text = color.ToHex();
        Container.BackgroundColor = color;
        BtnRandom.BackgroundColor = color;
    }

    private void GenerateRandomColor(object sender, EventArgs e)
    {
        _isRandom = true;

        Color randColor = Color.FromRgb(_rnd.Next(256), _rnd.Next(256), _rnd.Next(256));

        SldRed.Value = randColor.Red;
        SldGreen.Value = randColor.Green;
        SldBlue.Value = randColor.Blue;

        SetColor(randColor);
        _isRandom = false;
    }

    private async void CopyToClipboard(object sender, EventArgs e)
    {
        var color = LblHex.Text;
        await Clipboard.SetTextAsync(color);
        var toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 13);

        await toast.Show();
    }
}

