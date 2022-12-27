using System.Collections;
using UnityEngine;

namespace StackJump.Brick
{
    public class Mover : MonoBehaviour
    {
        [Tooltip("Offset relative to the position of the starting platform and between platforms.")]
        [SerializeField] private float platformOffset = 0.55f;
        [SerializeField] private float timeBetweenSpawn = 2f;

        private BrickTag brickTag;
        private Switcher switcher;

        private void Awake()
        {
            brickTag = FindObjectOfType<BrickTag>();
            switcher = GetComponent<Switcher>();

            GetStartPosition();
        }

        private void Start()
        {
            StartCoroutine(ActivateMover());
        }

        // Depends on Player speed, time between spawn and platform offset
        IEnumerator ActivateMover()
        {
            // if GameStarted
            while (true)
            {
                // Enable random
                switcher.PickRandom();
                // Move up
                MoveSpawner();

                switcher.TurnOfSpawners();
                yield return new WaitForSeconds(timeBetweenSpawn);
            }
        }

        private void MoveSpawner()
        {
            transform.Translate(0f, platformOffset, 0f);
        }

        private Vector2 GetStartPosition()
        {
            return transform.position = new Vector2(0f, brickTag.transform.position.y + platformOffset);
        }
    }
}