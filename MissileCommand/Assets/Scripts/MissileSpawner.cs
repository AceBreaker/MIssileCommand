using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileSpawner : MonoBehaviour {

    const float minSpawnLocation = -6.5f;
    const float maxSpawnLocation = 6.5f;

    const float spawnLocationY = 5.75f;

    float time = 0.0f;

    [SerializeField]
    GameObject[] targets = null;

    int spawnRate = 121;
    int frameCounter = 0;

    [SerializeField]
    GameObject missile = null;

    [SerializeField]
    float force = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if(Random.Range(0, spawnRate) == 0)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(minSpawnLocation, maxSpawnLocation), spawnLocationY, 0.0f);
            int target = Random.Range(0, 6);
            float AngleRad = Mathf.Atan2(targets[target].transform.position.y - spawnLocation.y, targets[target].transform.position.x - spawnLocation.x);
            float angle = (180 / Mathf.PI) * AngleRad;

            Vector3 direction = new Vector3(targets[target].transform.position.x - spawnLocation.x, targets[target].transform.position.y - spawnLocation.y, 0.0f);

            GameObject retVal = Instantiate(missile, spawnLocation,Quaternion.identity);
            retVal.GetComponent<Rigidbody2D>().AddForce(direction.normalized * force);
            retVal.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }
	}

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        frameCounter++;
        if (spawnRate > 31 && frameCounter % 120 == 0)
            spawnRate -= 5;

        if (spawnRate < 40)
            SceneManager.LoadScene("WinScene");
    }
}
