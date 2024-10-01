using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public GameObject finish;
    public GameObject start;
    private void OnTriggerEnter(Collider other)
    {
        start.SetActive(false);
        finish.SetActive(true);
    }
}
