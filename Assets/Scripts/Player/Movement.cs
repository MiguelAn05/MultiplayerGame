using Mechanic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform firePoint; // 🔹 Referencia al firePoint

        private Rigidbody2D _rb;
        private bool _isGrounded;
        private bool _facingRight = true; // 🔹 Para saber hacia dónde está mirando el jugador

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!GetComponent<PhotonView>().IsMine) return; // Solo controla su propio jugador

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

            if ((moveInput > 0 && !_facingRight) || (moveInput < 0 && _facingRight))
            {
                Flip();
            }
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            transform.localScale = new Vector3(_facingRight ? 1 : -1, 1, 1);
            firePoint.localScale = new Vector3(_facingRight ? 1 : -1, 1, 1);
        }

        private void Jump()
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        }

        private void CheckGround()
        {
            float rayLength = 0.2f;
            Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);
            _isGrounded = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
        }
        
       
    }

}


