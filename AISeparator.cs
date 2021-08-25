using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISeparator : MonoBehaviour
{
    private GameObject[] AI;

    public float m_spaceBetween = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ai in AI)
        {
            switch (ai != gameObject)
            {
                case true:
                    switch (ai != null)
                    {
                        case true:
                            float distance = Vector3.Distance(ai.transform.position, this.transform.position);
                            switch (distance <= m_spaceBetween)
                            {
                                case true:
                                    Vector3 direction = transform.position - ai.transform.position;
                                    transform.localPosition += direction * Time.deltaTime;
                                    break;
                                case false:
                                    break;
                            }
                            break;
                        case false: break;
                    }
                    break;
                case false:
                    break;
            }
        }
    }
}
