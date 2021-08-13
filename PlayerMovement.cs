using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_playerController;
    [SerializeField] private float m_speed;
    
    public float PlatformWidth = 2.7f;
    public float MaxFingerDistance = 250f;
    
    private Vector3 InitialPosition;

    private float DistanceFromCenter;
    private float Direction;
    private float Percent;
    private float XPos;



    // Start is called before the first frame update
    void Start()
    {
     m_playerController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        m_playerController.Move(Vector3.forward * m_speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            InitialPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 IP = InitialPosition;
            Vector3 IMP = Input.mousePosition;
            IP.y = 0f;
            IMP.y = 0f;
            DistanceFromCenter = Vector3.Distance(IP, IMP);
            Direction = (IP - IMP).x;
            if (Direction > 0 && transform.position.x > -PlatformWidth)
            {
                //moving to the left
                Percent = (DistanceFromCenter / MaxFingerDistance);
                XPos = (-PlatformWidth * Percent);
            }
            else if (Direction < 0 && transform.position.x < PlatformWidth)
            {
                //Moving to the Right
                Percent = (DistanceFromCenter / MaxFingerDistance);
                XPos = (PlatformWidth * Percent);
            }
            else if (Direction < 0 && transform.position.x > PlatformWidth)
            {
                XPos = PlatformWidth;
            }
            else if (Direction > 0 && transform.position.x < -PlatformWidth)
            {
                XPos = -PlatformWidth;
            }
            else
            {
                XPos = transform.position.x;
            }
            if (XPos < PlatformWidth && XPos > -PlatformWidth)
            {
                transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            }
        }
    }
}
