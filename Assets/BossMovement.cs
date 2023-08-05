using UnityEngine;
using Cinemachine;

public class CharacterScreenPosition : MonoBehaviour
{
    public Transform characterTransform;
    public Vector3 screenOffset;
    public CinemachineVirtualCamera vcam;

    private Camera cam;

    private void Start()
    {
        if (vcam == null)
        {
            vcam = FindObjectOfType<CinemachineVirtualCamera>();
        }

        cam = vcam.GetComponent<CinemachineBrain>().OutputCamera;
    }

    private void LateUpdate()
    {
        Vector3 worldPosition = characterTransform.position + screenOffset;
        Vector3 screenPosition = cam.WorldToScreenPoint(worldPosition);
        transform.position = screenPosition;
    }
}
