using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class NetworkGUIManager : NetworkLobbyManager
{
    public GameObject serverListWraper;
    public GameObject serverJoinButton;
    public Text loadingText;
    public Text notFoundText;
    public NetworkLobbyManager lobby;

	// Use this for initialization
	void Start()
    {
        this.StartMatchMaker();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void create()
    {
        matchMaker.CreateMatch("test",(uint)maxPlayers,true,"", "", "", 0, 0,OnMatchCreate);
        ServerChangeScene(lobbyScene);
    }

    public void search()
    {
        notFoundText.gameObject.SetActive(false);
        loadingText.gameObject.SetActive(true);
        for (int i = 0; i < serverListWraper.transform.childCount; i++)
        {
            Destroy(serverListWraper.transform.GetChild(i).gameObject);
        }
        matchMaker.ListMatches(0, 10, "", true, 0, 0, this.onSearched);
        
    }

    public void onSearched(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        loadingText.gameObject.SetActive(false);
        if (matches.Count == 0)
        {
            notFoundText.gameObject.SetActive(true);
            return;
        }
        foreach (MatchInfoSnapshot match in matches)
        {
            GameObject server = Instantiate(serverJoinButton) as GameObject;
            server.GetComponentInChildren<Text>().text = match.name + " の部屋";
            server.GetComponent<Button>().onClick.AddListener(() => {
                joinServer(match.networkId);
            });
            server.transform.SetParent(serverListWraper.transform, false);
        }
    }

    public void joinServer(NetworkID networkId)
    {
        matchMaker.JoinMatch(networkId, "", "","", 0,0,OnMatchJoined);
        ServerChangeScene(lobbyScene);
    }
}