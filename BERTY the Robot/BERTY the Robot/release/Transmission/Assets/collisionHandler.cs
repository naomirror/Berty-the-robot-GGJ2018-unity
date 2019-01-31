using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionHandler : MonoBehaviour {

    public Sprite state1; // Drag your first sprite here
    public Sprite state2; // Drag your second sprite here
    public GameObject goodButton;
    public GameObject badButton;
    public GameObject boole;
    public GameObject cHappy;
    public GameObject cSad;
    public Text txt;
    private SpriteRenderer spriteRenderer;
    string savedMessage;
    public Text t;
    int gOverall = 0;
    int bOverall = 0;
    int gBed = 0;
    int bBed = 0;
    int gComp = 0;
    int bComp = 0;
    int gWin = 0;
    int bWin = 0;
    int gCat = 0;
    int bCat = 0;
    int gBowl = 0;
    int bBowl = 0;
    int gFridge = 0;
    int bFridge = 0;

    void Start()
    {
        
        t.gameObject.SetActive(false);
        goodButton.SetActive(false);
        goodButton.GetComponent<Button>().onClick.AddListener(delegate { swapState(true); });
        badButton.SetActive(false);
        badButton.GetComponent<Button>().onClick.AddListener(delegate { swapState(false); });
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = state1; // set the sprite to sprite1
        if (cHappy !=null && cSad != null)
        {
            cHappy.SetActive(false);
            cSad.SetActive(false);
        }

    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        goodButton.SetActive(true);
        badButton.SetActive(true);

    }

    private void swapState(bool good)
    {

        if (spriteRenderer.sprite == state1 && good) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = state2;
        }
        else if (spriteRenderer.sprite == state2 && !good)
        {
            spriteRenderer.sprite = state1; // otherwise change it back to sprite1
        }
        if (good)
            {
            t.text = "" + ((int.Parse(t.text)) + 1);
        }
        else
        {
            t.text = "" + ((int.Parse(t.text)) - 1);
        }
        goodButton.SetActive(false);
        badButton.SetActive(false);
        if (gameObject.name != "computer" || (gameObject.name == "computer" && !good))
        {
            setTextMessage(good);
        }
        else
        {

            if (txt.text == "")
            {
                txt.text = "no new transmissions";

            }
            
            getTransmission();
        }
    }

    private void setTextMessage(bool good)
    {
        string[] positiveEnd = new string[] { "amazingly", "very well", "prodigiously","outstandingly", "pretty well"};
        string[] negativeEnd = new string[] { "awfully", "terribly", "in the worst way imaginable", "miserably" };
        string x;
        string v = "";
        switch (gameObject.name)
        {
            case "bed":
                if (good)
                {
                    v = "made ";
                    gBed++;
                }
                else
                {
                    v = "left ";
                    bBed--;
                }
                    break;
            case "window":
                if (good)
                {
                    v = "let some light in from ";
                    gWin++;
                }
                else
                {
                    bWin++;
                    v = "slinked away from ";
                }
                break;
            case "bowl":
                if (good)
                {
                    gBowl++;
                    cSad.SetActive(false);
                    cHappy.SetActive(true);
                   
                    v = "fed ";
                }
                else
                {
                    bBowl++;
                    cHappy.SetActive(false);
                    cSad.SetActive(true);
                    
                    v = "didn't feed ";

                }
                break;
            case "cat":
                if (good)
                {
                    v = "pet ";
                    cSad.SetActive(false);
                    cHappy.SetActive(true);
                    

                    gCat++;
                }
                else
                {
                    v = "annoyed ";
                    cHappy.SetActive(false);
                    cSad.SetActive(true);
               
                    bCat++;
                }
                break;
            case "fridge":
                if (good)
                {
                    v = "ate a healthy snack from ";
                    gFridge++;
                }
                else
                {
                    v = "ate junk food from ";
                    bFridge++;
                }
                break;
                    
            case "computer":
                if (!good)
                {
                    v = "trolled on ";
                    gComp++;
                }
                else { bComp++; }
                break;
            default:
                if (good)
                    v = "did ";
                else
                    v = "did not ";
                break;
        }
        //if (good) {
           // x = positiveEnd[(int) Random.Range(0, positiveEnd.Length)];
       // }
       // else
        //{
          //  x = negativeEnd[(int) Random.Range(0, negativeEnd.Length)];
        //}
        {
            if (gameObject.name != "bowl")
            {
                txt.text += "you " + v + "the " + gameObject.name + ", ";
            }
            else
            {
                txt.text += "you " + v + "the cat"+ ", ";
            }
        }

        disableText();
    }

    public void getTransmission()
    {
        txt.enabled = true;
        StartCoroutine(pause(2f));
        if (boole.activeInHierarchy == false)
        {
            if (((int.Parse(t.text)) - 1) >= 0)
            {
                StartCoroutine(pause(2f));
                txt.text = "Overall you've done well today little BERTY, keep up the good work";
                StartCoroutine(pause(2f));
            }
            else
            {
                StartCoroutine(pause(2f));
                txt.text = "Overall you've not been a good BERTY, try harder tomorrow";
                StartCoroutine(pause(2f));
            }
        }


    }
    private IEnumerator pause(float time)
    {
        yield return new WaitForSeconds(time);
        txt.text = "";
        disableText();
        boole.SetActive(true);
        spriteRenderer.sprite = state1;
       
    }
    private void disableText()
    {
        txt.enabled = false;
    }
}