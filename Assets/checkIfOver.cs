using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfOver : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("3RD Person Cowboy");
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.activeSelf)
        {
            Destroy(gameObject);
        }
    }
}
