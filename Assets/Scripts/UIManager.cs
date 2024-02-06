using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject victory;
    private GameManager gamemanager;

    [SerializeField] private Button restart;
    [SerializeField] private Button winrestart;

    [SerializeField] private TextMeshProUGUI lives;
    [SerializeField]private TextMeshProUGUI score;

    private string X;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        restart.onClick.AddListener(() => { gamemanager.Restart(); });
        winrestart.onClick.AddListener(() => { gamemanager.Restart(); });
    }

    public void Updatelives(int x)
    {
        if (x == 0) lives.text = "";
        else
        {
            X = "LIVES\n";
            for (int i = 0; i < x; i++)
            {
                X += "X ";
            }
            lives.text = X;
        }
    }

    public void Hidepanel()
    {
        gameover.SetActive(false);
        victory.SetActive(false);
    }

    public void Gameover()
    {
        gameover.SetActive(true);
    }

    public void Win(int x)
    {
        victory.SetActive(true);
        lives.text = "";
        score.text = "YOU HAVE DIED: " + (3 - x) + " TIMES";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
