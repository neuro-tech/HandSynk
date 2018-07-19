using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] scriptsToDisable;
    public OvrAvatarBody avatarBody;
    //public OculusLaserInput laserInput;
    public OvrAvatarHand hand1, hand2;

    Camera sceneCam;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            Invoke("DisableClientComp", 1.0f);
            gameObject.tag = "Client";
            //laserInput.enabled = false;
        }
        else
        {
            sceneCam = Camera.main;
            if(sceneCam)
                Camera.main.gameObject.SetActive(false);
            gameObject.tag = "LocalPlayer";


        }
    }

    //private void Update()
    //{
    //    if (isLocalPlayer)
    //        return;
    //    OvrAvatarComponent avatarComponent;
    //    avatarComponent = hand1.GetComponent<OvrAvatarComponent>();
    //    if (avatarComponent)
    //        avatarComponent.updateAvatar = false;
    //    avatarComponent = hand2.GetComponent<OvrAvatarComponent>();
    //    if (avatarComponent)
    //        avatarComponent.updateAvatar = false;

    //}

    //void SynchronizeAvatar()
    //{
    //    SynchronizeAvatarPart(avatarBody.transform);
    //}

    //void SynchronizeAvatarPart(Transform target)
    //{
    //    print("Synchronizing " + target.name);
    //    gameObject.SetActive(false);

    //    NetworkTransformChild newChild;

    //    newChild = gameObject.AddComponent<NetworkTransformChild>();
    //    newChild.target = target;

    //    foreach (Transform item in target)
    //    {
    //        SynchronizeAvatarPart(item);
    //    }

    //    RefreshCam();

    //}

    private void RefreshCam()
    {
        gameObject.SetActive(true);
        sceneCam.gameObject.SetActive(false);
    }

    void DisableClientComp()
    {
        Color avatarColor = new Color(Random.value, Random.value, Random.value, 1);
         
        foreach (var item in scriptsToDisable)
        {
            print("DisableClientComp: " + item.GetType());

            if (item.GetType().Equals(typeof(Camera)))
            {
                item.gameObject.SetActive(false);
                continue;
            }

            //if (item.GetType().Equals(typeof(OvrAvatarHand)))
            //{
            //    OvrAvatarComponent avComp = item.GetComponent<OvrAvatarComponent>();
            //    if (avComp)
            //        avComp.updateAvatar = false;

            //    if (item.transform.childCount == 0)
            //        continue;

            //    Transform child = item.transform.GetChild(0);
            //    child.gameObject.SetActive(true);
            //    child.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", avatarColor);
            //    continue;
            //}

            //if (item.GetType().Equals(typeof(OvrAvatarBody)))
            //{
            //    if (item.transform.childCount == 0)
            //        continue;
            //    print("New color defined");
            //    Transform child;
            //    child = item.transform.GetChild(0);
            //    child.gameObject.SetActive(true);
            //    child.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", avatarColor);

            //    child = item.transform.GetChild(1);
            //    child.gameObject.SetActive(true);
            //    child.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", avatarColor);

            //    child = item.transform.GetChild(2);
            //    child.gameObject.SetActive(true);
            //    child.gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", avatarColor);
            //    continue;
            //}
            item.enabled = false;
        }
    }

    void OnDisable()
    {
        if (sceneCam)
            sceneCam.gameObject.SetActive(true);
    }

  
}
