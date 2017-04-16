using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ReadyButton : MonoBehaviour {
    public NetworkLobbyPlayer networkLobbyPlalyer;
	// Use this for initialization
	void Start () {
        if (!networkLobbyPlalyer.isLocalPlayer) this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (networkLobbyPlalyer.readyToBegin)
        {
            networkLobbyPlalyer.SendReadyToBeginMessage();
            this.gameObject.SetActive(false);
        }
	}
}
