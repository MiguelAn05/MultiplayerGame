using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private Vector3 _spawnPointA;
        private Vector3 _spawnPointB;
        private int _deaths = 0;
        private PhotonView _photonView;
        private Transform player; 

        public void SetSpawnPoints(Vector3 pointA, Vector3 pointB)
        {
            _spawnPointA = pointA;
            _spawnPointB = pointB;
        }

        private void Start()
        {
            _photonView = GetComponentInParent<PhotonView>(); 
            player = transform.parent; 
            transform.localPosition = Vector3.zero; 

            Respawn(); 
        }

        public void TakeDamage()
        {
            if (_photonView == null)
            {
                Debug.LogError(" _photonView es NULL en TakeDamage()");
                return;
            }

            if (_photonView.IsMine) 
            {
                _deaths++;
                Debug.Log($" Jugador ha muerto! Total muertes: {_deaths}");
            
                // Respawn en lugar de destruir el objeto
                player.position = PhotonNetwork.IsMasterClient ? _spawnPointA : _spawnPointB;
            }
        }
        
        private void Respawn()
        {
            Vector3 respawnPosition = PhotonNetwork.IsMasterClient ? _spawnPointA : _spawnPointB;
            transform.position = respawnPosition;
        }
    }
}
