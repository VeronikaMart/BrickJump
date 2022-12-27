using UnityEngine;

namespace StackJump.Brick
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private BrickFactory brickFactory;
        [Tooltip("Position where spawn objects are created")]
        [SerializeField] private Transform spawnerTransform;

        private void OnEnable()
        {
            brickFactory.InstantiateObject(spawnerTransform);
        }
    }
}