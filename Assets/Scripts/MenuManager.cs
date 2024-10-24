using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Image _backgroundImage;
    [SerializeField] TextMeshProUGUI[] _chevronText;
    [SerializeField] Country[] _countries;
    [SerializeField] ShopItem[] _shopItems;
    ChevronManager _chevronManager;
    PlayerData _data;

    private void Start()
    {
        _chevronManager = ChevronManager.Instance;
        _data = Saver.Instance.LoadInfo();

        _backgroundImage.sprite = _data.SetCountry.Background;
    }

    private void Update()
    {
        foreach(var t in _chevronText)
        {
            t.text = _chevronManager.GetChevrons().ToString();
        }
    }

    //void SetShopItems()
    //{
    //    for (int i = 0; i < _shopItems.Length; i++)
    //    {

    //        if (_data.SetCountry.name == _countries[i].name)
    //        {
    //            _shopItems[i].SetItem(_countries[i], "Used");
    //        }
    //        else if (_data.PurchasedCountries.Contains(_countries[i]))
    //        {
    //            _shopItems[i].SetItem(_countries[i], "Use");
    //        }
    //        else
    //        {
    //            _shopItems[i].SetItem(_countries[i], "Buy");
    //        }
    //    }
    //}
}
