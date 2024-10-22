using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image _backgroundImage;
    PlayerData _data;

    private void Start()
    {
        _data = Saver.Instance.LoadInfo();
        if(_data.SetCountry)
            _backgroundImage.sprite = _data.SetCountry.Background;
    }
}
