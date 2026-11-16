using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
public class OpenPhase1 : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
