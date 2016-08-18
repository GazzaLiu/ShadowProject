using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos;
        pos.x = Mathf.Lerp(player.transform.position.x, transform.position.x, 0.9f);
        //pos.y = Mathf.Lerp(player.transform.position.y, transform.position.y, 0.9f);
        pos.y = transform.position.y;
        pos.z = transform.position.z;
        transform.position = pos;
	}
}
