using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EndPoint : MonoBehaviour
{
	public float ballY = -1;
	public float borderX = 90;
	public float borderZ = 90;
	private Vector3 currentPos;
	
	void OnTriggerEnter(Collider other)
	{
		GameManager.instance.score = GameManager.instance.targetScore;
		Destroy(gameObject);
	}
}
