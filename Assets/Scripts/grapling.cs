using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class grapling : MonoBehaviour
{
    [SerializeField] private LineRenderer Rope;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform Graplinghook, handPosition, player, graplingHookEndPoint;
    [SerializeField] private LayerMask graplinglayer;
    [SerializeField] private float maxgraplingdistance,graplingHookSpeed = 0f,playerElasticDist=0.5f;
    [SerializeField] private Vector3 graplingPlayeOffset;
    [SerializeField] private Animator anim;
    bool isgrapling, isShooting;
    private Vector3 hookpoint;
    private void Start()
    {
        isgrapling = false;
        isShooting = false;
        Rope.enabled = false;
    }
    private void LateUpdate()
    {
        if (Rope.enabled)
        {
            Rope.SetPosition(0, handPosition.position);
            //Rope.SetPosition(1, graplingHookEndPoint.position);
            Rope.SetPosition(1, hookpoint);
            
        }
    }
    private void Update()
    {
        if (Graplinghook.parent == handPosition)
        {
            Graplinghook.localPosition = Vector3.Lerp(Graplinghook.localPosition,new Vector3 (0f, 0f, 1f), 1000f);
            
        }

        if (Input.GetKeyDown("e"))

        {
            shoothook();
        }
        if (isgrapling)
        {
            grapling_();
        }
        


    }

    private void shoothook()
    {
        if (isShooting || isgrapling) return;


        isShooting = true;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, maxgraplingdistance,graplinglayer))
        {
            hookpoint = hit.point;
            isgrapling = true;
            Graplinghook.parent = null;
            Graplinghook.LookAt(hookpoint);
            Rope.enabled = true;
            //anim.SetBool("IsSliding", true);
            bloooom(true);
        }


        isShooting = false;

    }
    private void grapling_()
    {
        Graplinghook.position = Vector3.Lerp(Graplinghook.position, hookpoint, graplingHookSpeed * Time.deltaTime);
        if (Vector3.Distance(Graplinghook.position, hookpoint) < 0.1f)
        {
            controller.enabled = false;
            player.position = Vector3.Lerp(player.position, hookpoint, graplingHookSpeed * Time.deltaTime);
            if (Vector3.Distance(player.position, hookpoint) < playerElasticDist)
            {
                controller.enabled = true;
                print("character controiller is enabled");
                Graplinghook.SetParent(handPosition);
                isgrapling = false;
                Rope.enabled = false;
                //anim.SetBool("IsSliding", false);
                bloooom(false);
            }


        }
    }

    void bloooom(bool state)
    {
        float vig = state ? .6f : 0;
        float chrom = state ? 1 : 0;
        float depth = state ? 4.8f : 8;
        float vig2 = state ? 0f : .6f;
        float chrom2 = state ? 0 : 1;
        float depth2 = state ? 8 : 4.8f;
        DOVirtual.Float(chrom2, chrom, .1f, Chromatic);
        DOVirtual.Float(vig2, vig, .1f, Vignette);
        DOVirtual.Float(depth2, depth, .1f, DepthOfField);
    }
    void Chromatic(float x)
    {
        Camera.main.GetComponentInChildren<PostProcessVolume>().profile.GetSetting<ChromaticAberration>().intensity.value = x;
    }

    void Vignette(float x)
    {
        Camera.main.GetComponentInChildren<PostProcessVolume>().profile.GetSetting<Vignette>().intensity.value = x;
    }

    void DepthOfField(float x)
    {
        Camera.main.GetComponentInChildren<PostProcessVolume>().profile.GetSetting<DepthOfField>().aperture.value = x;
    }
}
