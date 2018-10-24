using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
//using Photon.Pun.Demo.Asteroids;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace Photon.Pun.Demo.Asteroids
{
    public class LauncherZL : MonoBehaviourPunCallbacks
    {
        public GameObject cube;
        string gameVersion = "1";
        public GameObject PlayerListEntryPrefab;
        public InputField nameField;

        public List<Image> imageLocations; 
        
        #region UNITY

        public void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

        }

        #endregion

        #region PUN CALLBACKS

        public override void OnConnectedToMaster()
        {
            Debug.Log("ZL调用了OnConnectedToMaster方法");
//            PhotonNetwork.JoinRandomRoom();
//            RoomOptions options = new RoomOptions {MaxPlayers = 6};
//            PhotonNetwork.CreateRoom("roomTest", options, null);
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("ZL调用了----OnJoinedLobby");
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("执行了+++OnRoomListUpdate方法"+roomList.Count);
            for (int i = 0; i < roomList.Count; i++)
            {
                Debug.Log("房间的信息:"+roomList[i].Name);
            }
//            ClearRoomListView();
//            UpdateCachedRoomList(roomList);
//            UpdateRoomListView();
        }

        public override void OnLeftLobby()
        {
//            cachedRoomList.Clear();
//
//            ClearRoomListView();
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("创建房间失败");
            //SetActivePanel(SelectionPanel.name);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.Log("加入房间失败---");
            //SetActivePanel(SelectionPanel.name);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
//            string roomName = "Room " + Random.Range(1000, 10000);
//
//            RoomOptions options = new RoomOptions {MaxPlayers = 8};
//
//            PhotonNetwork.CreateRoom(roomName, options, null);
        }

        public override void OnJoinedRoom()
        {

            Debug.Log("加入房间成功");
            Debug.Log("获取到该房间的Player的个数为"+PhotonNetwork.PlayerList.Length);
//            GameObject root = GameObject.Find("Plane");
//            //GameObject oneButton = root.transform.Find("ShunLocation").gameObject;
//            GameObject entry = PhotonNetwork.Instantiate("Player", new Vector3(0,0,0), Quaternion.identity, 0);
//            
//            
//            GameObject root02 = GameObject.Find("Canvas");
//            GameObject oneButton = root02.transform.Find("PlayerSelf").gameObject;
//            GameObject entry02 = PhotonNetwork.Instantiate("Card", oneButton.transform.position, Quaternion.identity, 0).gameObject;
//            //GameObject entry = PhotonNetwork.Instantiate(Resources.Load<GameObject>("Player"));
//            entry02.transform.SetParent(oneButton.gameObject.transform);
//            entry02.transform.localScale = new Vector3(1.0F,1.0F,1.0F);
            int k = PhotonNetwork.PlayerList.Length -1;
            
            while (k>=0)
            {
                Player p = PhotonNetwork.PlayerList[k];
                Debug.Log("该房间中用户名称为："+p.NickName);
                GameObject imageloca = imageLocations[k].gameObject;   
                GameObject entryPlayer = PhotonNetwork.Instantiate("Card", imageloca.transform.position, Quaternion.identity, 0).gameObject;
                entryPlayer.transform.SetParent(imageloca.transform);
                entryPlayer.transform.localScale = new Vector3(1.0F,1.0F,1.0F);
                k--;
            }
            
            
            
            foreach (Player p in PhotonNetwork.PlayerList)
            {
//                Debug.Log("该房间中用户名称为："+p.NickName);
               // PhotonNetwork.Instantiate(PlayerListEntryPrefab)
//                GameObject entry = Instantiate(Resources.Load<GameObject>("Player"));
//                entry.transform.SetParent(this.transform);
//                entry.transform.localScale = new Vector3(30,30,30);
//             
               // entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);
                if (PhotonNetwork.PlayerList.Length == 3)
                {
                    
                }
                if (PhotonNetwork.PlayerList.Length == 2)
                {
                    
                }


            }
//        SetActivePanel(InsideRoomPanel.name); 

//            if (playerListEntries == null)
//            {
//                playerListEntries = new Dictionary<int, GameObject>();
//            }
//
//            foreach (Player p in PhotonNetwork.PlayerList)
//            {
//                GameObject entry = Instantiate(PlayerListEntryPrefab);
//                entry.transform.SetParent(InsideRoomPanel.transform);
//                entry.transform.localScale = Vector3.one;
//                entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);
//
//                object isPlayerReady;
//                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
//                {
//                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
//                }
//
//                playerListEntries.Add(p.ActorNumber, entry);
//            }
//
//            StartGameButton.gameObject.SetActive(CheckPlayersReady());
//
//            Hashtable props = new Hashtable
//            {
//                {AsteroidsGame.PLAYER_LOADED_LEVEL, false}
//            };
//            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        }

        public override void OnLeftRoom()
        {
            Debug.Log("执行了OnLeftRoom");
//            SetActivePanel(SelectionPanel.name);
//
//            foreach (GameObject entry in playerListEntries.Values)
//            {
//                Destroy(entry.gameObject);
//            }
//
//            playerListEntries.Clear();
//            playerListEntries = null;
        }
        

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("调用了有玩家进入场景的方法OnPlayerEnteredRoom");
            Debug.Log("当前用户列表的个数为："+ PhotonNetwork.PlayerList.Length);
            int k = PhotonNetwork.PlayerList.Length -1;
            if (k == 1)
            {
                Player p = PhotonNetwork.PlayerList[k];
                Debug.Log("该房间中用户名称为："+p.NickName);
                GameObject imageloca = imageLocations[k].gameObject;   
                GameObject entryPlayer = PhotonNetwork.Instantiate("Card", imageloca.transform.position, Quaternion.identity, 0).gameObject;
                entryPlayer.transform.SetParent(imageloca.transform);
                entryPlayer.transform.localScale = new Vector3(1.0F,1.0F,1.0F);
               
            }

            if (k == 2)
            {
                Player p = PhotonNetwork.PlayerList[k];
                Debug.Log("该房间中用户名称为："+p.NickName);
                GameObject imageloca = imageLocations[k].gameObject;   
                GameObject entryPlayer = PhotonNetwork.Instantiate("Card", imageloca.transform.position, Quaternion.identity, 0).gameObject;
                entryPlayer.transform.SetParent(imageloca.transform);
                entryPlayer.transform.localScale = new Vector3(1.0F,1.0F,1.0F);
            }

//            GameObject root = GameObject.Find("Plane");
//            //GameObject oneButton = root.transform.Find("ShunLocation").gameObject;
//            Debug.Log("执行了OnPlayerEnteredRoom");
//            //GameObject entry = PhotonNetwork.Instantiate(Resources.Load<GameObject>("Player"));
//            GameObject entry = PhotonNetwork.Instantiate("Player", new Vector3(0,0,0), Quaternion.identity, 1);
//            entry.transform.SetParent(root.transform);
//            entry.transform.localScale = new Vector3(1,1,1);
            

            
            
//            GameObject entry = Instantiate(PlayerListEntryPrefab);
//            entry.transform.SetParent(InsideRoomPanel.transform);
//            entry.transform.localScale = Vector3.one;
//            entry.GetComponent<PlayerListEntry>().Initialize(newPlayer.ActorNumber, newPlayer.NickName);
//
//            playerListEntries.Add(newPlayer.ActorNumber, entry);
//
//            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
//            Destroy(playerListEntries[otherPlayer.ActorNumber].gameObject);
//            playerListEntries.Remove(otherPlayer.ActorNumber);
//
//            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                //StartGameButton.gameObject.SetActive(CheckPlayersReady());
            }
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
//            if (playerListEntries == null)
//            {
//                playerListEntries = new Dictionary<int, GameObject>();
//            }
//
//            GameObject entry;
//            if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
//            {
//                object isPlayerReady;
//                if (changedProps.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
//                {
//                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
//                }
//            }
//
//            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        #endregion

        #region UI CALLBACKS

        public void OnBackButtonClicked()
        {
//            SetActivePanel(SelectionPanel.name);
        }

        public void OnCreateRoomButtonClicked()
        {
//            string roomName = RoomNameInputField.text;
//            roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;
//
//            byte maxPlayers;
//            byte.TryParse(MaxPlayersInputField.text, out maxPlayers);
//            maxPlayers = (byte) Mathf.Clamp(maxPlayers, 2, 8);

//            RoomOptions options = new RoomOptions {MaxPlayers = 6};
//
//            PhotonNetwork.CreateRoom("roomTest", options, null);
            StartCoroutine(CreateOrJoinRoomZl());
        }

        private IEnumerator CreateOrJoinRoomZl()
        {
            //如果运行工程，直接创建或者加入房间的话，需要等待几秒先创建房间，否则会报错。
            yield return new WaitForSeconds(1.0f);

            Debug.Log("CreateOrJoinRoom---------ZL");

            if (!PhotonNetwork.InRoom)
            {
//                PhotonNetwork.JoinOrCreateRoom("RoomOne", new RoomOptions { MaxPlayers = 10 }, null);
                RoomOptions options = new RoomOptions {MaxPlayers = 6};

                PhotonNetwork.CreateRoom("roomTest", options, null);
            }

        }

        public void OnJoinRandomRoomButtonClicked()
        {
            //SetActivePanel(JoinRandomRoomPanel.name);

            PhotonNetwork.JoinRandomRoom();
        }

        public void OnLeaveGameButtonClicked()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void OnLoginButtonClicked()
        {
            string playerName = nameField.text;

            if (PhotonNetwork.IsConnected)
            {
                //LogFeedback("Joining Room...");
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                //LogFeedback("Connecting...");

                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.GameVersion = this.gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public void OnRoomListButtonClicked()
        {
            if (!PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinLobby();
            }

            //SetActivePanel(RoomListPanel.name);

        }

        public void OnStartGameButtonClicked()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            PhotonNetwork.LoadLevel("DemoAsteroids-GameScene");
        }

        #endregion

        private bool CheckPlayersReady()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                return false;
            }

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object isPlayerReady;
                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
                {
                    if (!(bool) isPlayerReady)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearRoomListView()
        {
//            foreach (GameObject entry in roomListEntries.Values)
//            {
//                Destroy(entry.gameObject);
//            }

            //roomListEntries.Clear();
        }

        public void LocalPlayerPropertiesUpdated()
        {
            //StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        private void SetActivePanel(string activePanel)
        {
//            LoginPanel.SetActive(activePanel.Equals(LoginPanel.name));
//            SelectionPanel.SetActive(activePanel.Equals(SelectionPanel.name));
//            CreateRoomPanel.SetActive(activePanel.Equals(CreateRoomPanel.name));
//            JoinRandomRoomPanel.SetActive(activePanel.Equals(JoinRandomRoomPanel.name));
//            RoomListPanel.SetActive(
//                activePanel.Equals(RoomListPanel.name)); // UI should call OnRoomListButtonClicked() to activate this
//            InsideRoomPanel.SetActive(activePanel.Equals(InsideRoomPanel.name));
        }

        private void UpdateCachedRoomList(List<RoomInfo> roomList)
        {
//            foreach (RoomInfo info in roomList)
//            {
//                // Remove room from cached room list if it got closed, became invisible or was marked as removed
//                if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
//                {
//                    if (cachedRoomList.ContainsKey(info.Name))
//                    {
//                        cachedRoomList.Remove(info.Name);
//                    }
//
//                    continue;
//                }
//
//                // Update cached room info
//                if (cachedRoomList.ContainsKey(info.Name))
//                {
//                    cachedRoomList[info.Name] = info;
//                }
//                // Add new room info to cache
//                else
//                {
//                    cachedRoomList.Add(info.Name, info);
//                }
//            }
        }

        private void UpdateRoomListView()
        {
//            foreach (RoomInfo info in cachedRoomList.Values)
//            {
//                GameObject entry = Instantiate(RoomListEntryPrefab);
//                entry.transform.SetParent(RoomListContent.transform);
//                entry.transform.localScale = Vector3.one;
//                entry.GetComponent<RoomListEntry>().Initialize(info.Name, (byte) info.PlayerCount, info.MaxPlayers);
//
//                roomListEntries.Add(info.Name, entry);
//            }
        }

        public void BiggerButtonAction()
        {
            if (PhotonNetwork.IsConnected)
            {
//                PhotonNetwork.JoinOrCreateRoom("xiaogeformax", new RoomOptions {MaxPlayers = 16}, null);
                Debug.Log("连接成功后----变大按钮");
                cube.transform.localScale = new Vector3(3, 3, 3);
                //PhotonNetwork.JoinRandomRoom();
//                string roomName = "Room " + Random.Range(1000, 10000);
//
//                RoomOptions options = new RoomOptions {MaxPlayers = 8};
//
//                PhotonNetwork.CreateRoom(roomName, options, null);
            }


        }
    }
}