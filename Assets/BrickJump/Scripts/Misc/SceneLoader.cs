using UnityEngine;
using UnityEngine.SceneManagement;

namespace StackJump.Misc
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}