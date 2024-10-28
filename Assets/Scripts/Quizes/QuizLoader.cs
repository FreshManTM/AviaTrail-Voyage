using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class QuizLoader : MonoBehaviour
{
    //Test part

    //private void Start()
    //{
    //    Quiz quiz = LoadQuiz(Resources.Load<TextAsset>("test1")); // Assumes the quiz file is named "quiz.txt" in Resources
    //    foreach (Answer answer in quiz.Questions[0].Answers)
    //    {
    //        print(answer.Text);
    //    }

    //}
    public Quiz LoadQuiz(TextAsset quizFile)
    {
        Quiz quiz = new Quiz();
        List<Result> results = new List<Result>();

        using (StringReader reader = new StringReader(quizFile.text))
        {
            string line = reader.ReadLine();
            Question currentQuestion = null;

            // Read quiz header
            quiz.Header = line.Trim();

            while ((line = reader.ReadLine()) != null)
            {
                // Detect question section
                if (line.StartsWith("Questions") || line.StartsWith("Results:"))
                {
                    continue;
                }

                // Start of a new question
                if (line.EndsWith("?"))
                {
                    // Add the previous question to the quiz list if it exists
                    if (currentQuestion != null)
                    {
                        quiz.Questions.Add(currentQuestion);
                    }

                    // Initialize a new question
                    currentQuestion = new Question { Text = line.Trim() };
                }
                // Parse answers and points
                else if (line.Contains(")"))
                {
                    Answer answer = ParseAnswer(line);
                    currentQuestion?.Answers.Add(answer);
                }
                // Parse results section
                else if (line.Contains("-"))
                {
                    // Add the last question if it exists and hasn't been added yet
                    if (currentQuestion != null)
                    {
                        quiz.Questions.Add(currentQuestion);
                        currentQuestion = null; // Reset to prevent duplicates
                    }

                    // Parse result range and description
                    Result result = ParseResult(line, reader.ReadLine());
                    if (result != null)
                    {
                        results.Add(result);
                    }
                }
            }

            // Add the final question if it hasn't been added
            if (currentQuestion != null)
            {
                quiz.Questions.Add(currentQuestion);
            }
        }

        quiz.Results = results;
        return quiz;
    }

    private Answer ParseAnswer(string line)
    {
        // Refined regex pattern to match answer text and points in various formats
        //Match match = Regex.Match(line, @"^[A-D]\)\s*(?<answerText>.+?)\s*\(\s*(?<points>\d+)\s*(points?)?\s*\)$");
        Match match = Regex.Match(line, @"^(?<answerText>.+?)\s*\(\s*(?<points>\d+)\s*(points?)?\s*\)$");
        if (match.Success )
        {
            // Extract answer text without points
            string answerText = match.Groups["answerText"].Value.Trim();
            int points = int.Parse(match.Groups["points"].Value);
            // Return the answer object with parsed text and points
            return new Answer { Text = answerText, Points = points };
        }
        else
        {
            Debug.LogWarning("Failed to parse answer line: " + line);
        }

        return null;
    }

    private Result ParseResult(string headerLine, string descriptionLine)
    {
        // Regex to match result range and description, e.g., "15-25 points: Light and Nimble Aircraft"
        Match match = Regex.Match(headerLine, @"^(?<minPoints>\d+)[-–](?<maxPoints>\d+)\s*[Pp]oints:\s*(?<header>.+)$");
        if (match.Success)
        {
            int minPoints = int.Parse(match.Groups["minPoints"].Value);
            int maxPoints = int.Parse(match.Groups["maxPoints"].Value);
            string header = match.Groups["header"].Value.Trim();
            string description = headerLine.Trim() + '\n' + descriptionLine.Trim();

            return new Result { MinPoints = minPoints, MaxPoints = maxPoints, Description = description };
        }
        else
        {
            Debug.LogWarning("Failed to parse result line: " + headerLine + descriptionLine);

        }
        return null;
    }
}

public class Quiz
{
    public string Header { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public List<Result> Results { get; set; } = new List<Result>();
}

public class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; set; } = new List<Answer>();
}

public class Answer
{
    public string Text { get; set; }
    public int Points { get; set; }
}

public class Result
{
    public int MinPoints { get; set; }
    public int MaxPoints { get; set; }
    public string Description { get; set; }
}


