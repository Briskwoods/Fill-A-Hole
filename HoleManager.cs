using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{

    public int m_holeSize;
    
    public Transform m_point;
    
    [SerializeField] private GameObject m_trigger;
   
    private int InitialHoleSize;

    public List<Transform> allPoints = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        InitialHoleSize = m_holeSize;
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_holeSize <= 0)
        {
            case true:
                m_trigger.SetActive(false);
                break;
            case false: break;
        }


        if (m_holeSize<0)
        {
            Delete();

        }


    }
    public IEnumerator Delete()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    public Transform ReturnCounter()
    {
        return allPoints[InitialHoleSize - m_holeSize];
    }

}
