using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Prize : MonoBehaviour
{
	public float ballY = 1;
	public float borderX = 45;
	public float borderZ = 15;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision other)
	{
		transform.position = new Vector3(Random.Range(-borderX,borderX), ballY, Random.Range(-borderZ,borderZ));
		//GameManager.instance.score++;
	}
}
