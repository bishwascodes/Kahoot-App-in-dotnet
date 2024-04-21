﻿using System.Runtime.Serialization;
using kahoot_app.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kahoot_app.Logic;
public class Questions
{
    public List<(string question, List<(int optionId, bool isCorrect, string option)> options)> QuestionsList = new();

    public Questions()
    {
        // Empty Questions
    }

    public Questions(string fileName)
    {
        var quizData = new QuizData();
        var rawData = quizData.getDataFromJson(fileName);
        foreach (var item in rawData)
        {
            List<(int optionId, bool isCorrect, string option)> _options = new();
            foreach (var option in item.options)
            {
                _options.Add((option.optionId, option.isCorrect, option.option));
            }

            QuestionsList.Add((item.question, _options));
        }
    }

    public int GetCorrectAnswer(int questionId)
    {
        var question = QuestionsList[questionId];
        var correctOption = question.options.FirstOrDefault(option => option.isCorrect);
        if (correctOption != default)
        {
            return correctOption.optionId;
        }
        else
        {
            throw new NoCorrectAnswerException();
        }
    }

    public string GetQuestion(int questionId)
    {
        return QuestionsList[questionId].question;
    }

    public List<(int, string)> GetOptions(int questionId)
    {
        List<(int, string)> options = new();
        foreach (var optionItem in QuestionsList[questionId].options)
        {
            options.Add((optionItem.optionId, optionItem.option));
        }
        return options;
    }
}



// Exceptions
[Serializable]
internal class NoCorrectAnswerException : Exception
{
    public NoCorrectAnswerException()
    {
    }

    public NoCorrectAnswerException(string? message) : base(message)
    {
    }

    public NoCorrectAnswerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NoCorrectAnswerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}