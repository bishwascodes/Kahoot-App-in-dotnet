namespace kahoot_app.Persistence;

using System.Collections.Generic;
using System.Text.Json;


public record Options(int optionId, bool isCorrect, string option);
public record Question(string question, List<Options> options);
public class QuizData
{
    public QuizData()
    {
        
    }
    public List<Question> getDataFromJson(string fileName){

        string jsonContent = File.ReadAllText(fileName);

        return JsonSerializer.Deserialize<List<Question>>(jsonContent);
    }
}
