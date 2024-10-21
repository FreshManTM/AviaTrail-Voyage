using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevronManager : MonoBehaviour
{
    public static ChevronManager Instance;
    static int _chevrons;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddChevrons(int chevrons)
    {
        _chevrons += chevrons;
        SaveChevrons();
    }

    public bool RemoveChevrons(int chevrons)
    {
        if(_chevrons - chevrons > 0)
        {
            _chevrons -= chevrons;
            SaveChevrons();
            return true;
        }
        else 
            return false;
    }

    void SaveChevrons()
    {
        PlayerData playerData = Saver.Instance.LoadInfo();
        playerData.Chevrons = _chevrons;
        Saver.Instance.SaveInfo(playerData);
    }
}
