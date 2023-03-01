using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bullet : MonoBehaviour
{
    public Transform mermiS;
	public GameObject mermi;
	public GameObject boom;
	private float canDegeri=1f;
	private bool shoot;
	private float shootTime;
	private float timingS;
	private bool hurt=false;
	private float attackTime=1.667f;
	private float timingA;
	public Image can;
    void Start()
    {
        shoot=false;
		shootTime=0.1f;
    }

    void Update()
    {
		timingS-=Time.deltaTime;
		timingA-=Time.deltaTime;
		if(Input.GetMouseButtonDown(0)){
			shoot=true;
    	}
		if(Input.GetMouseButtonUp(0)){
			shoot=false;
		}
		if(shoot&&timingS<=0f){
			GameObject bom=Instantiate(boom,mermiS.position,mermiS.rotation) as GameObject;
			GameObject go=Instantiate(mermi,mermiS.position,mermiS.rotation) as GameObject;
			go.GetComponent<Rigidbody>().velocity=mermiS.transform.forward*100f;
			Destroy(go,2f);
			Destroy(bom,1f);
			timingS=shootTime;
		}
		if(hurt&&timingA<=0f){
			timingA=attackTime;
			canDegeri-=1f/10f;
			can.fillAmount=canDegeri;
			can.color=Color.Lerp(Color.red,Color.green,canDegeri);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag.Equals("zombi")){
			hurt=true;
		}
	}

	private void OnTriggerExit(Collider other) {
		hurt=false;
	}
}
