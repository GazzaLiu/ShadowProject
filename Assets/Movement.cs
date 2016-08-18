using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Animator anim;
    int jump_state;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	rb = GetComponent<Rigidbody>();
        jump_state = Animator.StringToHash("Base Layer.jump");
    }

    // Update is called once per frame
    void Update () {

        anim.SetBool("walk", false);

	Vector3 force = new Vector3(20.0f, 0, 0);
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
            //if (anim.GetCurrentAnimatorStateInfo(0).nameHash != jump_state && !anim.IsInTransition(0)) {
             //   anim.SetTrigger("jump");
            //}
            move = true;
	    rb.AddForce(new Vector3(0.0f, 36.0f, 0.0f));
        }

        if (move) {
            anim.SetBool("walk", true);
        }
    }
}
