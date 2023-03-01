using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class _Random : MonoBehaviour
{
    public GameObject zombi;
	private float sayac=0f;
	private float olusumSuresi=5f;
	private GameObject go;
	private bool create=false;
	private int countZombie=0;
	
    void Update()
    {
		sayac-=Time.deltaTime;
		Vector3 pos=new Vector3(Random.Range(900,2100),231,Random.Range(-120,980));
		if(NavMesh.SamplePosition(pos,out NavMeshHit hit,1f,NavMesh.AllAreas))
			if(sayac<0&&countZombie<20){
				go=Instantiate(zombi,pos,Quaternion.identity);
				sayac=olusumSuresi;
				create=true;
				upCount();
			}
		if(create==true)
			if(go.transform.position.y<=230.3f){
				Destroy(go);
				create=false;
				downCount();
			}
	}
	
	public void upCount(){
		countZombie++;
	}
	public void downCount(){
		countZombie--;
	}
}
