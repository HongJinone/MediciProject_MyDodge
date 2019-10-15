using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame {
    public class GameManagerTest : Photon.PunBehaviour {
        //dkdk
        #region Photon Messages

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        #region Photon Messages

        public override void OnPhotonPlayerConnected (PhotonPlayer other) {
            Debug.Log ("OnPhotonPlayerConnected() " + other.name); // not seen if you're the player connecting

            if (PhotonNetwork.isMasterClient) {
                Debug.Log ("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

                LoadArena ();
            }
        }

        public override void OnPhotonPlayerDisconnected (PhotonPlayer other) {
            Debug.Log ("OnPhotonPlayerDisconnected() " + other.name); // seen when other disconnects

            if (PhotonNetwork.isMasterClient) {
                Debug.Log ("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

                LoadArena ();

            }
        }

        #endregion

        public void OnLeftRoom () {

            SceneManager.LoadScene (0);
        }

        #endregion

        #region Public Methods

        [Tooltip ("The prefab to use for representing the player")]

        public Transform[] s_Point;
        public Transform[] s_Cannon;
        public GameObject playerPrefab;
        public GameObject cannonPrefab;
        public GameObject tutorialText;
        public void LeaveRoom () {
            PhotonNetwork.LeaveRoom ();
        }

        #endregion

        #region Private Methods
        private void Start () {
            int i=0;
            int myIndexNumber = System.Array.IndexOf (PhotonNetwork.playerList, PhotonNetwork.player);
            Vector3 location = s_Point[myIndexNumber].position;
            
            
            

            location.y = 0.5f;
            if (playerPrefab == null) {
                Debug.LogError ("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            } else {

                if (PlayerManager.LocalPlayerInstance == null) {
                    Debug.Log ("We are Instantiating LocalPlayer from " + Application.loadedLevelName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                    PhotonNetwork.Instantiate (this.playerPrefab.name, location, s_Point[myIndexNumber].rotation, 0);
                } else {
                    Debug.Log ("Ignoring scene load for " + Application.loadedLevelName);
                }
            }
            Debug.Log(myIndexNumber);
            if(PhotonNetwork.isMasterClient){
                for (i = 0; i < 6; i++)
                {
                    PhotonNetwork.Instantiate (this.cannonPrefab.name, s_Cannon[i].position, s_Cannon[i].rotation, 0);
                }
            }
            
        }

        void LoadArena () {
            if (!PhotonNetwork.isMasterClient) {
                Debug.LogError ("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.Log ("PhotonNetwork : Loading Level : " + PhotonNetwork.room.playerCount);
            //PhotonNetwork.LoadLevel ("Roomfor" + PhotonNetwork.room.playerCount);
        }

        void OnLevelWasLoaded (int level) {
            // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
            if (!Physics.Raycast (transform.position, -Vector3.up, 5f)) {
                transform.position = new Vector3 (0f, 5f, 0f);
            }
        }

        
        #endregion
    }
}