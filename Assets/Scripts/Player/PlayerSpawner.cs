using Photon.Pun;
using UnityEngine;



namespace Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPointA;
        [SerializeField] private Transform spawnPointB;
        [SerializeField] private GameObject playerPrefab;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Vector3 spawnPosition = PhotonNetwork.IsMasterClient ? spawnPointA.position : spawnPointB.position;
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);


            PlayerHealth playerHealth = player.GetComponentInChildren<PlayerHealth>();
            playerHealth.SetSpawnPoints(spawnPointA.position,spawnPointB.position);
        }

    }
}
