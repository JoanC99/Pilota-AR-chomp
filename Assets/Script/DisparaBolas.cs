using UnityEngine;

public class DisparaBolas : MonoBehaviour
{
    public GameObject bola;
    public Transform camobj;
    public Transform PuntDisp;
    public float fuerzaDisparo = 100f;
    public LayerMask planoLayerMask; // Asegúrate de asignar el layer del plano en el inspector

    public void Disparar()
    {
        GameObject tObj = Instantiate(bola);
        tObj.transform.position = PuntDisp.transform.position;

        Vector3 tVec = CalcularDireccionDisparo();
        Rigidbody tR = tObj.GetComponent<Rigidbody>();

        tR.AddForce(tVec * fuerzaDisparo);
    }

    private Vector3 CalcularDireccionDisparo()
    {
        Ray ray = new Ray(camobj.position, camobj.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, planoLayerMask))
        {
            return (hit.point - PuntDisp.position).normalized;
        }
        else
        {
            // Si no se detecta el plano, dispara hacia adelante
            return camobj.forward;
        }
    }
}

