using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCam : MonoBehaviour
{
    public Transform playerCam;
    public Transform portalA;
    public Transform portalB;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCam.position - portalA.position;
        transform.position = portalB.position + playerOffsetFromPortal;

        float anglerDif = Quaternion.Angle(portalB.rotation, portalA.rotation);

        Quaternion portalRotationDif = Quaternion.AngleAxis(anglerDif, Vector3.up);
        Vector3 newCameraDir = portalRotationDif * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
    }
}
