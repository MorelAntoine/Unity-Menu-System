using UnityEngine;
using UnityEngine.Events;

namespace UniCraft.MenuSystem
{
    /// <inheritdoc/>
    /// <summary>
    /// Module to manage pause menu
    /// </summary>
    [AddComponentMenu("UniCraft/MenuSystem/PauseMenu")]
    [DisallowMultipleComponent]
    public sealed class PauseMenuSystem : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        [SerializeField] private UnityEvent _onOpenMenuEvents = null;
        [SerializeField] private UnityEvent _onCloseMenuEvents = null;
        [SerializeField] private UnityEvent _onOpenSettingsPanelEvents = null;
        [SerializeField] private UnityEvent _onQuitGameEvents = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        public void OpenMenu()
        {
            Time.timeScale = 0f;
            _onOpenMenuEvents.Invoke();
        }
        
        public void CloseMenu()
        {
            Time.timeScale = 1f;
            _onCloseMenuEvents.Invoke();
        }
        
        public void OpenSettingsPanel()
        {
            _onOpenSettingsPanelEvents.Invoke();
        }
        
        public void QuitGame()
        {
            Time.timeScale = 1f;
            _onQuitGameEvents.Invoke();
        }        
    }
}
