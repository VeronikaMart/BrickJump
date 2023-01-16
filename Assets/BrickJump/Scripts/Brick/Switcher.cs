using UnityEngine;

namespace BrickJump.Brick
{
    public class Switcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] spawners;

        private void Awake()
        {
            TurnOfSpawners();
        }

        public void TurnOfSpawners()
        {
            foreach (var spawner in spawners)
            {
                spawner.gameObject.SetActive(false);
            }
        }

        public void PickRandom()
        {
            var random = Random.Range(0, spawners.Length);
            spawners[random].gameObject.SetActive(true);
        }
    }
}