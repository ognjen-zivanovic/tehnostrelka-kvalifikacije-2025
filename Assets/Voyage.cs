using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voyage : MonoBehaviour
{
    public void Go() {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
         StartCoroutine(VoyageOverTime());
    } 

     private IEnumerator VoyageOverTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 5.0f)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x,  transform.localPosition.y,  transform.localPosition.z) + transform.forward * Time.deltaTime * 3.0f;
            yield return null;
        }
        Destroy(gameObject);
    }
}
