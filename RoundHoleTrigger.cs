using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundHoleTrigger : MonoBehaviour
{
    [SerializeField] private HoleManager m_holeManager;

    [SerializeField] private int holeSize;
    [SerializeField] private GameManager gm;
    


    public GameObject character;
    private bool firstExecution = false;



    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("AI"))
        {
            case true:
                other.GetComponent<CrowdController>().m_activeState = false;
                other.GetComponent<CrowdController>().m_leader = null;
                other.GetComponent<CapsuleCollider>().enabled = false;


                other.GetComponent<SlerpScript>().sunrise = other.transform;
                other.GetComponent<SlerpScript>().sunset = m_holeManager.ReturnCounter();
                other.GetComponent<SlerpScript>().enabled = true;

                other.GetComponent<AISeparator>().enabled = false;

                other.transform.parent = m_holeManager.m_point;

                if (firstExecution == false)
                {
                    SpawnExtraCharacters(22);
                    SpawnExtraCharacters(7);
                    gm.FlockSize -= holeSize;
                    firstExecution = true;
                }
                m_holeManager.m_holeSize -= 1;
                break;
            case false:
                break;
        }
    }

    public void SpawnExtraCharacters(int noOfCharacters)
    {
        for (int i = 0; i < noOfCharacters; i++)
        {
            GameObject obj = Instantiate(character);
            obj.transform.position = this.transform.position;
            character.GetComponent<SlerpScript>().sunrise = character.transform;
            character.GetComponent<SlerpScript>().sunset = m_holeManager.allPoints[9 + i];
            //m_holeManager.m_holeSize -= 1;
            character.GetComponent<SlerpScript>().enabled = true;
        }
    }
}
