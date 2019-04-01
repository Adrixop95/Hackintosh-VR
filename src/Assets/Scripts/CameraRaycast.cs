using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {

    public  float       raycastMaxDelay = 60f;
    public  float       raycastDistance = 10f;

    public  LayerMask[] ignoreLayer;

    private GameObject  lastObject;
    private float       raycastTimer;

    // ####################################################################################################
    void Start() {
        
    }

    // ----------------------------------------------------------------------------------------------------
    void Update() {
        RaycastHit();
    }

    // ####################################################################################################
    private void RaycastHit() {
        RaycastHit  hit;
        Ray         ray     =   new Ray( transform.position, transform.forward );

        if ( Physics.Raycast( ray, out hit, raycastDistance ) ) {
            GameObject  hitObject   =   hit.collider.gameObject;
            raycastTimer            +=  Time.deltaTime;

            if ( hitObject != lastObject ) {
                raycastTimer    =   0f;
                lastObject      =   hitObject;
            }

            if ( raycastTimer > raycastMaxDelay ) {
                raycastTimer = raycastMaxDelay;
            }

        } else {
            raycastTimer    =   0f;
            lastObject      =   null;
        }
    }

    // ####################################################################################################
    public GameObject SelectedObject {
        get { return lastObject; }
    }

    // ----------------------------------------------------------------------------------------------------
    public float SelectedTime {
        get { return raycastTimer; }
    }

    // ####################################################################################################
}
