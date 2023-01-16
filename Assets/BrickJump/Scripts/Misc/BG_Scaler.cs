using UnityEngine;

namespace BrickJump.Misc
{
    public class BG_Scaler : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = (SpriteRenderer)GetComponent("SpriteRenderer");
        }

        // Fit background to screen parameters
        private void Start()
        {
            Vector3 tempScale = transform.localScale;

            float width = spriteRenderer.sprite.bounds.size.x;
            float worldHeight = Camera.main.orthographicSize * 2;
            float worldWidth = worldHeight / Screen.height * Screen.width;

            tempScale.x = worldWidth / width;
            transform.localScale = tempScale;
        }
    }
}