using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject[] ai;
    public int FlockSize = 0;

    [SerializeField] private GameObject m_score;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    [SerializeField] private GameObject m_playerPlaceholder;


    // Start is called before the first frame update
    void Start()
    {
        ai = GameObject.FindGameObjectsWithTag("AI");
        FlockSize = ai.Length;
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreText.text = FlockSize + "";
        m_score.transform.position = m_playerPlaceholder.transform.position;
    }
}
