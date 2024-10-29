using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class fdUgbngd : MonoBehaviour
{
    public static fdUgbngd Instance;
    [SerializeField] Country _defaultCountry;
    string _filePath;
    PlayerData _playerData = new PlayerData();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        _filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

    }

   public void SaveInfo(PlayerData save)
    {
        File.WriteAllText(_filePath, JsonUtility.ToJson(save));
    }

    public PlayerData LoadInfo()
    {

        if (File.Exists(_filePath))
        {
            _playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(_filePath));
        }
        else
        {
            _playerData.SetCountry = _defaultCountry;
            _playerData.PurchasedCountries = new List<Country>();
            _playerData.PurchasedCountries.Add(_defaultCountry);
            SaveInfo(_playerData);
        }
        return _playerData;
    }

}
