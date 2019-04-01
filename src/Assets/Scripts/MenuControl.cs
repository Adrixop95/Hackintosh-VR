using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MenuControl : MonoBehaviour {

    public  CameraRaycast   raycast;
    public  float           raycastTime     =   2.5f;

    public  GameObject      mainMenu;
    public  GameObject      videoMenu;

    public  VideoPlayer     videoPlane;
    public  VideoClip[]     videos;

    // ####################################################################################################
    void Start() {
        
    }

    // ----------------------------------------------------------------------------------------------------
    void Update() {
        OnDetectUI( raycast );
    }

    // ####################################################################################################
    private void OnDetectUI( CameraRaycast raycast ) {
        if ( raycast.SelectedTime >= raycastTime ) {
            GameObject  raycastObject   =   raycast.SelectedObject;

            if ( raycastObject == null ) { return; }
            if ( raycastObject.name == "Button Play" ) {
                int video   =   Random.Range( 0, videos.Length );
                ShowMenu( false );
                ShowVideo( true );
                PlayVideo( video );

            } else if ( raycastObject.name == "Button Blose" ) {
                Application.Quit();

            } else if ( raycastObject.name == "Button Back" ) {
                if ( videoPlane.isPlaying ) { videoPlane.Stop(); }
                ShowVideo( false );
                ShowMenu( true );

            }
        }
    }

    // ####################################################################################################
    private void ShowMenu( bool show ) {
        mainMenu.SetActive( show );
    }

    // ----------------------------------------------------------------------------------------------------
    private void ShowVideo( bool show ) {
        videoMenu.SetActive( show );
    }

    // ----------------------------------------------------------------------------------------------------
    private void PlayVideo( int video ) {
        videoPlane.clip     =   videos[ video ];
        videoPlane.Play();
    }

    // ####################################################################################################
}
