using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishTrigger : MonoBehaviour
{
    public GameObject start;
    private void OnTriggerEnter(Collider other)
    {
        start.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
