using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData 
{
    public string PlayerName;
    public Sprite PlayerImage;
    public int Chevrons;
    public int PointRecord;
    public int CurrentLevel;
    public List<int> LevelStars;
    public Country SetCountry;
    public List<Country> PurchasedCountries;
}
