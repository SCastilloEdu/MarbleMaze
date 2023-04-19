using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int score = 0;
	public int targetScore = 3;
	public int currentLevel;
	
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
			currentLevel++;
			SceneManager.LoadScene(sceneBuildIndex: currentLevel);
			targetScore+= targetScore + targetScore/2;
		}
    }
}
