using UnityEngine;

namespace BrickJump.Misc
{
    public class DestroyObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}