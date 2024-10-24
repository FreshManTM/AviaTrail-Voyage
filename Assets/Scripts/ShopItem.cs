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
    PlayerData _data;

    private void OnEnable()
    {
        if (_data == null)
            _data = Saver.Instance.LoadInfo();
        SetImages();
    }

    public void BuyUseButton()
    {
        if (_data.PurchasedCountries.Contains(_country))
        {
            _data.SetCountry = _country;
            
            _priceText.gameObject.SetActive(false);
            _purchaseText.gameObject.SetActive(true);
            _purchaseText.text = "Used";
        }
        else
        {
            if (ChevronManager.Instance.RemoveChevrons(_country.Cost))
            {

            }
        }
    }

    public void SetImages()
    {
        _nameText.text = _country.name;
        _backgroundImage.sprite = _country.Road;
        _bagImage.sprite = _country.Bag;
        _barrelImage.sprite = _country.Stone;
        _stoneImage.sprite = _country.Barrel;
    }

}
