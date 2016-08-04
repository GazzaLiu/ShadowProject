using UnityEngine;
using System.Collections;

public class Field: MonoBehaviour {
    protected float charge;
    protected int type;
    protected Vector3 direction;

	void Start () {
	}

	void Update () {	
	}

    public void setCharge(float charge) {
        this.charge = charge;
    }

    public void setType(int type) {
        this.type = type;
    }

   public void setDirection(Vector3 direction){
        this.direction = direction;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.GetComponent<Entity>() && collider.gameObject != transform.parent.gameObject)
        {
            float otherCharge = collider.gameObject.GetComponent<Entity>().getCharge();
            if (otherCharge!=0)
            {
                if (type == 0)
                {
                    //point charge
                    float distance = Vector3.Distance(transform.position, collider.gameObject.transform.position);
                    direction = (transform.position - collider.gameObject.transform.position);
                    direction.Normalize();
                    Vector3 force = charge * otherCharge / Mathf.Pow(distance, 2) * -direction;
                    if(float.IsNaN(force.x))
                    {
                        force = Vector3.zero;
                    }
                    collider.attachedRigidbody.AddForce(force);
                }
                else if (type == 1)
                {
                    //parallel charged plates
                    //just set the direction in the beginning
                    collider.attachedRigidbody.AddForce(charge * otherCharge * direction);
                }

            }
        }
    }
}
