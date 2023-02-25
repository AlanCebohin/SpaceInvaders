using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    public static LivesManager instance;
    private int livesCounter = 3;

    private GameObject[] livesImageUI = new GameObject[3];
    private GameObject panelLives;
    private Color UIImageColor;

    private void Awake() {
        instance = this;
        UIImageColor = new Color(1f, 1f, 1f, 0.5f);
    }

    private void Start() {
        panelLives = GameObject.Find("PanelLives");
        livesImageUI = new GameObject[panelLives.transform.childCount];
        GetLivesImageUI();
    }

    public void RemoveLife()
    {
        if (livesCounter > 0)
        {
            livesCounter--;
            SetLivesImageUI();
            if (livesCounter > 0)
            {
                Invoke("Respawn", 2f);
            }
        }
        else if (livesCounter == 0)
        {
            GameManager.instance.GameOver();
        }
    }

    public void Respawn()
    {
        Instantiate(ship, new Vector3(0, -4.25f, 0), Quaternion.identity);
    }

    public void SetLivesImageUI()
    {
        livesImageUI[livesCounter].GetComponent<Image>().color = UIImageColor;
    }

    public void GetLivesImageUI()
    {
        for (int i = 0; i < panelLives.transform.childCount; i++)
        {
            livesImageUI[i] = panelLives.transform.GetChild(i).gameObject;
        }
    }
}
