using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_ScoresGraph : MonoBehaviour
{
    //public Text textForce;
    public Sprite ptSprite;
    public Sprite cnSprite;
    public Sprite lineSprite;
    public RectTransform graphContainer;

    private float height;
    private float width;
    private float ymax = 100f;
    private RectTransform currLineRect;

    //private List<double> forces;
    private int count;

    private void Awake() {

        //Plot the current state time line
        /*GameObject line = new GameObject("Current State line", typeof(Image));
        line.transform.SetParent(graphContainer, false);
        line.GetComponent<Image>().sprite = lineSprite;
        currLineRect = line.GetComponent<RectTransform>();
        currLineRect.anchoredPosition = new Vector2(0, 0);
        currLineRect.sizeDelta = new Vector2(1, height);
        currLineRect.anchorMin = new Vector2(0, 0.5f);
        currLineRect.anchorMax = new Vector2(0, 0.5f);*/
    }

    void Start() {
        height = graphContainer.rect.height;
        width = graphContainer.rect.width;
        Debug.Log(height + ", " + width);

        List<int> scores = new List<int>();
        for(int i = 0; i < 10; i++)
            scores.Add(UnityEngine.Random.Range(0, 100));
        ShowGraph(scores);
    }

    void PlotPoint(Vector2 pos){
        GameObject pt = new GameObject("GraphPt", typeof(Image));
        pt.transform.SetParent(graphContainer, false);
        pt.gameObject.tag = "Graph Point";
        pt.GetComponent<Image>().sprite = ptSprite;
        RectTransform ptRect= pt.GetComponent<RectTransform>();
        ptRect.anchoredPosition = pos;
        ptRect.sizeDelta = new Vector2(3, 3);
        ptRect.anchorMin = new Vector2(0, 0);
        ptRect.anchorMax = new Vector2(0, 0);
    }

    void PlotConnection(Vector2 pos1, Vector2 pos2){
        GameObject cn = new GameObject("GraphPt", typeof(Image));
        cn.transform.SetParent(graphContainer, false);
        cn.gameObject.tag = "Graph Point";
        //cn.GetComponent<Image>().sprite = cnSprite;
        RectTransform cnRect= cn.GetComponent<RectTransform>();

        Vector2 dir = (pos2 - pos1).normalized;
        float dist = Vector2.Distance(pos1, pos2);

        cnRect.anchoredPosition = pos1 + dir * dist * 0.5f;
        cnRect.sizeDelta = new Vector2(dist, 2);
        cnRect.anchorMin = new Vector2(0, 0);
        cnRect.anchorMax = new Vector2(0, 0);
        cnRect.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(pos2.y - pos1.y, pos2.x - pos1.x) * 180 / Mathf.PI);
    }

    public void ShowGraph(List<int> val){
        //forces = new List<double>(val);
        count = val.Count;
        ymax = 1.1f * Mathf.Max( Mathf.Abs((float)val.Max()), Mathf.Abs((float)val.Min()) );

        Vector2 prevPt = new Vector2();
        for (int i = 0; i < count; i++)
        {
            float xPos =  ((float)(i) / (count-1)) * width;
            float yPos = (float)val[i] / ymax * height;
            Vector2 currPt = new Vector2(xPos, yPos);
            PlotPoint(currPt);
            PlotConnection(prevPt, currPt);
            prevPt = currPt;
        }
    }
    
    public void GoToScoresCalendar() {
        SceneManager.LoadScene("Scores_Calendar");
    }
    
    public void GoToScoresLeaderboard() {
        SceneManager.LoadScene("Scores_Leaderboard");
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
