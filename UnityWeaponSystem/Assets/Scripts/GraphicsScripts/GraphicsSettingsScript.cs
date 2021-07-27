using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;


public class GraphicsSettingsScript : MonoBehaviour
{
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;

    public PostProcessVolume m_Volume;
    public Bloom m_Bloom = null;
    public AmbientOcclusion m_AO = null;
    public MotionBlur m_mb = null;

    public Toggle pp_toggle;
    public Toggle bloom_toggle;
    public Toggle AO_toggle;
    public Toggle Motion_Blur_toggle;

    
    void Start()
    {
        m_Volume.profile.TryGetSettings(out m_Bloom);
        m_Volume.profile.TryGetSettings(out m_AO);
        m_Volume.profile.TryGetSettings(out m_mb);
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
    public void EnablePostProcessing()
    {
        if (pp_toggle.isOn == true)
        {
            m_Volume.enabled = true;
        }
        else
        {
            m_Volume.enabled = false;
        }
    }
    public void EnableBloom()
    {
        if (bloom_toggle.isOn == true)
        {
            m_Bloom.active = true;
        }
        else
        {
            m_Bloom.active = false;

        }
    }
    public void EnableAmbientOcclusion()
    {
        if (AO_toggle.isOn == true)
        {
            m_AO.active = true;
        }
        else
        {
            m_AO.active = false;
        }
    }
    public void EnableMotionBlur()
    {
        if (Motion_Blur_toggle.isOn == true)
        {
            m_mb.active = true;
        }
        else
        {
            m_mb.active = false;
        }
        
    }
      
    

}
   

    
