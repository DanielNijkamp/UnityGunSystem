using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettingsScript : MonoBehaviour
{
    public float SFXSliderVolume;
    public float BGMSliderVolume;

    public Slider BGMSlider;
    public Slider SFXSlider;

    public TextMeshProUGUI BGMText;
    public TextMeshProUGUI SFXText;

    public Button backButton;

    public GameObject MainMenuCanvas;

    public GameObject settingsCanvas;

    private static AudioSettingsScript settingsMenuScript;

    [HideInInspector] public bool SettingIsOpen = false;

    public void ShowSettings()
    {
        SettingIsOpen = true;
        settingsCanvas.SetActive(true);
    }
    void Start()
    {
        float BGMSliderPerfs = PlayerPrefs.GetFloat("BGMSlider", 30);
        float SFXSliderPerfs = PlayerPrefs.GetFloat("BGMSlider", 30);
        BGMSlider.value = BGMSliderPerfs;
        SFXSlider.value = SFXSliderPerfs;
        SFXChanged(SFXSliderPerfs);
        BGMChanged(BGMSliderPerfs);
    }
    
    public void CloseSettings()
    {
        SettingIsOpen = false;
        settingsCanvas.SetActive(false);
    }

    public void BGMChanged(float value)
    {
        BGMSliderVolume = value;
        FindObjectOfType<SoundManagerScript>().ChangeBGMVolume(BGMSliderVolume);
        BGMText.text = value + "%";
        PlayerPrefs.SetFloat("BGMSlider", value);
        PlayerPrefs.Save();
    }
    public void SFXChanged(float value)
    {
        SFXSliderVolume = value;
        FindObjectOfType<SoundManagerScript>().ChangeSFXVolume(SFXSliderVolume);
        SFXText.text = value + "%";
        PlayerPrefs.SetFloat("SFXSlider", value);
        PlayerPrefs.Save();
    }
    public void OnBGMSliderChanged()
    {
        BGMChanged(BGMSlider.value);
    }

    public void OnSFXSliderChanged()
    {
        SFXChanged(SFXSlider.value);
    }
    private void OnEnable()
    {
        BGMSlider.onValueChanged.AddListener(delegate { OnBGMSliderChanged(); });
        SFXSlider.onValueChanged.AddListener(delegate { OnSFXSliderChanged(); });

    }
    void OnDisable()
    {
        BGMSlider.onValueChanged.RemoveAllListeners();
        SFXSlider.onValueChanged.RemoveAllListeners();
    }
    private void Awake()
    {
        if (!settingsMenuScript)
        {
            DontDestroyOnLoad(gameObject);
            settingsMenuScript = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
