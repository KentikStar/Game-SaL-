using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBullet : MonoBehaviour
{
    public float SpeedBullet { get; set; }
    public Vector3 TargetBullet { get; set; }


    // Update is called once per frame
    void FixedUpdate()
    {
        var step = SpeedBullet * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetBullet, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cosnulsa");
        other.gameObject.SetActive(false);
        transform.gameObject.SetActive(false);
    }
}
