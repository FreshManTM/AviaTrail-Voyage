using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizItem : MonoBehaviour
{
    [SerializeField] QuizController _controller;
    [SerializeField] QuizInfo _info;
    [SerializeField] TextMeshProUGUI _headerTest;
    [SerializeField] Image _quizImage;

    QuizLoader _qLoader;
    Quiz _quiz;
    private void Start()
    {
        _quiz = _controller.QLoader.LoadQuiz(_info.File);
        SetTest();
    }

    void SetTest()
    {
        _headerTest.text = _quiz.Header;
        _quizImage.sprite = _info.Image;
    }

    public void StartButton()
    {
        _controller.StartQuiz(_quiz, _info.Image);
    }

}
