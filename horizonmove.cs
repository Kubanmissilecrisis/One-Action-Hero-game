
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class horizonmove : MonoBehaviour
{

    public int diam = 5;
    [SerializeField]
    float movespeed = 5f;

    [SerializeField]
    Transform check;

    

    public Animator animator;
    public Animator animator2;
    public Transform movePoint;
    public float anemyradar;
    public GameObject vertic;
    public Transform hori;
   // public Button buttonright;
   // public Button buttonleft;

    public bool horiup = false;
    public bool horidown = false;
    public bool horiisbig= false;
    public bool horistuckup = false;
    public bool horistuckdown = false;
    public bool noup = true;
    public bool nodown = true;
    public bool noright = true;
    public bool noleft = true;
    public SoundManager sh;
    public bool isright = true;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    { 
       
      
        if (gameObject.tag == "Big")
        {
            if (nowallup(anemyradar))
            {
                noup = true;
            }
            else
            {
                noup = false;
            }
            if (nowalldown(anemyradar))
            {
                nodown= true;
            }
            else
            {
                nodown = false;
            }
            if (nowallright(anemyradar))
            {
                noright = true;
            }
            else
            {
                noright= false;
            }
            if (nowallleft(anemyradar))
            {
                noleft = true;
            }
            else
            {
                noleft = false;
            }
        }
       
          


        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movespeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {
            //FOR SENDING  TO OTHER CHARACTERS THAT HE STUCK AND HERE IS NO
            //WAY TO BE PUSHED 
            if (nowallup(anemyradar))
            {
                horistuckup = false;
            }
            else
            {
                horistuckup = true;
            }

            if (nowalldown(anemyradar))
            {
                horistuckdown = false;
            }
            else
            {
                horistuckdown = true;
            }

            // FOR PLAYING DIFFERENT ANIMATIONS DEPENDING ON THE STATE
            if (gameObject.tag == "Hori")
            {
                animator.Play("horistatic");
                animator.Play("horiblink");
            }

           if (gameObject.tag == "Big")
           {
                animator.Play("horistick");
           }
            //for sticking
           if (ToStick(anemyradar))
           {
                gameObject.tag = "Big";
                horiisbig = true;


           }
            else if  (ToStickleft(anemyradar) )
            {
                gameObject.tag = "Big";
                horiisbig = true;


            }

            else if (ToStickup(anemyradar) )
            {
                gameObject.tag = "Big";
                horiisbig = true;


            }

            else if (ToStickdown(anemyradar))
            {
                gameObject.tag = "Big";
                horiisbig = true;


            }
           else  
            {
                horiisbig = false   ;
                gameObject.tag = "Hori";

            }



        }

  
       

    }

  

    
    // up push checking
    bool CanSeeVertic(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider!=null)
        {
            if (hit.collider.gameObject.CompareTag("Vertic"))
            {
                val = true;
              

            }
            else
            {
                val = false;
            }

          
        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    //down push checking
    bool CanSeeVerticDown(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.up * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Vertic"))
            {
                val = true;

            }
          

            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }
    
    bool CanSeeVerticRight(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Vertic"))
            {
                val = true;

            }


            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.green);

        return val;
    }

    bool CanSeeVerticLeft(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left* distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Vertic"))
            {
                val = true;

            }


            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.green);

        return val;
    }

    bool CanSeeBigLeft(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("bigi"))
            {
                val = true;

            }


            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.green);

        return val;
    }

    bool CanSeeBigRight(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("bigi"))
            {
                val = true;

            }


            else
            {
                val = false;
            }


        }
        //Debug.DrawLine(check.position, endPos, Color.green);

        return val;
    }


    bool CanSeeboxright(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right* distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Box"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
      //  Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool CanSeeboxleft(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left* distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Box"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool CanSeeboxup(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.up * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Box"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool CanSeeboxdown(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Box"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }




    // to be sticked to the Bigboy
    bool ToStick(float distance)
      {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider!=null)
        {
            if (hit.collider.gameObject.CompareTag("Big"))
            {
                val = true;
              

            }
            else
            {
                val = false;
            }

          
        }
      //  Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
      }


    bool ToStickleft(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Big"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool ToStickup(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.up * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Big"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool ToStickdown(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Big"))
            {
                val = true;


            }
            else
            {
                val = false;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }
    // IN ORDER TO DETECT A WALL AND STOP MOVING IT WILL SENT THE BOOL TO THE FUNCTIONS ABOVE
    bool nowallright(float distance)
    {
        bool val = true;

        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if (hit.collider != null)
        {


            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                //Debug.Log("Waaaall");
                val = false;

            }
             
            else
            {

                val = true;
            }


        }
        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
          
    }

    bool nowallleft(float distance)
    {
        bool val = true;

        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if (hit.collider != null)
        {


            if (hit.collider.gameObject.CompareTag("Wall"))
            {
               // Debug.Log("Waaaall");
                val = false;

            }
            else
            {

                val = true;
            }


        }
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;

    }

    bool nowallup(float distance)
    {
        bool val = true;

        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.up * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if (hit.collider != null)
        {


            if (hit.collider.gameObject.CompareTag("Wall"))
            {

                val = false;

            }
            else
            {

                val = true;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;

    }

    bool nowalldown(float distance)
    {
        bool val = true;

        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down* distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("wall"));

        if (hit.collider != null)
        {


            if (hit.collider.gameObject.CompareTag("Wall"))
            {

                val = false;

            }
            else
            {

                val = true;
            }


        }
       // Debug.DrawLine(check.position, endPos, Color.blue);

        return val;

    }

    


    // FOR GETTING A SIGNALS FROM BUTTONS
    public void horimoveright()
    {
        bool Verticstuckright = GameObject.Find("vertic").GetComponent<verticmove>().verticstuckright;
        bool Bigstuckright = GameObject.Find("big").GetComponent<bigboymove>().bigstuckright;
        bool noRight = GameObject.Find("vertic").GetComponent<verticmove>().noright;
        bool nOright = GameObject.Find("big").GetComponent<bigboymove>().noright;
        bool norighT = GameObject.Find("box").GetComponent<boxmove>().boxnoright;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;

        if (CanSeeVerticRight(anemyradar) && Verticstuckright || CanSeeBigRight(anemyradar) && Bigstuckright || CanSeeboxright(anemyradar) && norighT ==false)
        {

        }             

        else if (nowallright(anemyradar) && gameObject.tag == "Hori" && Steps)
        {
                movePoint.parent = null;
                movePoint.position += new Vector3((float)2.543, 0, 0);
                animator.Play("horizonmove");
                animator2.Play("horimovestart");
            sh.PlayUp();
            if (isright  == false)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isright = true;
            }
            // transform.localScale = new Vector2(1, 1);
           
        }
        
        else if (gameObject.tag == "Big" && nowallright(anemyradar) && noRight )
        {
            if( norighT && nOright && Steps)
            {
                transform.Rotate(new Vector3(0, 0, 0));
                movePoint.parent = null;
                movePoint.position += new Vector3((float)2.543, 0, 0);
               
                animator.Play("horistickmoveright");
                animator2.Play("horieyesmove");
                sh.PlayUp();
                transform.rotation = Quaternion.Euler(0, 0, 0);
              
            }
        }
            else
            {
                movePoint.parent = hori;

            } 
    }
    public void horimoveleft()
    {
        bool Verticstuckleft = GameObject.Find("vertic").GetComponent<verticmove>().verticstuckleft;
        bool Bigstuckleft = GameObject.Find("big").GetComponent<bigboymove>().bigstuckleft;
        bool noLeft = GameObject.Find("vertic").GetComponent<verticmove>().noleft;
        bool nOleft = GameObject.Find("big").GetComponent<bigboymove>().noleft;
        bool nolefT = GameObject.Find("box").GetComponent<boxmove >().boxnoleft;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;

        if (CanSeeVerticLeft(anemyradar) && Verticstuckleft || CanSeeBigLeft(anemyradar) && Bigstuckleft ||CanSeeboxleft(anemyradar) && nolefT == false)
        {

        }

        else if (nowallleft(anemyradar) && gameObject.tag == "Hori" && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)-2.543, 0, 0);
            animator.Play("horizonmove");
            animator2.Play("horimovestart");
            sh.PlayDown();
            if (isright)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isright = false;
            }
           
        }
        else if (gameObject.tag == "Big" && nowallleft(anemyradar) && noLeft  )
        {
            if (nolefT && nOleft && Steps)
            {

                movePoint.parent = null;
                movePoint.position += new Vector3((float)-2.543, 0, 0);
                animator.Play("horistickmoveright");
                animator2.Play("horieyesleft");
                sh.PlayDown();
              
            }
        }
        
        else
        {
            movePoint.parent = hori;
           
        }
    }
    
    public void horipushedup()
    {
        bool Verticisbig = GameObject.Find("vertic").GetComponent<verticmove>().verticisbig;
        bool noUp = GameObject.Find("vertic").GetComponent<verticmove>().noup;
        bool nOup = GameObject.Find("big").GetComponent<bigboymove>().noup;
        bool nouP = GameObject.Find("box").GetComponent<boxmove>().boxnoup;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;
        if (CanSeeVertic(anemyradar) && gameObject.tag == "Hori" && nowallup (anemyradar) && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)2.543, 0);
            horiup = true;
            horidown = false;
            animator.Play("horizonpushed");
            animator2.Play("horieyespushed");
        }
        else if (Verticisbig && gameObject.tag == "Big" && nowallup(anemyradar) && noUp && nOup && nouP && Steps)
        {

            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)2.543, 0);
            animator.Play("horistickmoveup");
            animator2.Play("horieyespushed");
        }
        else
        {
            movePoint.parent = hori;
            horiup = false;
            horidown = false;
        }
    }

    public void horipusheddown()
    {
        bool Verticisbig = GameObject.Find("vertic").GetComponent<verticmove>().verticisbig;
        bool noDown = GameObject.Find("vertic").GetComponent<verticmove>().nodown;
        bool nOdown= GameObject.Find("big").GetComponent<bigboymove>().nodown;
        bool nodowN= GameObject.Find("box").GetComponent<boxmove>().boxnodown;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;
        if (CanSeeVerticDown(anemyradar) && gameObject.tag == "Hori" && nowalldown(anemyradar) && Steps)
        {
            animator2.Play("horieyespushed");
          
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)-2.543, 0);
            horiup = false;
            horidown = true;
            animator.Play("horizonpushed");
           
        }
        else if (Verticisbig && gameObject.tag == "Big" && nowalldown(anemyradar) && noDown && nOdown && nodowN && Steps)
        {

            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)-2.543, 0);
            animator.Play("horistickmoveup");
            animator2.Play("horieyespusheddown");
        }
        else
        {
            movePoint.parent = hori;
            horiup = false;
            horidown = false;
        }
    }

    public void horiturnbig()
    {
        if (gameObject.tag == "Big")
        {
            gameObject.tag = "Hori"; 
        }
    }

    public void Turnbig()
    {
        if (gameObject.tag == "Hori")
        {
            if (ToStick(anemyradar) || ToStickleft(anemyradar) || ToStickdown(anemyradar) || ToStickup(anemyradar))
            {
                gameObject.tag = "Big";
              
            }

        }
        else if (gameObject.tag == "Big")
        {

            gameObject.tag = "Hori";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("blue"))
        {
            Destroy(other.gameObject);
            SoundManager.instance.ChangeScore(diam);
        }
    }
}