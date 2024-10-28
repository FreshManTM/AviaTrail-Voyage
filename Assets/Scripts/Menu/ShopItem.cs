using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Country _country;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _purchaseText;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] Image _backgroundImage;
    [SerializeField] Image _bagImage;
    [SerializeField] Image _barrelImage;
    [SerializeField] Image _stoneImage;
    [SerializeField] AudioSource _purchaseSound;
    [SerializeField] AudioSource _useSound;
    PlayerData _data;

    public void BuyUseButton()
    {
        _data = Saver.Instance.LoadInfo();

        if (_data.SetCountry == _country)
            return;
        
        if (_data.PurchasedCountries.Contains(_country))
        {
            _useSound.Play();
            _data.SetCountry = _country;
            Saver.Instance.SaveInfo(_data);
            MenuManager.Instance.ItemPurchased(this);
        }
        else
        {
            if (ChevronManager.Instance.RemoveChevrons(_country.Cost))
            {
                _purchaseSound.Play();
                _data.PurchasedCountries.Add(_country);
                _data.SetCountry = _country;
                Saver.Instance.SaveInfo(_data);
                MenuManager.Instance.ItemPurchased(this);
            }
        }
    }

    public void SetCountry(Country country)
    {
        _country = country;
        _nameText.text = _country.name;
        _backgroundImage.sprite = _country.Road;
        _bagImage.sprite = _country.Bag;
        _barrelImage.sprite = _country.Stone;
        _stoneImage.sprite = _country.Barrel;
    }

    public void SetPriceText()
    {
        _purchaseText.gameObject.SetActive(false);
        _priceText.gameObject.SetActive(true);
        _priceText.text = "Buy " + _country.Cost;
    }

    public void SetUsedText()
    {
        _priceText.gameObject.SetActive(false);
        _purchaseText.gameObject.SetActive(true);
        _purchaseText.text = "Used";
    }

    public void SetUseText()
    {
        _purchaseText.text = "Use";
    }

}
