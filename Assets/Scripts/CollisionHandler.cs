using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelTrans = 1f;
    [SerializeField] AudioClip deathclip;
    [SerializeField] AudioClip finishclip;
    [SerializeField] ParticleSystem deathpart;
    [SerializeField] ParticleSystem finishpart;
    AudioSource collisionaudio;
    bool isTrans = false;
    private void OnCollisionEnter(Collision other) 
    {
     collisionaudio = GetComponent<AudioSource>();
    if (isTrans) {return;}

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
        isTrans = true;
        collisionaudio.Stop();
        deathpart.Play();
        GetComponent<Move>().enabled = false;
        collisionaudio.PlayOneShot(deathclip);
        Invoke("ReloadLevel", 1f);
    }
    void EndLevel()
    {
        isTrans = true;
        collisionaudio.Stop();
        GetComponent<Move>().enabled = false;
        collisionaudio.PlayOneShot(finishclip);
        Invoke("NextLevel", LevelTrans);
    }
    void NextLevel()
    {
        isTrans = true;
        collisionaudio.Stop();
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
        isTrans = true;
        collisionaudio.Stop();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    //void Update()
    //{
    //    CheatNL();
    //}

    //void CheatNL()
    //{
        //if (Input.GetKey(KeyCode.L))
        //{
        //NextLevel();
        //}
    //}
}
