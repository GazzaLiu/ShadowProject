using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    //set public only for test
    public float charge;
    protected bool isConductor;
    protected bool isTerrain;

    public GameObject field;

    public float getCharge() {
        return charge;
    }

	// Use this for initialization
	void Start () {
        //charge = 3.0F;
        isConductor = true;
        isTerrain = false;
	}
	
	// Update is called once per frame
	void Update () {
        field.GetComponent<Field>().setCharge(charge);
	}
}
