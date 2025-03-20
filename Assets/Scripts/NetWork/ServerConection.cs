using System;
using UnityEngine;
using Photon.Pun;
namespace NetWork
{
    public class ServerConection : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnected()
        {
            base.OnConnected();
            print("is conected");
        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Conectado master ");
            PhotonNetwork.JoinLobby();
        }

       
        
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            print("is joined");
        }
        
        
    }
}
