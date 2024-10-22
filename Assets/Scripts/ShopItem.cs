using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Country _country;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _purchaseText;
    [SerializeField] Image _backgroundImage;
    [SerializeField] Image _bagImage;
    [SerializeField] Image _barrelImage;
    [SerializeField] Image _stoneImage;

    private void Start()
    {
        SetImages();
    }

    void SetImages()
    {
        _nameText.text = _country.name;
        _backgroundImage.sprite = _country.Road;
        _bagImage.sprite = _country.Bag;
        _barrelImage.sprite = _country.Cat;
        _stoneImage.sprite = _country.Dog;

    }

}
