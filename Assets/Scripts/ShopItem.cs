using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Country _country;
    [SerializeField] int _cost;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _purchaseText;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] Image _backgroundImage;
    [SerializeField] Image _bagImage;
    [SerializeField] Image _barrelImage;
    [SerializeField] Image _stoneImage;
    PlayerData _data;

    private void Start()
    {
        _data = Saver.Instance.LoadInfo();
        if (!_data.SetCountry)
        {
            _data.SetCountry = _country;
        }
        SetImages();
    }

    void SetImages()
    {
        _nameText.text = _country.name;
        _backgroundImage.sprite = _country.Road;
        _bagImage.sprite = _country.Bag;
        _barrelImage.sprite = _country.Cat;
        _stoneImage.sprite = _country.Dog;

        if (_data.PurchasedCountries != null && _data.PurchasedCountries.Contains(_country.name))
        {
            _purchaseText.text = "Use";
        }
        else
        {
            _purchaseText.gameObject.SetActive(false);
            _priceText.gameObject.SetActive(true);
            _priceText.text = "Buy " + _cost;
        }
        if(_data.SetCountry.name == _country.name)
        {
            _purchaseText.text = "Used";
        }
    }

}
