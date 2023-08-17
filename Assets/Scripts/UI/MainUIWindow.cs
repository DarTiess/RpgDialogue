using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainUIWindow: MonoBehaviour
    {
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
    
}