using UnityEngine;

namespace StackJump.Misc
{
    public class Pause : MonoBehaviour
    {
        private void Start()
        {
            PauseGame(false);
        }

        public void PauseGame(bool paused)
        {
            if (paused)
                Time.timeScale = 0;

            else
                Time.timeScale = 1;
        }
    }
}