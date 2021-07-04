using UnityEngine;
using System.Collections;

public class MoveNpc : MonoBehaviour
{
    

	void Awake ()
	{
        

	}

	void Start ()
	{
        
	}
	
	
	void Update ()
	{
        this.transform.position = new Vector3(Mathf.PingPong(Time.time, 10), transform.position.y, transform.position.z);
	}



}
