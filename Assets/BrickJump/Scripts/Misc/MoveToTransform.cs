using BrickJump.Values;
using UnityEngine;

namespace BrickJump.Misc
{
    public class MoveToTransform : MonoBehaviour
    {
        [SerializeField] private IntReference highScore;
        private void Awake()
        {
            transform.position = new Vector2(0, highScore.Value);
        }
    }
}