using System;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
   [SerializeField] private Plane floor;


   private void Start()
   {

   }

   private void SpawnPlayer()
   {
      PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
   }

   

}
