using UnityEngine;

namespace StackJump.Misc
{
    public class DestroyObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}