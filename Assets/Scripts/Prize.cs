using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Prize : MonoBehaviour
{
	public float ballY = -1;
	public float borderX = 90;
	public float borderZ = 90;
	private Vector3 currentPos;
	
    // Start is called before the first frame update
    void Start()
    {
		currentPos = new Vector3(Random.Range(-borderX,borderX), ballY, Random.Range(-borderZ,borderZ));
    }

    // Update is called once per frame
    void Update()
    {
		if (this.GetComponent <Floater>().posOffset != currentPos)
		{
			this.GetComponent<Floater>().enabled=false;
			this.GetComponent <Floater>().posOffset = currentPos;
			this.GetComponent<Floater>().enabled=true;
		}
    }
	
	void OnTriggerEnter(Collider other)
	{
		currentPos = new Vector3(Random.Range(-borderX,borderX), ballY, Random.Range(-borderZ,borderZ));
		GameManager.instance.score++;
	}
}
