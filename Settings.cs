using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class Settings : MonoBehaviour
{
    public AudioMixer src;
    public Toggle volumeToggle;
    public Dropdown antiAliasingMenu;
    public PostProcessLayer layer;
    public Dropdown filteringMenu;
    public Toggle windowToggle;
    public PostProcessProfile profile;
    public Slider gammaSlider;

    public void MasterVolume()
    {
        if(volumeToggle.isOn)
        {
            src.SetFloat("Volume", 0);
        }
        else
        {
            src.SetFloat("Volume", -80);
        }
    }
    public void AntiAliasing()
    {
        if(antiAliasingMenu.value==0)
        {
            layer.antialiasingMode = PostProcessLayer.Antialiasing.None;
        }
        else if(antiAliasingMenu.value==1)
        {
            layer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        }
        else if (antiAliasingMenu.value == 2)
        {
            layer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
        }

    }
    public void AnisotropicFiltering()
    {
        if(filteringMenu.value==0)
        {
            QualitySettings.anisotropicFiltering = UnityEngine.AnisotropicFiltering.Disable;
        }
        if (filteringMenu.value == 1)
        {
            QualitySettings.anisotropicFiltering = UnityEngine.AnisotropicFiltering.Enable;
        }
        if (filteringMenu.value == 2)
        {
            QualitySettings.anisotropicFiltering = UnityEngine.AnisotropicFiltering.ForceEnable;
        }

    }
    public void Window()
    {
        if(windowToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow
;
        }
    }
    public void Gamma()
    {
        profile.GetSetting<ColorGrading>().postExposure.value = gammaSlider.value;
    }
}
