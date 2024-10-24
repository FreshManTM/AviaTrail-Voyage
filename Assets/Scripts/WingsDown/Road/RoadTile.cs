using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] _roadItems;

    public void SetCountry(Country country)
    {
        Sprite sprite = null;
        if (_roadItems.Length < 0)
            return;

        foreach (SpriteRenderer item in _roadItems)
        {
            switch (item.name)
            {
                case "Road":
                    {
                        sprite = country.Road;
                        break;
                    }
                case "Bag":
                    {
                        sprite = country.Bag;
                        break;
                    }
                case "Purse":
                    {
                        sprite = country.Purse;
                        break;
                    }
                case "Women":
                    {
                        sprite = country.Women;
                        break;
                    }
                case "Man":
                    {
                        sprite = country.Man;
                        break;
                    }
                case "Bird":
                    {
                        sprite = country.Bird;
                        break;
                    }
                case "Celebrity":
                    {
                        sprite = country.Celebrity;
                        break;
                    }
                case "Dog":
                    {
                        sprite = country.Barrel;
                        break;
                    }
                case "Cat":
                    {
                        sprite = country.Stone;
                        break;
                    }
            }
            item.sprite = sprite;
        }
    }
}
