using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class GameManager : NetworkBehaviour {
    public bool lose;
    public Canvas canvas;
    public GameObject enemy;
    public int playerCount;
    private GameObject countDownText;
    [SyncVar]
    public bool is_finished;
    [SyncVar]
    public bool is_started;

	// Use this for initialization
	void Start () {
        is_finished = false;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
	}

    void Update()
    {
        if (is_finished)
        {
            if (lose) {
                foreach(Transform child in canvas.transform)
                {
                    if (child.name == "LoseText")
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                foreach (Transform child in canvas.transform)
                {
                    if (child.name == "WinText")
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }

            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject playerObject in playerObjects)
            {
               playerObject.SetActive(true);
            }
        }
    }

    public void StartCountDown(int count)
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.name == "CountDownText")
            {
                countDownText = child.gameObject;
                countDownText.SetActive(true);
                break;
            }
        }
        Invoke("CountDown", 1);
    }

    private void CountDown()
    {
        int count = int.Parse(countDownText.GetComponent<Text>().text);
        count--;
        countDownText.GetComponent<Text>().text = count.ToString();
        if(count == 0)
        {
            countDownText.SetActive(false);
            is_started = true;
        } else
        {
            Invoke("CountDown", 1);
        }
    }
}
