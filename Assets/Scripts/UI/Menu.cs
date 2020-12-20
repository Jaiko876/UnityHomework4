using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        private Button _button;
        private bool _isPaused;

        public void InitializeMenu()
        {
            _button = GetComponentInChildren<Button>();
            _button.onClick.AddListener(Restart);
            _isPaused = false;
            gameObject.SetActive(false);
        }

        public void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    Resume();       
                }
                else
                {
                    Pause();
                }
            }
        }
        
        private void Resume()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            _isPaused = false;
        }

        private void Pause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            _isPaused = true;
        }

        public bool IsPaused
        {
            get => _isPaused;
            set => _isPaused = value;
        }
        
        public void Restart()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(activeScene);
            SceneManager.LoadScene(activeScene.buildIndex);
            _isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
