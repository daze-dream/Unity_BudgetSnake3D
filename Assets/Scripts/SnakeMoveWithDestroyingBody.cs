using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMoveWithDestroyingBody : MonoBehaviour
{

    /// <summary> snake body List. First object should ALWAYS be the head prefab.</summary>
    public List<Transform> bodyParts = new List<Transform>();
    /// <summary> minimum follow distance of the segments.</summary>
    public float followDist;
    /// <summary> base speed of the snake.</summary>
    public float speed;
    /// <summary> speed of rotation. </summary>
    public float rotationspeed;
    /// <summary> starting size of the snake to instantiate with.</summary>
    public int startSize;//, prevBodyCount;
    public GameObject segmentPrefab;

    private float dis;
    private Transform curSeg, nextSeg;

    //game mechanics
    bool hasSpeedPowerup = false;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startSize - 1; i++)
        {
            AddSnakeSegment();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bodyMovement();
        //debug only
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddSnakeSegment();
        }

    }

    //body parts should move in relation to what is in front and behind
    public void bodyMovement()
    {

        // accelerate and brake basically. Tried to move to Update but the code is intrinsically tied to the bodymovement
        float currentSpeed = speed;
        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetKey(KeyCode.Z))
        {
            currentSpeed *= 2;
        }

        if (Input.GetAxisRaw("Vertical") < 0 || Input.GetKey(KeyCode.X))
        {
            currentSpeed /= 2;
        }
        //rotate based on RAWINPUT. no smoothing or ramping up because that was terrible.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput != 0)
        {
            bodyParts[0].Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontalInput);

        }

        // keep moving the head in the direction of its rotation
        bodyParts[0].Translate(bodyParts[0].forward * currentSpeed * Time.deltaTime, Space.World);
        //now do this for all body parts in the List. List is a strongly ordered list, so it'll be in the same order we put them in.
        //  in other words, it's from the first segment added, not the last like I was thinking with stack or vect
        //  so the previous body part is the one "ahead" of it essentially.
        for (int i = 1; i < bodyParts.Count; i++)
        {
            if (bodyParts[i].gameObject.CompareTag("body") 
                && bodyParts[i].gameObject.GetComponent<SnakeBody>().isHit == true)
            {

                Debug.Log("Piece hit at" + i + "|| body count: " + bodyParts.Count);
                //KEEP FOR EMERGENCY PURPOSES
                //prevBodyCount = bodyParts.Count;
                //for (int j = i; j < prevBodyCount; j++)
                //{
                //    Debug.Log("removing piece at: " + i);
                //    bodyParts[i].GetComponent<SnakeBody>().playFX();
                //    Destroy(bodyParts[i].gameObject);
                //    bodyParts.RemoveAt(i);
                //}
                DestroySegmentsAfterParam(i);
                Debug.Log("New body count: " + bodyParts.Count);
            }
            else
            {
                curSeg = bodyParts[i];
                nextSeg = bodyParts[i - 1];
                // find the distance between the current segment and the previous segment
                dis = Vector3.Distance(nextSeg.position, curSeg.position);
                // nextSeg is the one ahead of the current segment
                Vector3 newPos = nextSeg.position;
                //align its Y coordinate with the head's Y
                newPos.y = bodyParts[0].position.y;
                //complex but finds the time as a function of distance between the segments
                float T = Time.deltaTime * dis / followDist * currentSpeed;
                if (T > .5f)
                    T = .5f;
                //smoothly spherically move and then rotate accordingly
                curSeg.position = Vector3.Slerp(curSeg.position, newPos, T);
                curSeg.rotation = Quaternion.Slerp(curSeg.rotation, nextSeg.rotation, T);
            }
        }
    }
    /// <summary>
    /// this adds a segment to the snake.
    /// </summary>
    public void AddSnakeSegment()
    {
        //gets the transform position of the new part based on last segment. Cast to GameObject.
        Transform newPart = (Instantiate(segmentPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;
        // set the body part to be a child of the main head
        newPart.SetParent(transform);
        //now add it to the list
        bodyParts.Add(newPart);
    }

    /// <summary>
    /// <para>this is supposed to destroy the whole object </para>
    /// 
    /// it mimics this by iterating and playing the FX of all the objects, then deletes itself.
    /// </summary>
    public void DestroyAllSegments()
    {
        var prevCount = bodyParts.Count;
        for (int i = 1; i< prevCount; i++)
        {
            Debug.Log("removing piece at: " + i);
            bodyParts[i].GetComponent<SnakeBody>().playFX();
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// <para>this is supposed to delete segments after the index that was hit.</para>
    /// since we both destroy and remove, the list dynamically shrinks, meaning indexes stay the same.
    /// <br />
    /// so, we delete that index place as many times as there are remaining pieces after the hit index.
    /// </summary>
    /// <param name="index"></param>
    public void DestroySegmentsAfterParam(int index)
    {
        // get how many pieces are after the index hit, then iterate.
        var prevCount = bodyParts.Count - index;
        for (int i = 0; i < prevCount; i ++)
        {
            Debug.Log("removing piece at: " + i);
            bodyParts[index].GetComponent<SnakeBody>().playFX();
            Destroy(bodyParts[index].gameObject);
            bodyParts.RemoveAt(index);
        }
    }


}
