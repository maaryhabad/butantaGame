using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    public GameObject[] projetil;


    public void SpawnProjetil(Vector3 playerPos) {
        Vector3 direction = (playerPos - transform.position).normalized;
        
        GameObject projetil_Obj = Instantiate(projetil[Random.Range(0, projetil.Length)]);
        Debug.Log("Spawnou");
        Vector3 temp = transform.position;
        temp.z = 1f;
        projetil_Obj.GetComponent<Projectile>().SetDirection(direction);
        projetil_Obj.transform.position = temp;
    }
}
