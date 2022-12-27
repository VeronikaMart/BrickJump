using StackJump.Values;
using UnityEngine;

namespace StackJump.Misc
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