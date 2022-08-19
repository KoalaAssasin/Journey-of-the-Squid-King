using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_reel : MonoBehaviour
{
    public GameObject player;
    public GameObject plusOne;
    Vector3 offset = new Vector3(-0.5f, 1.5f, -3.0f);

    public IEnumerator PlayClip()
    {
        GameObject source = Instantiate(plusOne);
        source.transform.parent = player.transform;
        source.transform.position = player.transform.position;
        source.transform.position += offset;

        yield return new WaitForSeconds(0.005f);
        Destroy(source);
    }
}