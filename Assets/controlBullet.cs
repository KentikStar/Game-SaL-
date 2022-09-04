using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlBullet : MonoBehaviour
{
    public float SpeedBullet { get; set; }
    public Vector3 TargetBullet { get; set; }
    
    [SerializeField]
    List<string> triggerList = new List<string>();

    private void Start()
    {
        transform.LookAt(TargetBullet, Vector3.forward);
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
}
