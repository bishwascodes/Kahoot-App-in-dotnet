namespace kahoot_app.Persistence;

using System.Collections.Generic;
using System.Text.Json;

public class QuestionData
{
    public string question { get; set; }
    public List<OptionData> options { get; set; }
}

public class OptionData
{
    public int optionId { get; set; }
    public bool isCorrect { get; set; }
    public string option { get; set; }
}
public class QuizData
{
    public QuizData()
    {

    }

    public List<(string question, List<(int optionId, bool isCorrect, string option)> options)> getDataFromJson(string fileName)
    {
        try
        {
            string jsonContent = File.ReadAllText(fileName);
            var questions = JsonSerializer.Deserialize<List<QuestionData>>(jsonContent);

            List<(string question, List<(int optionId, bool isCorrect, string option)> options)> questionsList = new();

            foreach (var questionData in questions)
            {
                List<(int optionId, bool isCorrect, string option)> optionsList = new();

                foreach (var optionData in questionData.options)
                {
                    optionsList.Add((optionData.optionId, optionData.isCorrect, optionData.option));
                }

                questionsList.Add((questionData.question, optionsList));
            }

            return questionsList;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<(string question, List<(int optionId, bool isCorrect, string option)> options)>();
        }
    }

}
