using Photon.Pun;
using UnityEngine.SceneManagement;

namespace MidnightTestTask.Scripts.Multiplayer
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
