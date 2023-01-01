using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigboymove : MonoBehaviour
{
    public Transform movePoint;

    [SerializeField]
    Transform check;


    [SerializeField]
    float movespeed = 20f;

    [SerializeField] float anemyradar;

    public GameObject vertic;

    public Transform bigboy;


    public GameObject hori;
    public GameObject Bigi;

    public bool bigstuckright = false;
    public bool bigstuckleft = false;
    public bool bigstuckup = false;
    public bool bigstuckdown = false;

    public bool noup = true;
    public bool nodown = true;
    public bool noright = true;
    public bool noleft = true;
    public SoundManager shb;

    public Animator animator;
    [SerializeField]
    Animator animator2;
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
                nodown = true;
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
                noright = false;
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
        { //is sending  bools to hori to be stop if he hits wall
            if (nowallright(anemyradar))
            {
                bigstuckright = false;
            }
            else
            {
                bigstuckright = true;
            }

            if (nowallleft(anemyradar))
            {
                bigstuckleft = false;
            }
            else
            {
                bigstuckleft = true;
            }

            if (nowallup(anemyradar))
            {
                bigstuckup = false;
            }
            else
            {
                bigstuckup = true;
            }

            if (nowalldown(anemyradar))
            {
                bigstuckdown = false;
            }
            else
            {
                bigstuckdown= true;
            }



            // to be pushed up
            if (gameObject.tag == "bigi")
            {
                animator.Play("bigstatic");
            }

            if (gameObject.tag == "Big")
            {
                animator.Play("bigstick");
            }
        }
    }

    bool CanSeeboxright(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right * distance;
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
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool CanSeeboxleft(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left * distance;
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
        Debug.DrawLine(check.position, endPos, Color.blue);

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
        Debug.DrawLine(check.position, endPos, Color.blue);

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
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }


    bool CanSeeVerticdown(float distance)
    {
        bool val = false;
        float castDist = distance;

        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down * distance;
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

        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }

    bool CanSeeVerticup(float distance)
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
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    //hori
    bool CanSeeHoriright(float distance)
    {
        bool val = false;
        float castDist = distance;

        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Hori"))
            {
                val = true;

            }
            else
            {
                val = false;
            }


        }
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;
    }

    bool CanSeeHorileft(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Hori"))
            {
                val = true;

            }
            else
            {
                val = false;
            }


        }
        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }

    //to be pushed by vertic through hori
    bool verticdoubledown(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.up * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Hori"))
            {
                val = true;

            }
            else
            {
                val = false;
            }


        }
        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }


    bool verticdoubleup(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down * distance;
        RaycastHit2D hit = Physics2D.Linecast(check.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Hori"))
            {
                val = true;

            }
            else
            {
                val = false;
            }


        }
        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }

    // to be pushed by hori through vertic
    bool horidoubleright(float distance)
    {
        bool val = false;
        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.left * distance;
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
        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }

    bool horidoubleleft(float distance)
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
        Debug.DrawLine(check.position, endPos, Color.red);

        return val;
    }

    //FOR DETECTING WALLS
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
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;

    }

    bool nowalldown(float distance)
    {
        bool val = true;

        float castDist = distance;
        Physics2D.queriesStartInColliders = false;
        Vector2 endPos = check.position + Vector3.down * distance;
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
        Debug.DrawLine(check.position, endPos, Color.blue);

        return val;

    }
    //FOR GETTING SIGNALS FROM THE BUTTONS TO MOVE
    public void bigmoveup()
    {
        bool Horiup = GameObject.Find("hori").GetComponent<horizonmove>().horiup;
        bool Verticisbig = GameObject.Find("vertic").GetComponent<verticmove>().verticisbig;
        bool Noup = GameObject.Find("hori").GetComponent<horizonmove>().noup;
        bool noUp = GameObject.Find("vertic").GetComponent<verticmove>().noup;
        bool nouP = GameObject.Find("box").GetComponent<boxmove>().boxnoup;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;
        if (CanSeeVerticdown(anemyradar) && gameObject.tag == "bigi" && nowallup(anemyradar) && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)2.543, 0);

        }
       else if (verticdoubleup(anemyradar) && Horiup && Steps)
       {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)2.543, 0);
       }
      else if (Verticisbig && gameObject.tag == "Big" && nowallup(anemyradar) && Noup && noUp && nouP && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)2.543, 0);
            animator.Play("bigstickmove");
            animator2.Play("bigeyesup");


        }
        else
      {
       movePoint.parent = bigboy;
      }
    }
     
    public void bigmovedown()
    {
        bool Horidown = GameObject.Find("hori").GetComponent<horizonmove>().horidown;
        bool Verticisbig = GameObject.Find("vertic").GetComponent<verticmove>().verticisbig;
        bool Nodown = GameObject.Find("hori").GetComponent<horizonmove>().nodown;
        bool noDown = GameObject.Find("vertic").GetComponent<verticmove>().nodown;
        bool nodowN = GameObject.Find("box").GetComponent<boxmove>().boxnodown;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;
        if (CanSeeVerticup(anemyradar) && gameObject.tag == "bigi" && nowalldown(anemyradar) && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)-2.543, 0);

        }
       else if (verticdoubledown(anemyradar) && Horidown && Steps)
       {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)-2.543, 0);
       }
        else if (Verticisbig && gameObject.tag == "Big" && nowalldown(anemyradar)&& Nodown &&noDown && nodowN && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3(0, (float)-2.543, 0);
            animator.Play("bigstickmove");
            animator2.Play("bigeyesdown");

        }
        else
        {
            movePoint.parent = bigboy;
        }
    }

    public void bigmoveright()
    {
        bool Verticright = GameObject.Find("vertic").GetComponent<verticmove>().verticright;
        bool Horiisbig = GameObject.Find("hori").GetComponent<horizonmove>().horiisbig;
        bool Noright = GameObject.Find("hori").GetComponent<horizonmove>().noright;
        bool noRight = GameObject.Find("vertic").GetComponent<verticmove>().noright;
        bool norighT= GameObject.Find("box").GetComponent<boxmove>().boxnoright;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;
        if (CanSeeHorileft(anemyradar) && gameObject.tag == "bigi" && nowallright(anemyradar) && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)2.543, 0, 0);
            animator2.Play("bigeyesright");

        }
       
       else if (horidoubleright(anemyradar) && Verticright && Steps)
       {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)2.543, 0, 0);
       }
        else if (Horiisbig && gameObject.tag == "Big" && nowallright(anemyradar)&& Noright && noRight && norighT && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)2.543, 0, 0);
            animator.Play("bigstickmoveright");
            animator2.Play("bigeyesright");

        }
        else
        {
            movePoint.parent = bigboy;
        }
    }

    public void bigmoveleft()
    {
        bool Verticleft = GameObject.Find("vertic").GetComponent<verticmove>().verticleft;
        bool Horiisbig = GameObject.Find("hori").GetComponent<horizonmove>().horiisbig;
        bool Noleft = GameObject.Find("hori").GetComponent<horizonmove>().noleft;
        bool noLeft = GameObject.Find("vertic").GetComponent<verticmove>().noleft;
        bool nolefT = GameObject.Find("box").GetComponent<boxmove>().boxnoleft;
        bool Steps = GameObject.Find("vertic").GetComponent<SoundManager>().steps;
        if (CanSeeHoriright(anemyradar) && gameObject.tag == "bigi" && nowallleft(anemyradar) && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)-2.543, 0, 0);
            animator2.Play("bigeyesleft");

        }
        else if (horidoubleleft(anemyradar) && Verticleft && Steps)
       {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)-2.543, 0, 0);
       }
        else if (Horiisbig && gameObject.tag == "Big" && nowallleft(anemyradar) && Noleft &&  nolefT && Steps)
        {
            movePoint.parent = null;
            movePoint.position += new Vector3((float)-2.543, 0, 0);
            animator.Play("bigstickmoveright");
            animator2.Play("bigeyesleft");

        }
        else
        {
            movePoint.parent = bigboy;
        }
    }
     public void Turnbig()
    {
        if (gameObject.tag == "bigi")
        {
            shb.PlayStick();
            gameObject.tag = "Big";
        }
        else if (gameObject.tag == "Big")
        {
            shb.PlayUnstick();
            gameObject.tag = "bigi";
        }
    }

   

}
