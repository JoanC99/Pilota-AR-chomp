using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit; // Aseg�rate de tener este using

public class ShootingController : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del objeto a disparar
    public GameObject xrOrigin; // Referencia al XR Origin
    public Transform spawnPoint; // Referencia al punto de aparici�n

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Obtener la posici�n del punto de aparici�n
        Vector3 spawnPosition = spawnPoint.position; // Usar la posici�n del SpawnPoint
        GameObject chomp = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Agregar fuerza al proyectil
        Rigidbody rb = chomp.AddComponent<Rigidbody>();
        rb.AddForce(xrOrigin.transform.forward * 500); // Ajusta la fuerza seg�n sea necesario
    }
}
