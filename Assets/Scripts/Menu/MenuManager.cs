using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] Image _backgroundImage;
    [SerializeField] TextMeshProUGUI _countryText;
    [SerializeField] TextMeshProUGUI[] _chevronText;
    [SerializeField] Country[] _countries;
    [SerializeField] ShopItem[] _shopItems;
    [SerializeField] AudioSource _buttonClickSound;
    [SerializeField] AudioSource _musicSound;

    ChevronManager _chevronManager;
    PlayerData _data;
    ShopItem _currentItem, _previousItem;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _chevronManager = ChevronManager.Instance;
        _data = Saver.Instance.LoadInfo();
        _backgroundImage.sprite = _data.SetCountry.Background;
        _countryText.text = _data.SetCountry.name;
        SetShopItems();
    }

    private void Update()
    {
        foreach(var t in _chevronText)
        {
            t.text = _chevronManager.GetChevrons().ToString();
        }
    }

    public void ToggleAnimButton(Animator animator)
    {
        if (animator.GetBool("On"))
        {
            animator.SetBool("On", false);
        }
        else
        {
            animator.SetBool("On", true);
        }

    }
    public void SoundButton(AudioSource sound)
    {
        if (sound.mute)
        {
            sound.mute = false;
        }
        else
        {
            sound.mute = true;
        }
    }
    public void MusicButton(AudioSource sound)
    {
        if (sound.isPlaying)
        {
            sound.Pause();
        }
        else
        {
            sound.Play();
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ItemPurchased(ShopItem item)
    {
        foreach (var t in _shopItems)
        {
            if (t == item)
            {
                _previousItem = _currentItem;
                _currentItem = t;
                _currentItem.SetUsedText();
                _previousItem.SetUseText();
                _data = Saver.Instance.LoadInfo();

                _backgroundImage.sprite = _data.SetCountry.Background;
                _countryText.text = _data.SetCountry.name;

                return;
            }
        }
    }

    void SetShopItems()
    {
        for (int i = 0; i < _shopItems.Length; i++)
        {
            _shopItems[i].SetCountry(_countries[i]);

            if (_data.SetCountry.name == _countries[i].name)
            {
                _currentItem = _shopItems[i];
                _shopItems[i].SetUsedText();
            }
            else if (_data.PurchasedCountries.Contains(_countries[i]) || i == 0)
            {
                _shopItems[i].SetUseText();
            }
            else
            {
                _shopItems[i].SetPriceText();
            }
        }
    }
}
