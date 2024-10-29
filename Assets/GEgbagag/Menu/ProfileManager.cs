using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static NativeGallery;
using System.IO;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    [SerializeField] GameObject _firstTimePanel;
    [SerializeField] TMP_InputField _nameField;
    [SerializeField] TextMeshProUGUI[] _playerNameText;
    [SerializeField] Image[] _defaultImages;
    [SerializeField] Image[] _playerImage;

    private const string ImagePathKey = "SelectedImagePath";

    PlayerData _data;
    void Start()
    {
        _data = fdUgbngd.Instance.LoadInfo();
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            foreach (var text in _playerNameText)
            {
                text.text = _data.PlayerName;
            }
        }
        else
        {
            _firstTimePanel.SetActive(true);
        }

        LoadAvatar();
    }

    public void ContinueButton()
    {
        if(_nameField.text != "")
        {
            _data.PlayerName = _nameField.text;
            fdUgbngd.Instance.SaveInfo(_data);
            foreach (var text in _playerNameText)
            {
                text.text = _data.PlayerName;
            }
            _firstTimePanel.SetActive(false);
            PlayerPrefs.SetInt("FirstTime", 1);
        }
    }

    public void LoadAvatar()
    {

        if (PlayerPrefs.HasKey(ImagePathKey))
        {
            string savedPath = PlayerPrefs.GetString(ImagePathKey);
            if (File.Exists(savedPath))
            {
                Texture2D savedTexture = NativeGallery.LoadImageAtPath(savedPath, 512);
                if (savedTexture != null)
                {

                    Sprite savedSprite = SpriteFromTexture2D(savedTexture);

                    for (int i = 0; i < _defaultImages.Length; i++)
                    {
                        _defaultImages[i].gameObject.SetActive(false);
                        _playerImage[i].gameObject.SetActive(true);
                        _playerImage[i].sprite = savedSprite;
                    }
                    Debug.Log("Loaded saved image.");
                }
            }
            else
            {
                Debug.LogWarning("Saved image path no longer exists.");
            }
        }
    }

    private Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {

                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }


                Sprite newSprite = SpriteFromTexture2D(texture);

                for (int i = 0; i < _defaultImages.Length; i++)
                {
                    _defaultImages[i].gameObject.SetActive(false);
                    _playerImage[i].gameObject.SetActive(true);
                    _playerImage[i].sprite = newSprite;
                }
                PlayerPrefs.SetString(ImagePathKey, path);
                PlayerPrefs.Save();

                Debug.Log("Image successfully applied and saved.");
            }
        });

        Debug.Log("Permission result: " + permission);
    }
}
