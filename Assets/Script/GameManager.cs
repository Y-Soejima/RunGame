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
    public int EndTime { get => m_endTime; set => m_endTime = value; }
    public  GameObject m_player;
    [SerializeField] Text m_scoreText;
    [SerializeField] Text m_timeText;
    [SerializeField] Button m_restart;
    static int[] m_scoreRanking = new int[10];
    public int[] ScoreRanking { get; set; }
    [SerializeField] Text[] m_rankingText = new Text[10];
    [SerializeField] GameObject m_textCamvas;
    public Subject<Unit> m_gameStart = new Subject<Unit>();
    Subject<Unit> m_gameEnd = new Subject<Unit>();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        m_restart.gameObject.SetActive(false);
        m_textCamvas.gameObject.SetActive(false);
        m_timeText.text = m_endTime.ToString("D2");
        m_gameStart.Subscribe(_ => StartCoroutine(GameCountDown()));
        m_gameStart.Subscribe(_ => StartCoroutine(GameScore()));
        m_gameEnd.Subscribe(_ => GameEnd());
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        m_timeText.text = m_endTime.ToString("D2");
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
            yield return new WaitForSeconds(1);
        }
        m_gameEnd.OnNext(Unit.Default);
    }

    IEnumerator GameScore()
    {
        while(m_endTime > 0)
        {
            if (m_player != null)
            {
                m_score += 1000 * m_scoreRate;
                m_scoreText.text = m_score.ToString("D10");
            }
            else if (m_player == null)
            {
                m_gameEnd.OnNext(Unit.Default);
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    void GameEnd()
    {
        Time.timeScale = 0;
        if (m_score > m_scoreRanking[9])
        {
            m_scoreRanking[9] = m_score;
            for (int i = 0; i < m_scoreRanking.Length; i++)
            {
                for (int j = i + 1; j < m_scoreRanking.Length; j++)
                {
                    if (m_scoreRanking[i] < m_scoreRanking[j])
                    {
                        int a = m_scoreRanking[i];
                        m_scoreRanking[i] = m_scoreRanking[j];
                        m_scoreRanking[j] = a;
                    }
                }
            }
            for (int i = 0; i < m_scoreRanking.Length; i++)
            {
                m_rankingText[i].text = m_scoreRanking[i].ToString("D10");
            }
        }
        m_textCamvas.gameObject.SetActive(true);
        m_restart.gameObject.SetActive(true);
    }

}
