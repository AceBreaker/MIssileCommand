using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour {

    [SerializeField]
    float scaleAmount = 1.0f;
    SpriteRenderer renderer = null;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1.0f);
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount) * Time.deltaTime;
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Mountain":
                SceneManager.LoadScene("BadEnding");
                break;
            case "Missile":
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
