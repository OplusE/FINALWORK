using UnityEngine;
using System.Collections;

/// <summary>
/// 传送门
/// </summary>
public class TranDoor : MonoBehaviour
{

    public GameObject target;//要传送到的目标
	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}

    void OnCollisionEnter(Collision c)
    {
        c.collider.gameObject.transform.position = target.transform.position; 
    }
}