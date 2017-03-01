using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {
    private GameObject myHexagon;
    public GameObject hexagon;
    public GameObject currentHexagon;
    [SyncVar]
    public Color color;
    // Use this for initialization
    void Start () {
        myHexagon = this.transform.GetChild(0).gameObject;
        if(isServer)
        {
            color = isLocalPlayer ? Color.cyan : Color.red;
        }
        if (!isLocalPlayer)
        {
            GameObject.Find("GameManager(Clone)").GetComponent<GameManager>().StartCountDown(10);
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Color currentColor = currentHexagon.GetComponent<onHexagon>().color;
        if (currentColor != Color.white && currentColor != color)
        {
            CmdFinish();
            GameManager gm = GameObject.Find("GameManager(Clone)").GetComponent<GameManager>();
            gm.lose = true;
        }
	}

    public void Move(GameObject hexagon)
    {
        currentHexagon = hexagon;
        float z = myHexagon.transform.position.z;
        Vector3 position = currentHexagon.transform.position;
        Color color = currentHexagon.GetComponent<SpriteRenderer>().color;
        this.transform.position = new Vector3(position.x, position.y, z);
        myHexagon.transform.position = new Vector3(position.x, position.y, z);
        myHexagon.GetComponent<SpriteRenderer>().color = color;
    }

    [Command]
    public void CmdAttack(GameObject hexagonObject)
    {
        hexagonObject.GetComponent<onHexagon>().color = this.color;
    }
    [Command]
    public void CmdFinish()
    {
        GameManager gm = GameObject.Find("GameManager(Clone)").GetComponent<GameManager>();
        gm.is_finished = true;
    }
}
