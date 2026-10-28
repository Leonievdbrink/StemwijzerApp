using System.Text.Json;

namespace StemwijzerApp;

public partial class QuestionPage : ContentPage
{

    public QuestionPage()
    {
        InitializeComponent();
        Window_Loaded();
    }

    private async void Window_Loaded()
    {
        try
        {
            var stellingenService = new GetStellingen();
            List<Stellingen> stellingen =
                await stellingenService.LoadStellingenAsync();

            if (stellingen.Count > 0)
            {
                StellingArea.Text = stellingen[0].tekst;
            }
        }
        catch (Exception exception)
        {
            StellingArea.Text = $"De stellingen konden niet worden geladen: {exception.Message}";
        }
    }
    //http://localhost/Stemwijzer/API/SendStellingen.php

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

    

    public class GetStellingen
    {
        private const string ApiUrl =
          "http://10.0.2.2/Stemwijzer/API/SendStellingen.php";

        private readonly HttpClient _client = new();
        private readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public List<Stellingen> Items { get; private set; } = [];

        public async Task<List<Stellingen>> LoadStellingenAsync(
            CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response =
                await _client.GetAsync(ApiUrl, cancellationToken);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync(cancellationToken);

            Items = JsonSerializer.Deserialize<List<Stellingen>>(
                json,
                _serializerOptions) ?? [];

            return Items;
        }
    }

}