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
                private Transform _player; 

                public void SetSpawnPoints(Vector3 pointA, Vector3 pointB)
                {
                        _spawnPointA = pointA;
                        _spawnPointB = pointB;
                }

                private void Start()
                {
                        _player = transform.parent; 
                        _photonView = _player.GetComponent<PhotonView>();  

                        if (_photonView.IsMine)
                        {
                                Respawn(); 
                        }

                        transform.localPosition = Vector3.zero; 
                }

                public void TakeDamage()
                {
                        if (_photonView == null)
                        {
                                Debug.LogError("❌ _photonView es NULL en TakeDamage()");
                                return;
                        }

                        if (_photonView.IsMine) // 🔹 Solo el jugador golpeado ejecuta el RPC
                        {
                                _deaths++;
                                Debug.Log($"💀 Jugador ha muerto! Total muertes: {_deaths}");

                                Vector3 newSpawnPosition = PhotonNetwork.IsMasterClient ? _spawnPointA : _spawnPointB;

                                Debug.Log($"📡 Intentando enviar RPC_Respawn a {newSpawnPosition}");

                                _photonView.RPC("RPC_Respawn", RpcTarget.AllBuffered, newSpawnPosition);
                        }
                }

                public void Respawn()
                {
                        Vector3 respawnPosition = PhotonNetwork.IsMasterClient ? _spawnPointA : _spawnPointB;
                        _player.position = respawnPosition; 
                        Debug.Log($"🔄 Respawn en {respawnPosition}");
                }
        }

}


