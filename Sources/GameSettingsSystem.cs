using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UniCraft.MenuSystem
{
    /// <inheritdoc/>
    /// <summary>
    /// Module to adjust the game settings
    /// </summary>
    [AddComponentMenu("UniCraft/MenuSystem/GameSettingsSystem")]
    [DisallowMultipleComponent]
    public sealed class GameSettingsSystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private AudioMixer _audioMixer = null;
        [SerializeField] private Dropdown _resolutionDropdown = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////

        /////////////////////////
        ////////// API //////////
        
        public void AdjustQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void AdjustResolution(int resolutionIndex)
        {
            var resolution = Screen.resolutions[resolutionIndex];
            
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        
        public void AdjustVolume(int volume)
        {
            _audioMixer.SetFloat("volume", volume);
        }

        public void ManageFullscreen(bool bActive)
        {
            Screen.fullScreen = bActive;
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour callback //////////

        private void Awake()
        {
            if ( _resolutionDropdown != null )
            {
                SetupResolutionDropdown();
            }
        }
        
        /////////////////////////////
        ////////// Service //////////

        private void SetupResolutionDropdown()
        {
            var currentResolutionIndex = 0;
            var resolutionOptions = new List<string>();
            
            _resolutionDropdown.ClearOptions();
            for (var resolutionIndex = 0; resolutionIndex < Screen.resolutions.Length; resolutionIndex++)
            {
                resolutionOptions.Add(Screen.resolutions[resolutionIndex].width.ToString() + " x " +
                                      Screen.resolutions[resolutionIndex].height.ToString());
                if ( (Screen.resolutions[resolutionIndex].width == Screen.currentResolution.width)
                    && (Screen.resolutions[resolutionIndex].height == Screen.currentResolution.height) )
                {
                    currentResolutionIndex = resolutionIndex;
                }
            }
            _resolutionDropdown.AddOptions(resolutionOptions);
            _resolutionDropdown.value = currentResolutionIndex;
            _resolutionDropdown.RefreshShownValue();
        }
    }
}
