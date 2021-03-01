using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myRigid;
    public int soldiercount;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victory;
    public TextMeshProUGUI finaltime;
    public Text heliSoldiers;
    public Text goalSoldiers;
    public int hospicount;
    private int soldiermax;
    private float timeresult;
    // Start is called before the first frame update
    void Start()
    {
        soldiermax = 4;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        Vector2 myForce = new Vector2(hori, verti);
        myRigid.AddForce(myForce * speed);
        heliSoldiers.text = "Sldrs in Heli: " + soldiercount + ", Time: " + Time.timeSinceLevelLoad;
        goalSoldiers.text = "Sldrs saved: " + hospicount + "/" + soldiermax;
        TimeSet();
        if (hospicount == soldiermax)
        {
            this.gameObject.SetActive(false);
            victory.gameObject.SetActive(true);
            finaltime.gameObject.SetActive(true);
            finaltime.text = "Final Time: " + timeresult;
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision!");
        if (collision.gameObject.tag == "Soldier")
        {
            if (soldiercount < 3)
            {
                collision.gameObject.SetActive(false);
            
                soldiercount++;
            }

        }
        if(collision.gameObject.tag == "Tree")
        {
            this.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Hospital")
        {
            hospicount += soldiercount;
            soldiercount = 0;

        }
    }
    void TimeSet()
    {
        timeresult = Time.timeSinceLevelLoad;
    }
}

