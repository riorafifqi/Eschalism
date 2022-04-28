using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{
    const string glyphs = "ABCDEFGHIJLMNOPQRSTUVWXYZ";
    public string roomPassword;
    public TMP_InputField joinInput;
    public TextMeshProUGUI roomPass;
    public InputField usernameInput;

    public GameObject playPanel;
    public GameObject roomPanel;
    public GameObject accountPanel;
    public GameObject menuPanel;
    public TextMeshProUGUI title;

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }
    
    public void SetUsername()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            accountPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }

    public void CreateRoom()
    {
        roomPassword = "";
        for (int i = 0; i < 5; i++)
        {
            roomPassword += glyphs[Random.Range(0, glyphs.Length)];
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;
        PhotonNetwork.CreateRoom(roomPassword, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        roomPanel.SetActive(true);
        playPanel.SetActive(false);
        title.gameObject.SetActive(false);
        roomPass.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        roomPanel.SetActive(false);
        playPanel.SetActive(true);
        title.gameObject.SetActive(true);

    }

    void UpdatePlayerList()
    {
        // Delete and Clear PlayerItem List
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        // Check if player is in room
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        // Instantiate PlayerItem
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            playerItemsList.Add(newPlayerItem);

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
}
