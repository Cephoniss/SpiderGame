using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelTrans = 1f;
    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("Friendly object");
            break;
            
            case "Finish":
            EndLevel();
            break;
            
            case "Danger":
            StartDeath();
            break;
            
            default:
            Debug.Log("Hit something");
            break;
        }
    }
    
    void StartDeath()
    {
        GetComponent<Move>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }
    void EndLevel()
    {
        GetComponent<Move>().enabled = false;
        Invoke("NextLevel", LevelTrans);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
