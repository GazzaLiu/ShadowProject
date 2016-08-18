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
    public void setCharge(float newCharge) {
        charge = newCharge;
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
    void OnCollisionStay(Collision collision) {
        
        if (collision.gameObject.GetComponent<Entity>())
        {
            Entity otherEntity = collision.gameObject.GetComponent<Entity>();
            float otherCharge = otherEntity.getCharge();
            if (otherCharge > charge)
            {
                otherEntity.setCharge(otherCharge - 1);
                charge++;
            }
            else if (otherCharge < charge)
            {
                otherEntity.setCharge(otherCharge + 1);
                charge--;
            }
        }
    }
}
