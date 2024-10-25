using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] int _levelNum;
    [SerializeField] GameObject _normalBack;
    [SerializeField] GameObject[] _stars;

    public void SetLevelUI(int stars = 0)
    {

        _normalBack.SetActive(true);
        if(stars > 0)
        {
            for (int i = 0; i < stars; i++)
            {
                _stars[i].SetActive(true);
            }
        }
    }

    public void LoadLevel()
    {
        var _data = Saver.Instance.LoadInfo();
        _data.CurrentLevel = _levelNum;
        Saver.Instance.SaveInfo(_data);
        SceneManager.LoadScene(1);
    }
}
