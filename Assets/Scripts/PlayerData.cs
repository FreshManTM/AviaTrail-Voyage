using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData 
{
    public int Chevrons;
    public int PointRecord;
    public int[] LevelStars;
    public Country SetCountry;
    public List<Country> PurchasedCountries;
}
