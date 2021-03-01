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
    public AudioSource music;
    public AudioClip boom;
    public AudioClip pickup;
    public AudioClip dropoff;


    // Start is called before the first frame update
    void Start()
    {
        soldiermax = 4;
        music.Play();
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
                music.PlayOneShot(pickup, 1f);
            }

        }
        if(collision.gameObject.tag == "Tree")
        {
            music.Stop();
            this.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            music.PlayOneShot(boom, 1f);
        }
        if (collision.gameObject.tag == "Hospital" && soldiercount > 0)
        {
            hospicount += soldiercount;
            soldiercount = 0;
            music.PlayOneShot(dropoff, 1f);

        }
    }
    void TimeSet()
    {
        timeresult = Time.timeSinceLevelLoad;
    }
}

