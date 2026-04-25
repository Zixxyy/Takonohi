using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    // transition method
    public void ChangeScene(int index)
    {
        Debug.Log("button pressed. loading scene: " + index);
        SceneManager.LoadScene(index);
    }
}