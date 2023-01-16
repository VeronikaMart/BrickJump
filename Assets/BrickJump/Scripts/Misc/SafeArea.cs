using UnityEngine;

namespace BrickJump.Misc
{
    public class SafeArea : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Vector2 anchorMin, anchorMax;

        private void Awake()
        {
            rectTransform = (RectTransform)GetComponent("RectTransform");
        }

        private void Start()
        {
            AdjustSafeArea();
        }

        private void AdjustSafeArea()
        {
            var safeArea = Screen.safeArea;
            anchorMin = safeArea.position;
            anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;

            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}