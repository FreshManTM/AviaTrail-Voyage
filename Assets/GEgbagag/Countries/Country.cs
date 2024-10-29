using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="Country", menuName = "CountryImages")]
public class Country : ScriptableObject
{
    public int Cost;
    public Sprite Background;
    public Sprite Road;
    public Sprite Bag;
    public Sprite Purse;
    public Sprite Women;
    public Sprite Man;
    public Sprite Bird;
    public Sprite Celebrity;
    public Sprite Barrel;
    public Sprite Stone;
    public Sprite Trash;
}
