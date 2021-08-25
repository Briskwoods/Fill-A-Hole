using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("AI"))
        {
            case true:
                other.transform.parent = null;
                other.transform.parent.parent = null;
                other.transform.parent.parent.parent = null;
                other.transform.parent = this.transform;
                other.GetComponent<CrowdController>().enabled = false;
                other.GetComponent<CapsuleCollider>().enabled = false;
                other.GetComponent<AISeparator>().enabled = false;  
                other.GetComponent<SlerpScript>().enabled = false;
                other.GetComponent<Animator>().SetBool("Dead", true);
                break;
            case false:
                break;
        }
    }
}
