using System.Runtime.Serialization;

namespace kahoot_app.Logic;

// REQ#1.1.3
public class Quiz
{
    public Quiz(string quizName)
    {
        if (quizName == null)
        {
            throw new ArgumentNullException("You can't have an Quiz with Empty Name");
        }
        else
        {
            QuizName = quizName;
        }
    }
    public string QuizName { get; }
    public List<Player?> Players = new();
    public Admin? Admin { get; set; }
    public Questions? Questions;

    // REQ#4.1.2
    public void getQuestions()
    {
        Questions = new Questions("../kahoot-app.Persistence/quiz_1.json");
    }

    public int Join(string newPlayerName)
    {
        Player player = new Player(newPlayerName);
        Players.Add(player);
        QuizStateChanged?.Invoke();
        return player.PlayerId; // Return the ID of the newly added player
    }
    private int currentQuestionIndex = 0;
    public List<(int id, int score)> LeaderBoard = new();
    public bool IsQuizOver = false;
    public bool PlayersCanJoin = false;
    public event Action? QuizStateChanged;
    public event Action? QuizReset;
}

[Serializable]
internal class QuizClosedException : Exception
{
    public QuizClosedException()
    {
    }

    public QuizClosedException(string? message) : base(message)
    {
    }

    public QuizClosedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected QuizClosedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}