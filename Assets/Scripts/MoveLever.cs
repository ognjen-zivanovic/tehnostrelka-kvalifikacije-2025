using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLever : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 rotation1;
    public Vector3 position2;
    public Vector3 rotation2;

    int i = 0;

    public void ChangePlace() {
        if (i == 0) {
            transform.localPosition = position1;
            transform.localRotation = Quaternion.Euler(rotation1);
        }
        else {
            transform.localPosition = position2;
            transform.localRotation = Quaternion.Euler(rotation2);
        }

        i = 1 - i;
    }
}
