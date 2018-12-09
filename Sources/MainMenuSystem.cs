using UnityEngine;
using UnityEngine.Events;

namespace UniCraft.MenuSystem
{
    /// <inheritdoc/>
    /// <summary>
    /// Module to manage main menu
    /// </summary>
    [AddComponentMenu("UniCraft/MenuSystem/MainMenu")]
    [DisallowMultipleComponent]
    public sealed class MainMenuSystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        //////////////////////////////////////////
        ////////// Introduction Setting //////////

        [Header("Introduction Setting")]
        [SerializeField] private KeyCode _keyToPress = KeyCode.A;
        [SerializeField] private bool _useAnyKey;
        private bool _bIsIntroductionDone;
        
        /////////////////////////////////
        ////////// Unity Event //////////
        
        [Header("Unity Event")]
        [SerializeField] private UnityEvent _onStartIntroductionEvents;
        [SerializeField] private UnityEvent _onOpenMainMenuPanelEvents;
        [SerializeField] private UnityEvent _onOpenSettingsPanelEvents;
        [SerializeField] private UnityEvent _onOpenCreditsPanelEvents;
        [SerializeField] private UnityEvent _onExitGameEvents;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////
        ////////// API //////////
        
        public void OpenMainMenuPanel()
        {
            _onOpenMainMenuPanelEvents.Invoke();
        }

        public void OpenSettingsPanel()
        {
            _onOpenSettingsPanelEvents.Invoke();
        }

        public void OpenCreditsPanel()
        {
            _onOpenCreditsPanelEvents.Invoke();
        }
        
        public void ExitGame()
        {
            _onExitGameEvents.Invoke();
            Application.Quit();
        }
        
        ////////////////////////////////////////////
        ////////// MonoBehaviour callback //////////

        private void Start()
        {
            _onStartIntroductionEvents.Invoke();
        }

        private void Update()
        {
            if ( (!_bIsIntroductionDone) && (_useAnyKey) && (Input.anyKey) )
            {
                OpenMainMenuPanel();
                _bIsIntroductionDone = true;
            }
            else if ( (!_bIsIntroductionDone) && (Input.GetKeyDown(_keyToPress)) )
            {
                OpenMainMenuPanel();
                _bIsIntroductionDone = true;
            }
        }
    }
}
