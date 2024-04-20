namespace kahoot_app.Logic;

public class QuizHost
{
    public static QuizHost Instance{get;}

    static QuizHost()
    {
        Instance = new QuizHost();
    } 

    public List<Quiz> Quizzes{get;} = new();
    public void RaiseHostStateChanged() => HostStateChanged?.Invoke();
    public event Action HostStateChanged;
}