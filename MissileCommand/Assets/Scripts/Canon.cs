using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    [SerializeField]
    GameObject pivotPoint = null;
    [SerializeField]
    GameObject bomb = null;

    Camera cam = null;

    [SerializeField]
    float fireForce = 1.0f;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = cam.transform.position.y - pivotPoint.transform.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - pivotPoint.transform.position.y, mouse.x - pivotPoint.transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;
        
        pivotPoint.transform.rotation = Quaternion.Euler(0, 0, angle);

        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBomb = Instantiate(bomb, pivotPoint.transform.position, Quaternion.identity);
            newBomb.GetComponent<Bomb>().SetDestination(new Vector3(mouse.x, mouse.y, 0.0f));
            Vector2 force = new Vector2(mouse.x - pivotPoint.transform.position.x, mouse.y - pivotPoint.transform.position.y);
            newBomb.GetComponent<Rigidbody2D>().AddForce(force.normalized * fireForce);
            //fire bomb
        }
	}
}
