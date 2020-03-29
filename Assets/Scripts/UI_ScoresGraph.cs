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
    public GameObject infoText;
    public Text topText;
    public Text middleText;

    private Text infoTextComp;
    private Color c;
    private float height;
    private float width;
    private float ymax = 100f;
    private RectTransform currLineRect;

    //private List<double> forces;
    private int count;

    private List<GameObject> points = new List<GameObject>();
    private List<GameObject> cns = new List<GameObject>();

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
        height = graphContainer.rect.height - 10;
        width = graphContainer.rect.width - 10;
        //Debug.Log(height + ", " + width);

        infoTextComp = infoText.transform.GetChild(0).GetComponent<Text>();
        c = infoTextComp.color;

        List<int> scores = GlobalController.GetScores(1);
        ShowGraph(scores);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GoBackToMainMenu();
        }
    }

    void FixedUpdate() {
        if(infoText.activeSelf == true && infoTextComp.color.a > 0){
            c.a -= 0.005f;
            infoTextComp.color = c;
        } else {
            c.a = 1;
            infoTextComp.color = c;
            infoText.SetActive(false);
        }
    }

    void PlotPoint(Vector2 pos){
        GameObject pt = new GameObject("GraphPt", typeof(Image));
        pt.transform.SetParent(graphContainer, false);
        pt.gameObject.tag = "Graph Point";
        pt.GetComponent<Image>().sprite = ptSprite;
        pt.GetComponent<Image>().color = Color.cyan;
        RectTransform ptRect= pt.GetComponent<RectTransform>();
        points.Add(pt);
        ptRect.anchoredPosition = pos;
        ptRect.sizeDelta = new Vector2(3, 3);
        ptRect.anchorMin = new Vector2(0.02f, 0.02f);
        ptRect.anchorMax = new Vector2(0.02f, 0.02f);
    }

    void PlotConnection(Vector2 pos1, Vector2 pos2){
        GameObject cn = new GameObject("GraphPt", typeof(Image));
        cn.transform.SetParent(graphContainer, false);
        cn.gameObject.tag = "Graph Point";
        //cn.GetComponent<Image>().sprite = cnSprite;
        cn.GetComponent<Image>().color = Color.cyan;
        RectTransform cnRect= cn.GetComponent<RectTransform>();
        cns.Add(cn);

        Vector2 dir = (pos2 - pos1).normalized;
        float dist = Vector2.Distance(pos1, pos2);

        cnRect.anchoredPosition = pos1 + dir * dist * 0.5f;
        cnRect.sizeDelta = new Vector2(dist, 2);
        cnRect.anchorMin = new Vector2(0.02f, 0.02f);
        cnRect.anchorMax = new Vector2(0.02f, 0.02f);
        cnRect.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(pos2.y - pos1.y, pos2.x - pos1.x) * 180 / Mathf.PI);
    }

    void ShowGraph(List<int> val){
        //forces = new List<double>(val);
        if(val.Count == 0)
            return;
        count = val.Count;
        ymax = 1.1f * Mathf.Max( Mathf.Abs((float)val.Max()), Mathf.Abs((float)val.Min()) );

        topText.text = ymax.ToString("F0");
        middleText.text = (ymax / 2).ToString("F0");

        float xPos =  0;
        float yPos = (float)val[0] / ymax * height;
        Vector2 currPt = new Vector2(xPos, yPos);
        PlotPoint(currPt);
        Vector2 prevPt = currPt;

        for (int i = 1; i < count; i++)
        {
            xPos =  ((float)(i) / (count-1)) * width;
            yPos = (float)val[i] / ymax * height;
            currPt = new Vector2(xPos, yPos);
            PlotPoint(currPt);
            PlotConnection(prevPt, currPt);
            prevPt = currPt;
        }
    }

    public void ChooseGraph(int idx) {
        
        foreach (GameObject g in points)
        {
            Destroy(g);
        }

        foreach (GameObject g in cns)
        {
            Destroy(g);
        }
        
        switch(idx) {
            case 0: ShowGraph(GlobalController.GetScores(1));
                    break;
            case 1: ShowGraph(GlobalController.GetScores(2));
                    break;
            case 2: ShowGraph(GlobalController.GetScores(3));
                    break;
        }
    }
    
    public void GoToScoresCurrent() {
        SceneManager.LoadScene("Scores_CurrentSession");
    }
    
    public void GoToScoresLeaderboard() {
        if(GlobalController.currUser != "GUEST")
            PlayGamesController.ShowLeaderboardUI();
        else {
            infoText.SetActive(true);
            c.a = 1;
            infoTextComp.color = c;
        }
    }

    public void GoBackToMainMenu() {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
