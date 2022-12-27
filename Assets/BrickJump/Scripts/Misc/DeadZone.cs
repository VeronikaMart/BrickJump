using StackJump.Observer;
using UnityEngine;

namespace StackJump.Misc
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] GameEvent PlayerDeathEvent;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                PlayerDeathEvent.TriggerEvent();
            }
        }
    }
}