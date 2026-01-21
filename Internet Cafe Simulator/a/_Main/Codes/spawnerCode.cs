using System.Collections;
using UnityEngine;

public class spawnerCode : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] float spawnTime;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            GameObject tempPlatform = Instantiate(platform, transform.position + Vector3.up * Random.Range(-2, 2), Quaternion.identity);
            Destroy(tempPlatform, 7);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
