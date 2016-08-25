using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    //set public only for test
    public float charge;
	public int type;
	public Vector3 dir;
    public bool isConductor;
    protected bool isTerrain;

    public GameObject field;

    public float getCharge() {
        return charge;
    }
    public void setCharge(float newCharge) {
        charge = newCharge;
    }
	public bool getConductive() {
		return isConductor;
	}

	// Use this for initialization
	void Start () {
        //charge = 3.0F;
        //isConductor = true;
        isTerrain = false;
		field.GetComponent<Field> ().setType (type);
		field.GetComponent<Field> ().setDirection (dir);
	}
	
	// Update is called once per frame
	void Update () {
        field.GetComponent<Field>().setCharge(charge);
	}
    void OnCollisionStay(Collision collision) {

        if (collision.gameObject.GetComponent<Entity>())
        {
			bool isOtherConductive = collision.gameObject.GetComponent<Entity> ().getConductive ();
			if (!isOtherConductive || !isConductor) 
			{
				return;
			}

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
