using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class follow : MonoBehaviour
{
    // Start is called before the first frame upda
	private GameObject oyuncu;
    void Start()
    {
        oyuncu=GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination=oyuncu.transform.position;
    }
}
