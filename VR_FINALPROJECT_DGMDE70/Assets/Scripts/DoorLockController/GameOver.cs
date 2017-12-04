using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	bool gameHasEnded = false;
	public float restartDelay = 1f;

	public void endGame()
	{
		if (gameHasEnded == false) 
		{
			gameHasEnded = true;
			Invoke ("restart", restartDelay);
		}
	}

	void restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
