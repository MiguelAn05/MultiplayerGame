using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

namespace NetWork
{
    public class Rooms : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField roomNameInput;
        [SerializeField] private byte maxPlayers = 2;

        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.ConnectUsingSettings(); 
            }
        }

        public void CreateOrJoinRoom()
        {
            if (!PhotonNetwork.IsConnectedAndReady) 
            {
                Debug.LogError("No estás conectado a Photon.");
                return;
            }

            if (!string.IsNullOrEmpty(roomNameInput.text))
            {
                RoomOptions roomOptions = new RoomOptions { MaxPlayers = maxPlayers };
                PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, roomOptions, TypedLobby.Default);
            }
        }

        public void LeaveRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        public override void OnJoinedRoom()
        {
            Debug.Log($"✅ Entraste a la sala: {PhotonNetwork.CurrentRoom.Name}");
            CheckPlayersAndStartGame();
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            Debug.Log($"👤 Nuevo jugador en la sala: {newPlayer.NickName}");
            CheckPlayersAndStartGame();
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            Debug.Log($" {otherPlayer.NickName} salió de la sala.");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError($" Fallo al unirse a la sala: {message}");
        }

        public override void OnCreatedRoom()
        {
            Debug.Log(" Sala creada exitosamente.");
        }

        public override void OnLeftRoom()
        {
            Debug.Log(" Saliste de la sala.");
        }

        private void CheckPlayersAndStartGame()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers)
            {
                Debug.Log("🎮 Todos los jugadores están listos. Cargando el nivel...");
                PhotonNetwork.LoadLevel("Game");
            }
        }
    }
}
