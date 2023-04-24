using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject playerInstance;
	[Header("Scoring")]
	public int score = 0;
	public int targetScore = 3;
	public int currentLevel;
	[Header("UI")]
	public TMP_Text speedUI;
	public int speed = 0;
	
	void Awake()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
		
    }
	

    // Update is called once per frame
    void Update()
    {
        if (score==targetScore)
		{
			if (currentLevel == 0)
			{
				if (SceneManager.GetActiveScene().buildIndex == 1)
				{
					currentLevel = 1;
				}
			}
			currentLevel++;
			if (currentLevel == 3)
			{
				SceneManager.LoadScene(sceneBuildIndex: currentLevel);
				currentLevel = 0;
			}
			SceneManager.LoadScene(sceneBuildIndex: currentLevel);
			//targetScore+= targetScore + targetScore/2;
			score=0;
			playerInstance.transform.position = new Vector3(0f,0f,0f);
			playerInstance.GetComponent<Rigidbody>().velocity=new Vector3 (0f,0f,0f);
		}
		
		if(playerInstance.TryGetComponent(out Rigidbody rb)) {
			speed = Mathf.CeilToInt(rb.velocity.magnitude*10f-0.5f);
			speedUI.text = "Speed: " + speed;
		}
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			foreach (Transform child in transform)
				{
					child.gameObject.SetActive(false);
				}
		} else {
			foreach (Transform child in transform)
				{
					child.gameObject.SetActive(true);
				}
		}
    }
	
}
