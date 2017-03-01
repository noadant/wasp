using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class onHexagon : NetworkBehaviour
{
    public Player player;
    [SyncVar]
    public Color color;

    void OnMouseEnter()
    {
        player.Move(this.gameObject);
    }

    void OnMouseOver()
    {
        if (GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().is_started && Input.GetMouseButton(0))
        {
            player.CmdAttack(this.gameObject);
        }
    }

    void Update()
    {
        if(!player)
        {
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject playerObject in playerObjects)
            {
                if (!playerObject.GetComponent<Player>().isLocalPlayer) continue;
                player = playerObject.GetComponent<Player>();
            }
        }

        this.GetComponent<SpriteRenderer>().color = color;
    }

    void Start()
    {
        color = Color.white;
        if(player && !player.isLocalPlayer)
        {
            player = null;
        }
    }
}
