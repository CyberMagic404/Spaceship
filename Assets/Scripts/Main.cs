using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main solo;
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    private BoundsChecker boundsChecker;

    private void Awake()
    {
        solo = this;
        boundsChecker = GetComponent<BoundsChecker>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        int index = Random.Range(0, prefabEnemies.Length);
        GameObject gameObject = Instantiate(prefabEnemies[index]);

        float enemyPadding = enemyDefaultPadding;
        if(gameObject.GetComponent<BoundsChecker>() != null)
        {
            enemyPadding = Mathf.Abs(gameObject.GetComponent<BoundsChecker>().radius);
        }

        Vector3 position = Vector3.zero;
        float xMin = -boundsChecker.cameraWidth + enemyPadding;
        float xMax = boundsChecker.cameraWidth - enemyPadding;
        position.x = Random.Range(xMin, xMax);
        position.y = boundsChecker.cameraHeight + enemyPadding;
        gameObject.transform.position = position;
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
