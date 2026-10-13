using System.Diagnostics.Metrics;

namespace StemwijzerApp;

public partial class QuestionPage : ContentPage
{
    public QuestionPage()
    {
        InitializeComponent();
    }

    int count = 0;
    private void OnClickEens(object? sender, EventArgs e)
    {
        count++;
        StellingArea.Text = $"Je hebt eens geklikt! ({count})";
        
    }

    private void OnClickGeenMening(object? sender, EventArgs e)
    {
        StellingArea.Text = $"Je hebt geen mening geklikt! ({count})";
    }

    private void OnClickOneens(object? sender, EventArgs e)
    {
        count--;
        StellingArea.Text = $"Je hebt oneens geklikt! ({count})";
        
    }
}