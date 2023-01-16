using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrickJump.Player
{
    public class PlayerJump : MonoBehaviour, PlayerControls.IPlayerActions
    {
        [Tooltip("Distance between platform and player")]
        [SerializeField] private float rayDistance = .1f;
        [SerializeField] private int jumpForce = 200;
        [SerializeField] private LayerMask groundMask;

        private Animator animator;
        private Rigidbody2D rb;
        private PlayerControls controls;
        private AudioSource audioSource;
        private bool canTound;

        private bool CheckForLanding()
        {
            return Physics2D.BoxCast(transform.position, Vector2.one , 0f, Vector2.down, rayDistance, groundMask)
                ? true : false;
        }

        private void Start()
        {
            canTound = true;

            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            controls = new PlayerControls();
            audioSource = GetComponent<AudioSource>();

            // Reference to class, will call methods
            controls.Player.SetCallbacks(this);
            controls.Player.Enable();
        }

        private void OnDestroy()
        {
            controls.Player.Disable();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CheckForLanding();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && CheckForLanding() && canTound)
            {
                // Check number of touches in 1 second
                if (Input.touchCount >= 1)
                {
                    canTound = false;

                    animator.SetTrigger("Fly");
                    audioSource.Play();
                    rb.AddForce(Vector2.up * jumpForce);

                    StartCoroutine(Timer());
                }
            }
        }

        IEnumerator Timer()
        {
            yield return new WaitForSeconds(1f);
            canTound = true;
        }
    }
}