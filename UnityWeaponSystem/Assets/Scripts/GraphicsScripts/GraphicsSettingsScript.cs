using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;
using UnityEngine.SceneManagement;


public class GraphicsSettingsScript : MonoBehaviour
{





    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;

    public PostProcessVolume m_Volume;

    public GameObject volumeobject;

    public Bloom m_Bloom = null;
    public AmbientOcclusion m_AO = null;
    public MotionBlur m_mb = null;




    public Toggle pp_toggle;
    public Toggle bloom_toggle;
    public Toggle AO_toggle;
    public Toggle Motion_Blur_toggle;



    public bool PP_bool;
    public bool Bloom_bool;
    public bool AO_bool;
    public bool Mb_bool;

    
    void Start()
    {

        
        volumeobject.SetActive(true);
        

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
       
    }
    /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "GameScene")
  
            SceneSettings();
        }*/

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void TogglePostProcessing()
    {
        if (pp_toggle.isOn == true)
        {
            m_Volume.enabled = true;
            PP_bool = true;
        }
        else
        {
            m_Volume.enabled = false;
            PP_bool = false;
        }
    }
    public void ToggleBloom()
    {
        if (bloom_toggle.isOn == true)
        {
            m_Bloom.active = true;
            Bloom_bool = true;
        }
        else
        {
            m_Bloom.active = false;
            Bloom_bool = false;

        }
    }
    public void ToggleAmbientOcclusion()
    {
        if (AO_toggle.isOn == true)
        {
            
            m_AO.active = true;
            AO_bool = true;
        }
        else
        {
            m_AO.active = false;
            AO_bool = false;
        }
    }
    public void ToggleMotionBlur()
    {
        if (Motion_Blur_toggle.isOn == true)
        {
            m_mb.active = true;
            Mb_bool = true;
        }
        else
        {
            m_mb.active = false;
            Mb_bool = false;
        }
        
    }

    
    private void Awake()
    {

        GetInfo();
        Initiallize();
  
    }
    void GetInfo()
    {
        m_Volume.profile.TryGetSettings(out m_Bloom);
        m_Volume.profile.TryGetSettings(out m_AO);
        m_Volume.profile.TryGetSettings(out m_mb);
    }
    void Initiallize()
    {
        pp_toggle.isOn = true;
        bloom_toggle.isOn = true;
        AO_toggle.isOn = true;
        Motion_Blur_toggle.isOn = true;

        m_Volume.enabled = true;
        m_Bloom.active = true;
        m_AO.active = true;
        m_mb.active = true;

    }
    



}
   

    
