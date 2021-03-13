using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float degreesPerSecond = 50.0f;
    public GameObject playerGameObject;
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("player");
        Debug.Assert(playerGameObject != null);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Heart Collided!");
        if(collision.collider.tag == "player")
        {
        playerGameObject.GetComponent<HitController>().HealPlayer(20);
        Destroy(gameObject);
        }
    }
}
