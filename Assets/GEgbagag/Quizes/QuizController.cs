using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(QuizLoader))]
public class QuizController : MonoBehaviour
{
    public QuizLoader QLoader;
    [SerializeField] GameObject _testZonePanel;
    [SerializeField] GameObject _quizpanel;
    [SerializeField] GameObject _resultPanel;

    [Space, Header("Quiz")]
    [SerializeField] Image _backgroundImage;
    [SerializeField] TextMeshProUGUI _quizNameText;
    [SerializeField] TextMeshProUGUI _questionText;
    [SerializeField] TextMeshProUGUI[] _answersText;
    [SerializeField] TextMeshProUGUI _resultText;

    Quiz _quiz;
    int _score = 0;
    int _questionNum = 0;


    public void StartQuiz(Quiz quiz, Sprite image)
    {
        _quiz = quiz;
        _questionNum = 0;

        //foreach(var q in _quiz.Questions)
        //{
        //    print(q.Text);
        //    print(q.Answers.Count);
        //}
        _quizNameText.text = _quiz.Header;
        _backgroundImage.sprite = image;
        _testZonePanel.SetActive(false);
        _quizpanel.SetActive(true);
        SetQuestion();
       
    }

    public void AnswerButton(int answerNum)
    {
        if(_questionNum < _quiz.Questions.Count)
        {
            //print(_quiz.Questions.Count + " " + _questionNum);
            _score += _quiz.Questions[_questionNum].Answers[answerNum].Points;
            SetQuestion();
        }
        else
        {
            _score += _quiz.Questions[_questionNum-1].Answers[answerNum].Points;

            _quizpanel.SetActive(false);
            _resultPanel.SetActive(true);

            _resultText.text = ResultText();
        }

    }

    public string ResultText()
    {
        foreach (var result in _quiz.Results)
        {
            if(_score >= result.MinPoints && _score <= result.MaxPoints)
            {
                return result.Description;
            }
        }
        return null;
    }
    public void TryAgainButton()
    {
        _resultPanel.SetActive(false);
        StartQuiz(_quiz, _backgroundImage.sprite);
    }

    void SetQuestion()
    {
        _questionText.text = _quiz.Questions[_questionNum].Text;

        for (int i = 0; i < _quiz.Questions[_questionNum].Answers.Count; i++)
        {
            _answersText[i].text = _quiz.Questions[_questionNum].Answers[i].Text;
        }


        _questionNum++;
    }
}
