using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public int rotateSpeed;

    void Update() {
        transform.Rotate(new Vector3(rotateSpeed, 0, 0) * Time.deltaTime);
    }
}
