using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary> <para>DEPRECATED: Basic code skeleton adapted from Gamad: https://www.youtube.com/watch?v=xz8Ga9er3_8 </para>
/// DEPRECATED: original snake movement but without parts being destroyed.
/// </summary>
public class SnakeMove : MonoBehaviour
{

    // the body of the snake
    public List<Transform> bodyParts = new List<Transform>();
    public float followDist = .25f,
        speed = 1.0f,
        rotationspeed = 70.0f;

    public int startSize, prevBodyCount;
    public GameObject segmentPrefab;

    private float dis;
    private Transform curSeg, prevSeg;

    //game mechanics
    bool hasSpeedPowerup = false;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startSize - 1; i++)
        {
            AddSnakeSegment();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //debug

        bodyMovement();
        if(Input.GetKey(KeyCode.X))
        {
            AddSnakeSegment();
        }
        
    }

    //body parts should move in relation to what is in front and behind
    public void bodyMovement()
    {
        float currentSpeed = speed;
        if (Input.GetAxis("Vertical") > 0)
        {
            currentSpeed *= 2;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            currentSpeed /= 2;
        }

        //rotate the head based on input axis 
        float horizontalInput = Input.GetAxis("Horizontal");
        bodyParts[0].Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontalInput);

        // keep moving the head in the direction of its rotation
        bodyParts[0].Translate(bodyParts[0].forward * currentSpeed * Time.deltaTime, Space.World);
        //bodyParts[0].GetComponent<Rigidbody>().velocity = bodyParts[0].forward;


        
        //now do this for all body parts in the List. List is a strongly ordered list, so it'll be in the same order we put them in.
        //  in other words, it's from the first segment added, not the last like I was thinking with stack or vect
        //  so the previous body part is the one "ahead" of it essentially.
        for(int i = 1; i < bodyParts.Count; i++)
        {

            curSeg = bodyParts[i];

            prevSeg = bodyParts[i - 1];

            //get the distance between the two segments as as Vector3
            dis = Vector3.Distance(prevSeg.position, curSeg.position);
            Vector3 newPos = prevSeg.position;
            newPos.y = bodyParts[0].position.y;
            float T = Time.deltaTime * dis / followDist * currentSpeed;
            if (T > .5f)
                T = .5f;

            curSeg.position = Vector3.Slerp(curSeg.position, newPos, T);
            curSeg.rotation = Quaternion.Slerp(curSeg.rotation, prevSeg.rotation, T);



        }

    }

    public void AddSnakeSegment()
    {
        //gets the transform position of the new part based on last segment. Cast to GameObject.
        Transform newPart = (Instantiate(segmentPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;
        // set the body part to be a child of the main head
        newPart.SetParent(transform);
        //now add it to the list
        bodyParts.Add(newPart);
    }
}
