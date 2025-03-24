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
            Physics2D.SyncTransforms(); // 🔹 Forzar la actualización de colisiones
    
            Debug.Log($"🔥 La bala tocó: {other.gameObject.name} (Tag: {other.tag})");

            if (other.CompareTag("Player"))
            {
                Debug.Log("🔫 Bala impactó a un jugador!");

                PhotonNetwork.Destroy(gameObject); // 🔹 Destruir la bala

                PlayerHealth playerHealth = other.gameObject.GetComponentInChildren<PlayerHealth>();
        
                if (playerHealth != null)
                {
                    Debug.Log("💀 PlayerHealth encontrado, aplicando daño.");
                    playerHealth.TakeDamage();
                }
                else
                {
                    Debug.LogError("❌ No se encontró PlayerHealth en el jugador.");
                }
            }
        }
    }
}
