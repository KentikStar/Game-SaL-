using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBullet : MonoBehaviour
{
    public float SpeedBullet { get; set; }
    
    [SerializeField]
    List<string> triggerList = new List<string>();

    [SerializeField]
    float lifeBullet = 3f;

    public void SetTarget(Vector3 target)
    {
        transform.LookAt(target, Vector3.forward);
        StartCoroutine(TimeToLife());
    }


    // Добавить пул объекта пуля! и вермя жизни
    void FixedUpdate() 
    { 
        this.transform.Translate(Vector3.forward * SpeedBullet * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerList.IndexOf(other.tag) != -1)        
            other.gameObject.SetActive(false);

        transform.gameObject.SetActive(false);
    }

    IEnumerator TimeToLife()
    {
        yield return new WaitForSeconds(lifeBullet);

        transform.gameObject.SetActive(false);
    }
}
