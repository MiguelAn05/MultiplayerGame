using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace NetWork
{
    public class ServerConnection : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            Debug.Log(" Intentando conectar a Photon...");
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Conectado al Master Server. Entrando al Lobby...");
            PhotonNetwork.JoinLobby(); 
        }

        public override void OnJoinedLobby()
        {
            Debug.Log(" Entraste al Lobby de Photon.");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogError($" Desconectado de Photon. Causa: {cause}");
        }
    }
}