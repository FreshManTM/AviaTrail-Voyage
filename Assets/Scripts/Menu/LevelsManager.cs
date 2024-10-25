using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] LevelUI[] _levels;
    PlayerData _data;

    private void Start()
    {
        _data = Saver.Instance.LoadInfo();

        for (int i = 0; i < _data.LevelStars.Count; i++)
        {
            _levels[i].SetLevelUI(_data.LevelStars[i]);
        }
        _levels[_data.LevelStars.Count].SetLevelUI();
    }

    public void NextLevelButton()
    {
        var _data = Saver.Instance.LoadInfo();
        _data.CurrentLevel = _data.LevelStars.Count + 1;
        Saver.Instance.SaveInfo(_data);
        SceneManager.LoadScene(1);
    }
}
