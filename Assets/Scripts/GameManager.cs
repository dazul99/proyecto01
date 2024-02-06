using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Vector3 startpos;
    private int firststage = 55;
    private int secondstage = 100;
    private Vector3 spawn;


    private UIManager uimanager;

    private int miny = -5;
    private float goal = 188f;
    private int vidas = 3;


    // Start is called before the first frame update
    void Start()
    {
        startpos = player.transform.position;
        uimanager = FindObjectOfType<UIManager>();
        uimanager.Hidepanel();
        uimanager.Updatelives(vidas);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= miny) 
        {
            vidas--;
            if (player.transform.position.z >= firststage)
            {
                if (player.transform.position.z >= secondstage) spawn = new Vector3(startpos.x, startpos.y, secondstage);

                else spawn = new Vector3(startpos.x, startpos.y, firststage);
            }
            else spawn = startpos;
            
            player.transform.position = spawn;
            player.transform.rotation = Quaternion.identity;

            uimanager.Updatelives(vidas);

            if (vidas == 0)
            {
                uimanager.Gameover();
                gameover();
            }
        }
        else if (player.transform.position.z >= goal)
        {
            uimanager.Win(vidas);
            gameover();
        }
    }

    private void gameover()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
