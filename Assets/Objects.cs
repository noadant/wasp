using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Objects : NetworkBehaviour {
    public GameObject gameManager;
    private GameObject gameManagerPrehab;
    public GameObject hexagon;
    Player player;
    private int centerRawCount = 15;

    void Update()
    {
        if (player) {
            return;
        }
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            player = playerObject.GetComponent<Player>();
            if (!player.isLocalPlayer)
            {
                player = null;
                continue;
            }
            break;
        }
    }

    void Start()
    {
        if (this.isClient) return; 
        gameManagerPrehab = Instantiate(gameManager);
        NetworkServer.Spawn(gameManagerPrehab);
        for (int i = 0; i < centerRawCount; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2));
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }

        for (int i = 0; i < centerRawCount - 1; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2)) + 37;
            position.y += 64.8f;
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }

        for (int i = 0; i < centerRawCount - 1; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2)) + 37;
            position.y -= 64.8f;
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }

        for (int i = 0; i < centerRawCount; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2));
            position.y += 129.6f;
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }

        for (int i = 0; i < centerRawCount; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2));
            position.y -= 129.6f;
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }

        for (int i = 0; i < centerRawCount - 1; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2)) + 37;
            position.y += 64.8f * 3;
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }

        for (int i = 0; i < centerRawCount - 1; i++)
        {
            Vector3 position = this.transform.position;
            position.x += 74 * (i - (int)(centerRawCount / 2)) + 37;
            position.y -= 64.8f * 3;
            GameObject hexagonPrehab = (GameObject)Instantiate(hexagon, position, hexagon.transform.rotation);
            NetworkServer.Spawn(hexagonPrehab);
        }
    }
}
