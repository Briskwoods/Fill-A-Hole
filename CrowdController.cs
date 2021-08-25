using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    /* NOTE: This script is placed under a crowd entity whose parent is the PLayer object. */

    [SerializeField] private Animator m_player;             // Player Animator 
    [SerializeField] private Animator m_crowdEntity;        // Crowd Entity Animator

    [SerializeField] private GameObject m_self;
 
    public Transform m_leader;                              // Point where the entity crowds to
    public float m_spaceBetween = 1.5f;                     // Distance between crowd entity and chosen leader.

    public bool m_activeState = true;


    void Start()
    {
        m_self = this.gameObject;
        m_self.GetComponent<SlerpScript>().sunrise = m_self.transform;

        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the crowd entity to copy player animations when Running
        switch(m_player.GetBool("Run") && m_activeState == true){
            case true:
                m_crowdEntity.SetBool("Run", true);
                break;
            case false:
                m_crowdEntity.SetBool("Run", false);
                break;
        }

        // Set the crowd entity to copy player animations when Jumping
        switch (m_player.GetBool("Jump") && m_activeState == true)
        {
            case true:
                m_crowdEntity.SetBool("Jump", true);
                break;
            case false:
                m_crowdEntity.SetBool("Jump", false);
                break;
        }

        // Set the crowd entity to copy player animations when Jumping
        switch (m_activeState == false)
        {
            case true:
                m_crowdEntity.SetBool("Run", false);
                break;
            case false:
                break;
        }

        // Part that controls the crowd entity distance to the specified leader
        switch (Vector3.Distance(m_leader.position, transform.position) >= m_spaceBetween)
        {
            case true:
                Vector3 direction = m_leader.position - transform.position;
                transform.localPosition += direction * Time.deltaTime;
                break;
            case false:
                break;
        }

        if (m_activeState == false)
        {
                Delete();
              
        }


    }
        IEnumerator Delete()
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
}
