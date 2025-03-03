using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit; // Asegúrate de tener este using

public class ShootingController : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del objeto a disparar
    public GameObject xrOrigin; // Referencia al XR Origin
    public Transform spawnPoint; // Referencia al punto de aparición

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Obtener la posición del punto de aparición
        Vector3 spawnPosition = spawnPoint.position; // Usar la posición del SpawnPoint
        GameObject chomp = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Agregar fuerza al proyectil
        Rigidbody rb = chomp.AddComponent<Rigidbody>();
        rb.AddForce(xrOrigin.transform.forward * 500); // Ajusta la fuerza según sea necesario
    }
}
