using Photon.Pun;
using UnityEngine;

namespace NetWork
{
    public class Rooms : MonoBehaviourPunCallbacks
    {
        [SerializeField] private string roomName;
        [ContextMenu("Create")]
    
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(roomName);
        }

        [ContextMenu("Join")]
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        
        [ContextMenu("Leave")]
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();
            print("sala creada");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            print($"coneccion fallida \nCode: {returnCode} Message: {message}");
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            print("se conecto");
            PhotonNetwork.LoadLevel("Game");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            print($"coneccion fallida \nCode: {returnCode} Message: {message}");
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            print("a salido de la sala !");
        }
        
        
    }
}
