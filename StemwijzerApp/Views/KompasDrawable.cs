using StemwijzerApp.Models;

namespace StemwijzerApp;

public class KompasDrawable : IDrawable
{
    public List<MatchResultaat> Partijen { get; set; } = new();
    public (double X, double Y) Gebruiker { get; set; }

    public void Draw(ICanvas canvas, RectF rect)
    {
        float cx = rect.Center.X;
        float cy = rect.Center.Y;
        float r = Math.Min(rect.Width, rect.Height) / 2 - 40; // straal van de buitenste cirkel

        // Cirkels en assen
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 1.5f;
        for (int i = 1; i <= 4; i++)
            canvas.DrawCircle(cx, cy, r * i / 4);
        canvas.DrawLine(cx - r, cy, cx + r, cy);
        canvas.DrawLine(cx, cy - r, cx, cy + r);

        // Labels bij de assen
        canvas.FontColor = Colors.Black;
        canvas.FontSize = 12;
        canvas.DrawString("progressief", cx - 50, cy - r - 24, 100, 18, HorizontalAlignment.Center, VerticalAlignment.Center);
        canvas.DrawString("conservatief", cx - 50, cy + r + 6, 100, 18, HorizontalAlignment.Center, VerticalAlignment.Center);
        canvas.DrawString("links", rect.Left, cy - 9, 40, 18, HorizontalAlignment.Center, VerticalAlignment.Center);
        canvas.DrawString("rechts", rect.Right - 40, cy - 9, 40, 18, HorizontalAlignment.Center, VerticalAlignment.Center);

        // Partijen
        for (int i = 0; i < Partijen.Count; i++)
        {
            var p = Partijen[i];
            float px = cx + (float)Math.Clamp(p.X, -1.3, 1.3) * r;
            float py = cy - (float)Math.Clamp(p.Y, -1.3, 1.3) * r; // min: positief = progressief = omhoog

            canvas.FillColor = Color.FromHsla((i * 0.618f) % 1f, 0.6f, 0.45f);
            canvas.FillCircle(px, py, 14);

            canvas.FontColor = Colors.White;
            canvas.FontSize = 8;
            canvas.DrawString(p.Naam, px - 14, py - 8, 28, 16, HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        // Gebruiker (je eigen positie)
        float ux = cx + (float)Math.Clamp(Gebruiker.X, -1.3, 1.3) * r;
        float uy = cy - (float)Math.Clamp(Gebruiker.Y, -1.3, 1.3) * r;
        canvas.FillColor = Color.FromArgb("#2BA39B");
        canvas.FillCircle(ux, uy, 16);
        canvas.FontColor = Colors.White;
        canvas.FontSize = 11;
        canvas.DrawString("JIJ", ux - 16, uy - 8, 32, 16, HorizontalAlignment.Center, VerticalAlignment.Center);
    }
}