using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerConfig : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private PhotonView _photonView;

        private void Start()
        {
            _playerHealth = GetComponentInChildren<PlayerHealth>(); 
        }

        [PunRPC]
        private void RPC_Respawn(Vector3 newPosition)
        {
            Debug.Log($"🔄 Respawn ejecutado en {newPosition}");

            if (_photonView.IsMine) // 🔹 Solo afecta al jugador local
            {
                transform.parent.position = newPosition;
            }
        }

    }
}