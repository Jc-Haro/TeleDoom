using UnityEngine;
using UnityEngine.SceneManagement;

public class DropSystem : MonoBehaviour
{
    [SerializeField] GameObject[] objectPool;
    private bool isQuitting = false;


    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {

        if (!isQuitting && gameObject.scene.isLoaded)
        {
            int randomIndex = Random.Range(0, objectPool.Length);
            Instantiate(objectPool[randomIndex], transform.position,transform.rotation);
        }
    }
}
