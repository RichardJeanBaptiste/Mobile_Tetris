using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{

    public Vector3 rotationPoint;
    public float fallTime = 0.8f;
    private float previousTime;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.down);
        if(hit.collider != null)
        {
            UnityEngine.Debug.Log(hit.transform.name);
            
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!ValidMove())
            {
                transform.position -= new Vector3(-1,0,0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if(!ValidMove())
            {
                transform.position -= new Vector3(1,0,0);
            }
        }else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                
                //CheckForLines();

                this.enabled = false;
                //UnityEngine.Debug.Log(transform.position);
                FindObjectOfType<Spawn>().NewTetromino();

            }
            previousTime = Time.time;
        }

    }

    
    void AddToGrid()
    {
       
        /* 
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            
        }
        */

    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if(roundedX < -7 || roundedX > 7 || roundedY < -15)
            {
                return false;
            }
            
          
        }
        return true;
    }

}
