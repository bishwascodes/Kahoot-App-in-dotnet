namespace kahoot_app.Persistence;

using System.Collections.Generic;
using System.Text.Json;


public class QuizData
{
    public QuizData()
    {
        
    }
    
    public List<(string question, List<(int optionId, bool isCorrect, string option)> options)> getDataFromJson(string fileName)
    {
        string jsonContent = File.ReadAllText(fileName);
        var questions = JsonSerializer.Deserialize<List<(string question, List<(int optionId, bool isCorrect, string option)> options)>>(jsonContent);
        return questions;
    }
}
