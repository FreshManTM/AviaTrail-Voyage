using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevronManager : MonoBehaviour
{
    public static ChevronManager Instance;
    public static int Chevrons;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Chevrons = fdUgbngd.Instance.LoadInfo().Chevrons;
    }

    public int GetChevrons()
    {
        return Chevrons;
    }
    public void AddChevrons(int chevrons)
    {
        Chevrons += chevrons;
        SaveChevrons();
    }

    public bool RemoveChevrons(int chevrons)
    {
        if(Chevrons - chevrons > 0)
        {
            Chevrons -= chevrons;
            SaveChevrons();
            return true;
        }
        else 
            return false;
    }

    void SaveChevrons()
    {
        PlayerData playerData = fdUgbngd.Instance.LoadInfo();
        playerData.Chevrons = Chevrons;
        fdUgbngd.Instance.SaveInfo(playerData);
    }
}