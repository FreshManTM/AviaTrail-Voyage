using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _pointsText;
    [SerializeField] TextMeshProUGUI _winPointsText;
    [SerializeField] TextMeshProUGUI _winChevronsText;
    [SerializeField] GameObject _winPanel;
    [SerializeField] GameObject[] _stars;

    PlayerData _data;
    int _points;
    int _chevrons;
    int _addPoints = 10;
    private void Start()
    {
        _data = Saver.Instance.LoadInfo();
    }
    public void AddChevrons(int chevrons)
    {
        _chevrons += chevrons;
    }

    public void AddPoints()
    {
        _points += _addPoints;
        _addPoints *= 2;

        _pointsText.text = _points.ToString();
    }

    public void ResetCombo()
    {
        _addPoints = 10;
    }

    public void Win(int collides)
    {
        ChangeTimeScale(0);
        _winPanel.SetActive(true);
        _winPointsText.text = "Result: " + _points;
        _winChevronsText.text = _chevrons.ToString();
        
        
        if(_data.PointRecord < _points)
        {
            _data.PointRecord = _points;
        }

        try
        {
            _data.LevelStars[_data.CurrentLevel - 1] = EnableStars(collides);
        }
        catch (ArgumentOutOfRangeException)
        {
            print("exception " + _data.CurrentLevel);
            _data.LevelStars.Add(EnableStars(collides));
        }

        Saver.Instance.SaveInfo(_data);
        ChevronManager.Instance.AddChevrons(_chevrons);
    }

    private int EnableStars(int collides)
    {
        int starsCount = 0;
        if (collides > 5)
        {
            starsCount = 1;
        }
        else if (collides >= 3 && collides <= 5)
        {
            starsCount = 2;

        }
        else
        {
            starsCount = 3;

        }

        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].SetActive(true);
        }
        return starsCount;
    }

    public void ChangeTimeScale(int scale = 0)
    {
        Time.timeScale = scale;
    }
    public void MenuButton()
    {
        ChangeTimeScale(1);
        SceneManager.LoadScene(0);
    }
}
