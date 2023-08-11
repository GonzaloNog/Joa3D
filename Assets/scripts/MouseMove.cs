using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseMove : MonoBehaviour
{
    public GameObject sphere;
    private float StartPoint = 18.46f;
    private bool move;
    private void Start()
    {
        move = false;
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && move && !GameManager.instance.pause)
        {
            // Obtener la posici�n del mouse en el mundo
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = StartPoint; // Asegurarse de que la Z est� en una posici�n adecuada en el mundo
                Vector3 targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);

                // Mover el objeto hacia la posici�n del mouse
                sphere.gameObject.transform.position = targetPosition;
                transform.position = targetPosition;
            }
        }
    }
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        move = true;
    }
    private void OnMouseExit()
    {
        move = false;
    }
}
