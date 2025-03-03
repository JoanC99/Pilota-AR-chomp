using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil

    private void Start()
    {
        // Obtener el Rigidbody del proyectil
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Aplicar fuerza en la direcci�n hacia adelante
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("El prefab del proyectil debe tener un componente Rigidbody.");
        }

        // Destruir el proyectil despu�s de 5 segundos para evitar acumulaci�n
        Destroy(gameObject, 5f);
    }
}