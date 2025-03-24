using Photon.Pun;
using Player;
using UnityEngine;

namespace Mechanic
{
    using UnityEngine;
    using Photon.Pun;

    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        private Vector3 _direction;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"🔥 La bala tocó: {other.name} (Tag: {other.tag})");

            if (other.CompareTag("Player"))
            {
                PlayerHealth playerHealth = other.GetComponentInChildren<PlayerHealth>();

                if (playerHealth != null)
                {
                    Debug.Log("⚡ Ejecutando TakeDamage en el jugador golpeado...");
                    playerHealth.TakeDamage();
                }
                else
                {
                    Debug.LogError("❌ No se encontró el componente PlayerHealth en el jugador.");
                }

                PhotonNetwork.Destroy(gameObject);
            }
        }

    }
}
