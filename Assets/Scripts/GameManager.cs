using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public bool isPressed;

    public LineRenderer reel;

    public Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        reel = GetComponent<LineRenderer>();
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        CatchFish();

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
             mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (isPressed)
        {
            endPoint.transform.position = Vector3.MoveTowards(endPoint.transform.position, mousePos, 10 * Time.deltaTime);
        }
        else
        {
            endPoint.transform.position = Vector3.MoveTowards(endPoint.transform.position, startPoint.transform.position, 10 * Time.deltaTime);
        }

        if(endPoint.transform.position == mousePos)
        {
            isPressed = false;
        }
    }
       
            //endPoint.transform.position = Vector3.MoveTowards(endPoint.transform.position, startPoint.transform.position, 10 * Time.deltaTime);
         
        

    void CatchFish()
    {
        
        reel.SetPosition(0, startPoint.transform.position);
        reel.SetPosition(1, endPoint.transform.position);
    }


}
