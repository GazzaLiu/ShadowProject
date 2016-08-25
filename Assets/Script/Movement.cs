using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Animator anim;
    int jump_state;
	float mass;
	bool jumpable = true;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		mass = rb.mass;
		jump_state = Animator.StringToHash("Base Layer.player_jump");
    }

    // Update is called once per frame
    void Update () {

        anim.SetBool("walk", false);
		anim.SetBool("jump", false);

	Vector3 force = new Vector3(20.0f, 0, 0) * mass;
        bool move = false;
        if (Input.GetKey("d")) {
            transform.localEulerAngles = new Vector3(0, 0, 0);
	    	rb.AddForce(force);
            move = true;
        }
        else if (Input.GetKey("a")) {
            transform.localEulerAngles = new Vector3(0, 180, 0);
	    	rb.AddForce(-force);
            move = true;
        }

        if (Input.GetKey("w")) {
			if (jumpable) {
				//if (anim.GetCurrentAnimatorStateInfo(0).nameHash != jump_state && !anim.IsInTransition(0)) {
					anim.SetBool("jump", true);
					anim.SetBool("isGround", false);
					jumpable = false;

				//move = true;
				rb.AddForce(new Vector3(0.0f, 360.0f, 0.0f) * mass);
				//}
			}

        }

        if (move) {
            anim.SetBool("walk", true);
        }
    }

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "ground") {
			jumpable = true;
			anim.SetBool("isGround", true);
		}
	}
}
