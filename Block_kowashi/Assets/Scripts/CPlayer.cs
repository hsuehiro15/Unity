using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour {

       public float VEL = 400f;
       public GameObject prefBall;
       public GameObject insBall = null; 
       public bool shotflag = false;        

	// Use this for initialization
	void Start () {
            createholdBall();	
	}
	
	// Update is called once per frame
	void Update () {
            Vector3 npos = transform.position;	
            npos.x = npos.x + VEL*Time.deltaTime*Input.GetAxis("Horizontal");
            rigidbody.MovePosition(npos);
            

                if(insBall != null){
			if (Input.GetButton("Jump")) {
				insBall.rigidbody.isKinematic = false;
                              insBall.SendMessage("shotBall");
                              insBall = null;
			}
		}
	}

        void createholdBall(){
               Vector3 bpos = transform.position;
               bpos.y += (collider.bounds.size.y + prefBall.collider.bounds.size.y)/2f;
               insBall = (GameObject)Instantiate(prefBall,bpos,Quaternion.identity);
               insBall.transform.parent = transform;
               insBall.transform.Rotate(new Vector3(0.0f,0.0f,0.0f));

               insBall.rigidbody.isKinematic = true;

        }


}

