using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UniCraft.MenuSystem
{
    /// <inheritdoc/>
    /// <summary>
    /// Module to load scene
    /// </summary>
    [AddComponentMenu("UniCraft/MenuSystem/SceneLoader")]
    [DisallowMultipleComponent]
    public sealed class SceneLoader : MonoBehaviour
    {
        ///////////////////////////////
        ////////// Attribute //////////
        ///////////////////////////////

        ///////////////////////////////
        ////////// Component //////////
        
        [SerializeField] private Slider _progressBar = null;
        
        /////////////////////////////////
        ////////// Unity Event //////////

        [SerializeField] private UnityEvent _onStartLoadingSceneEvents = null;
        
        ////////////////////////////
        ////////// Method //////////
        ////////////////////////////
        
        /////////////////////////
        ////////// API //////////
        
        public void LoadSceneByIndex(int sceneIndex)
        {
            StartCoroutine(LoadScene(SceneManager.LoadSceneAsync(sceneIndex)));
        }
        
        public void LoadSceneByName(string sceneName)
        {
            StartCoroutine(LoadScene(SceneManager.LoadSceneAsync(sceneName)));
        }
        
        /////////////////////////////
        ////////// Service //////////

        private IEnumerator LoadScene(AsyncOperation asyncOperation)
        {
            _onStartLoadingSceneEvents.Invoke();
            while ( !asyncOperation.isDone )
            {
                if ( _progressBar )
                {
                    _progressBar.value = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                }
                yield return null;
            }
        }
    }
}
