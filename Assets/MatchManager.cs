using UnityEngine;
using UnityEngine.Networking.Match;
using System.Collections;

public class MatchManager : MonoBehaviour {
    NetworkMatch networkMatch;

    void Awake()
    {
        networkMatch = gameObject.AddComponent<NetworkMatch>();
    }

    public void createRoom ()
    {

    }
}
