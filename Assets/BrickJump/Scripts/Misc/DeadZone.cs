using BrickJump.Observer;
using UnityEngine;

namespace BrickJump.Misc
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] GameEvent PlayerDeathEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8) // Player layer
            {
                PlayerDeathEvent.TriggerEvent();
            }
        }
    }
}