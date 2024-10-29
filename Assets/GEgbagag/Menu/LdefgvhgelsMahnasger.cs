using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LdefgvhgelsMahnasger : MonoBehaviour
{
    [SerializeField] LevelUI[] _levels;
    [SerializeField] TextMeshProUGUI _recordText;
    PlayerData _data;

    private void Start()
    {
        _data = fdUgbngd.Instance.LoadInfo();

        for (int i = 0; i < _data.LevelStars.Count; i++)
        {
            _levels[i].SetLevelUI(_data.LevelStars[i]);
        }
        _levels[_data.LevelStars.Count].SetLevelUI();
        _recordText.text = "Last record: " + _data.PointRecord;
    }

    public void NextLevelButton()
    {
        var _data = fdUgbngd.Instance.LoadInfo();
        _data.CurrentLevel = _data.LevelStars.Count + 1;
        fdUgbngd.Instance.SaveInfo(_data);
        SceneManager.LoadScene(1);
    }
}