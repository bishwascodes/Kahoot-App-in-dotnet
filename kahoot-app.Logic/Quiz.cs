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
    private int currentQuestionNumber = 0;

    public int CurrentQuestionNumber
    {
        get
        {
            return currentQuestionNumber;
        }
    }
    public List<(int id, int score)> LeaderBoard = new();
    public bool IsQuizOver = false;
    public bool PlayersCanJoin;

    public string QuizName { get; }
    public List<Player?> Players = new();
    public Admin? Admin { get; set; }
    public Questions? Questions;

    // REQ#4.1.2
    public void getQuestions()
    {
        Questions = new Questions("../kahoot-app.Persistence/quiz_1.json");
    }

    // REQ#1.2.3
    public int Join(string newPlayerName)
    {
        if (PlayersCanJoin)
        {
            if (newPlayerName == null)
            {
                throw new ArgumentNullException("You can't use null name");
            }
            else
            {
                Player player = new Player(newPlayerName);
                Players.Add(player);
                QuizStateChanged?.Invoke();
                return player.PlayerId; // Return the ID of the newly added player
            }
        }
        else
        {
            throw new QuizClosedException("Sorry! This quiz is already closed");
        }
    }
    public void Start()
    {
        PlayersCanJoin = false;
        currentQuestionNumber++;
        QuizStarted?.Invoke();
    }
    public void EndQuiz()
    {
        IsQuizOver = true;
        // REQ#3.1.2
        QuizReset?.Invoke();
    }
    public void ChangeQuestion(){
        IncrementCurrentQuestionNumber();
        QuestionChangedEvent?.Invoke();
    }
    public void TriggerStateChange(){
         QuizStateChanged?.Invoke();
    }
    public void IncrementCurrentQuestionNumber()
    {
        if(currentQuestionNumber >= Questions.QuestionsList.Count){
            QuizReset?.Invoke();
        } else{
        currentQuestionNumber++;
        }
    }
    public List<( int rank, string playerName, int score)> GetPlayerRanks()
    {
        // Sort players by score value in descending order
        var sortedPlayers = Players
            .Where(player => player != null && player.Score != null) // Filter out null players or scores
            .OrderByDescending(player => player!.Score!.Value) // Sort by score value
            .ToList();

        // Assign ranks to players based on their position in the sorted list
        var rankedPlayers = sortedPlayers
            .Select((player, index) => (Rank: index + 1, player!.Name, Score: player.Score!.Value)) // Assign rank based on position in the sorted list
            .ToList();

        return rankedPlayers;
    }

    //REQ#3.1.1
    public event Action? QuizStateChanged;
    public event Action? QuizReset;
    public event Action? QuizStarted;
    public event Action? QuestionChangedEvent;
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