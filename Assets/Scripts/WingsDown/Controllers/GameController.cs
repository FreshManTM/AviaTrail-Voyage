using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    PlayerData _playerData;
    int _points;
    int _chevrons;
    int _addPoints = 10;
    private void Start()
    {
        _playerData = Saver.Instance.LoadInfo();
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
        EnableStars(collides);

        ChevronManager.Instance.AddChevrons(_chevrons);
    }

    private void EnableStars(int collides)
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
    }

    public void ChangeTimeScale(int scale = 0)
    {
        Time.timeScale = scale;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
