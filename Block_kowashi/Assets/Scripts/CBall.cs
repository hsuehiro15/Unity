using UnityEngine;
using System.Collections;

public class CBall : MonoBehaviour {

       public float INIT_DEGREE = 75f;
       public float INIT_SPEED = 250f;

	// Use this for initialization
	void Start () {
	  shotBall();
	}
	
	// Update is called once per frame
	void Update () {
           rigidbody.velocity += Vector3.Normalize(rigidbody.velocity)*2.0f;
	}

         void shotBall(){
           Vector3 vel = Vector3.zero;
           vel.x = INIT_SPEED*Mathf.Cos(INIT_DEGREE*Mathf.PI/180f);           
           vel.y = INIT_SPEED*Mathf.Sin(INIT_DEGREE*Mathf.PI/180f);
           rigidbody.velocity = vel;
         }

        void OnCollisionEnter(Collision col){
             if(col.gameObject.CompareTag("Block")){
                   Destroy(col.gameObject);
             }
        }


}