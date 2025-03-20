using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private LayerMask groundLayer; 
        private Rigidbody2D _rb;
        private bool _isGrounded;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            CheckGround();

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Move()
        {
            float moveInput = Input.GetAxis("Horizontal");
            _rb.linearVelocity = new Vector2(moveInput * moveSpeed, _rb.linearVelocity.y);
        }

        private void Jump()
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void CheckGround()
        {
            float rayLength = 0.2f;
            Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);

            _isGrounded = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
            Debug.DrawRay(rayOrigin, Vector2.down * rayLength, _isGrounded ? Color.green : Color.red);
        }
    }

}

