using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    private GameObject oyuncu;
	private bool die;
	private _Random random;
    void Start()
    {
		random=GameObject.Find("_Script").GetComponent<_Random>();
        oyuncu=GameObject.Find("Oyuncu");
    }

    void Update()
    {
		if(!die){
			float distance=Vector3.Distance(oyuncu.transform.position,transform.position);
			if(distance<2.5f){
				GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
			}
			else{
				GetComponentInChildren<Animation>().Play("Zombie_Walk_01");
			}
			GetComponent<NavMeshAgent>().destination=oyuncu.transform.position;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag.Equals("bullet")){
			GetComponent<NavMeshAgent>().destination=transform.position;
			die=true;
			GetComponentInChildren<Animation>().Play("Zombie_Death_01");
			Destroy(gameObject,1.667f);
			random.downCount();
		}
	}
	
}