using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject Tree;
    private CanvasGroup canvasGroup;
    private GameObject selectedObject;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z += Camera.main.nearClipPlane;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        selectedObject = Instantiate(Tree, objectPos, Quaternion.identity);

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RaycastHit hit = CastRay();
        if (hit.collider != null && hit.collider.gameObject.CompareTag("floor"))
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
            selectedObject.transform.position = new Vector3(hit.point.x, 0.7f, hit.point.z);
        }
        else
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 0.4f);
            selectedObject.transform.position = new Vector3(worldPosition.x, 0.7f, worldPosition.z);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    private RaycastHit CastRay()
    {
        Vector3 screenPosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenPosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenPosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenPosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
