using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
