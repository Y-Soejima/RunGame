using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    [SerializeField] int m_scoreRate = 1;
    public int ScoreRate { get; set; }
    [SerializeField] int m_score;
    [SerializeField] int m_endTime;
    [SerializeField] GameObject m_player;
    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_timeText;
    Subject<Unit> m_gameStart = new Subject<Unit>();
    // Start is called before the first frame update
    void Start()
    {
        m_timeText.text = m_endTime.ToString("D2");
        m_gameStart.Subscribe(_ => StartCoroutine(GameCountDown()));
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_player != null || m_endTime >= 0)
        {
            m_score += 1000 * m_scoreRate;
            m_scoreText.text = m_score.ToString("D10");
        }
    }

    IEnumerator CountDown()
    {
        int time = 3;
        while(time > 0)
        {
            Debug.Log(time);
            time -= 1;
            yield return new WaitForSeconds(1);
        }
        Debug.Log("start");
        m_gameStart.OnNext(Unit.Default);
    }

    IEnumerator GameCountDown()
    {
        while(m_endTime > 0)
        {
            m_endTime -= 1;
            m_timeText.text = m_endTime.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
