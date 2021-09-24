using UnityEngine;
using UnityEngine.UI;

namespace Script.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public Button startButton;
        public Button quitButton;
        private void Awake()
        {
            Debug.Assert(startButton!=null,"startButton!=null");
            quitButton.onClick.AddListener(Quit);
            startButton.onClick.AddListener(StartGame);
            
        }

        private static void StartGame()
        {
            GameManager.Instance.LoadLevel(1);
            Cursor.lockState = CursorLockMode.Locked;
            GameManager.Instance.objectiveUI.gameObject.SetActive(true);
            GameManager.Instance.sceneNum = 1;
            AudioManager.Instance.Play("Theme1");
        }

        private static void Quit()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}
