using System.Text.Json;
using StemwijzerApp.Models;

namespace StemwijzerApp.Services;

public sealed class AnswerSession
{
    private readonly List<Answer> _answers = new();

    public string Json => JsonSerializer.Serialize(_answers);

    public void Clear()
    {
        _answers.Clear();
    }

    public void AddAnswer(Stelling stelling, int value)
    {
        _answers.Add(new Answer
        {
            StellingId = stelling.Id,
            Value = value
        });
    }

    public IReadOnlyList<Answer> GetAnswers()
    {
        return _answers.AsReadOnly();
    }

    public sealed class Answer
    {
        public int StellingId { get; set; }
        public int Value { get; set; }
    }
}
