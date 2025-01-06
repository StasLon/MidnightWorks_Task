using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private string carObjectName;
    public Transform targetCarTransform;

    [Range(1, 10)]
    public float cameraFollowSpeed = 2;
    [Range(1, 10)]
    public float cameraLookSpeed = 5;

    private Vector3 initialCameraPos;
    private Vector3 initialTargetCarPos;
    private Vector3 relativeCameraStartPos;

    private IEnumerator Start()
    {
        while (targetCarTransform == null)
        {
            targetCarTransform = GameObject.Find(carObjectName)?.transform;
            yield return null;
        }

        initialCameraPos = transform.position;
        initialTargetCarPos = targetCarTransform.position;
        relativeCameraStartPos = initialCameraPos - initialTargetCarPos;
    }

    private void FixedUpdate()
    {
        if (targetCarTransform == null)
            return;

        Vector3 directionToLook = targetCarTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraLookSpeed * Time.deltaTime);

        Vector3 desiredPosition = relativeCameraStartPos + targetCarTransform.position;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);
    }


}

