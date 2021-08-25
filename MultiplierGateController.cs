using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierGateController : MonoBehaviour
{
    [SerializeField] private GameObject clone;
    [SerializeField] private GameObject m_player;

    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private Transform FollowPoint;

    [SerializeField] private int gateSize;

    [SerializeField] private int ScoreValue;
    [SerializeField] private GameManager gm;


    private bool firstExecution = false;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("AI"))
        {
            case true:
                if (firstExecution == false)
                {
                    SpawnExtraCharacters(gateSize);
                    gm.FlockSize *= ScoreValue;
                    firstExecution = true;
                }
                break;
            case false:
                break;
        }
    }

    public void SpawnExtraCharacters(int noOfCharacters)
    {
        for (int i = 0; i < noOfCharacters; i++)
        {
            GameObject obj = Instantiate(clone, m_spawnPoint);
            clone.GetComponent<SlerpScript>().enabled = false;
            clone.transform.parent = m_player.transform.parent;
            clone.GetComponent<AISeparator>().enabled = true;
            clone.GetComponent<AISeparator>().m_spaceBetween = 1.5f;
            clone.GetComponent<CrowdController>().m_spaceBetween = 2f;
            clone.GetComponent<CrowdController>().m_leader = FollowPoint;
            clone.GetComponent<CrowdController>().m_activeState = true;
        }
    }
}
