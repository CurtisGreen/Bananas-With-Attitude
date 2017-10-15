using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Player player;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Player> ();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
		print ("hello");
        if (collider.gameObject.name == "Player" && player.hostageCount == 4)
        {
            SceneManager.LoadScene("Victory Screen");
        }

    }
}