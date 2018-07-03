using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerMovement : MonoBehaviour {

    bool isMoving = false;
    public GameObject objectA;
    public GameObject objectB;
    public const int up = 0;
    public const int down = 1;
    public const int left = 2;
    public const int right = 3;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        float xLoc = transform.position.x;
        float zLoc = transform.position.z;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 30.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 30.0f;

        float oBX = objectB.transform.position.x;
        float oBZ = objectB.transform.position.z;

        if ( Input.GetKey("w") && zLoc < 70 )
        {
            objectB.transform.position = transform.position;
            objectB.transform.Translate( new Vector3(0, 0, 10 ));
            StartCoroutine(MoveToX(objectA.transform, objectB.transform.position, 0.50f, up));
        }
        if (Input.GetKey("s") && zLoc > -70)
        {
            objectB.transform.position = transform.position;
            objectB.transform.Translate(new Vector3(0, 0, -10));
            StartCoroutine(MoveToX(objectA.transform, objectB.transform.position, 0.50f, down));
        }
        if (Input.GetKey("a") && xLoc > -70)
        {
            objectB.transform.position = transform.position;
            objectB.transform.Translate(new Vector3(-10, 0, 0));
            StartCoroutine(MoveToX(objectA.transform, objectB.transform.position, 0.50f, left));
        }
        if (Input.GetKey("d") && xLoc < 70)
        {
            objectB.transform.position = transform.position;
            objectB.transform.Translate(new Vector3(10, 0, 0));
            StartCoroutine(MoveToX(objectA.transform, objectB.transform.position, 0.5f, right));
        }




    }
    IEnumerator MoveToX(Transform fromPosition, Vector3 toPosition, float duration, int direction)
    {
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;

        float counter = 0;
        float turn = 0.0f;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            if ( direction == up )
            {
                fromPosition.Rotate(turn + 3, 0, 0);
            }
            if (direction == down)
            {
                fromPosition.Rotate(turn - 3, 0, 0);
            }
            if (direction == left)
            {
                fromPosition.Rotate(0, 0, turn + 3);
            }
            if (direction == right)
            {
                fromPosition.Rotate(0, 0, turn - 3);
            }
            yield return null;
        }
        fromPosition.eulerAngles = new Vector3(0, 0, 0);


        isMoving = false;
    }


}
