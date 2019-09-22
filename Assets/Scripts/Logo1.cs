using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Logo1 : MonoBehaviour {

    float timer = 0f;
    void Start()
    {
      
    }
    void Update () {
       timer += Time.deltaTime;
        
		if (timer >= 3f)
        {
            SceneManager.LoadScene(1);
        }

		if (Input.anyKeyDown)
		{
            SceneManager.LoadScene(1);
        }

	}
}
