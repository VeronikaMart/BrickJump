using BrickJump.Observer;
using BrickJump.Values;
using UnityEngine;

namespace BrickJump.Brick
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private ParticleSystem effect;
        [SerializeField] private Sprite[] brickSprites;
        [Space]
        [SerializeField] private float minSpeed = 2f;
        [SerializeField] private float maxSpeed = 3f;
        [Space]
        [SerializeField] private int bonusIncrement = 1;
        [Space]
        [SerializeField] private IntVariable colorBonusCurrentValue;
        [SerializeField] private IntVariable transformBonusCurrentValue;
        [Space]
        [SerializeField] private GameEvent GotTransformMatchEvent;
        [SerializeField] private GameEvent GotColorMatchEvent;

        private SpriteRenderer spriteRenderer;

        private Direction direction;
        private bool stopBrick;
        private float speed;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            SetRandomSprite();
        }

        private void Start()
        {
            speed = Random.Range(minSpeed, maxSpeed);
            GetDirection();
        }

        private void LateUpdate()
        {
            MoveTo();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 8) // Player layer
            {
                stopBrick = true;
                CheckBonus();
            }
        }

        public void CheckBonus() // TODO: Move to another script, Edit
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f);

            if (hit.collider != null)
            {
                Transform hitedObjectTranform = hit.transform.gameObject.GetComponent<Transform>();
                SpriteRenderer hitedObjectRender = hit.transform.gameObject.GetComponent<SpriteRenderer>();

                float currentRounded = (float)System.Math.Truncate(10 * transform.position.x) / 10;
                float hitRouned = (float)System.Math.Truncate(10 * hitedObjectTranform.position.x) / 10;

                if (currentRounded.Equals(hitRouned))
                {
                    transform.position = new Vector2(hitedObjectTranform.position.x, transform.position.y);

                    GotTransformMatchEvent.TriggerEvent();
                    transformBonusCurrentValue.ApplyChange(bonusIncrement);

                    effect.Play();
                    Handheld.Vibrate();

                    if (spriteRenderer.sprite == hitedObjectRender.sprite)
                    {
                        GotColorMatchEvent.TriggerEvent();
                        colorBonusCurrentValue.ApplyChange(bonusIncrement);

                        Handheld.Vibrate();
                    }
                }
            }
        }

        private void SetRandomSprite()
        {
            spriteRenderer.sprite = brickSprites[Random.Range(0, brickSprites.Length)];
        }

        // Determine in which corner we are and, based on this, get the direction
        private Direction GetDirection()
        {
            return direction = (transform.position.x > 0) ? Direction.LEFT : Direction.RIGHT;
        }

        private void MoveTo()
        {
            if (!stopBrick)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                        Move(Vector3.left);
                        break;
                    case Direction.RIGHT:
                        Move(Vector3.right);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Move(Vector3 direction)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}