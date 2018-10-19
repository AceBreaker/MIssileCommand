using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    [SerializeField]
    GameObject graphics = null;
    [SerializeField]
    float rot = 0.0f;

    [SerializeField]
    Vector3 destination = Vector3.zero;

    Collider2D myCollider = null;

    [SerializeField]
    GameObject explosion = null;

	// Use this for initialization
	void Start () {
        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        graphics.transform.Rotate(new Vector3(0.0f, 0.0f, rot));

        Debug.Log(transform.position.ToString());
        if(myCollider.bounds.Contains(destination))
        {
            Detonate();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Missile":
                Detonate();
                break;
            default:
                break;
        }
    }

    void Detonate()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetDestination(Vector3 dest)
    {
        destination = dest;
    }
}
