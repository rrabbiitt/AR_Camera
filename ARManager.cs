using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ARManager : MonoBehaviour
{
    ARFaceManager arFaceManager;
    ARSessionOrigin arSessionOrigin;

    public List<Material> faceMaterials = new List<Material>();
    private int faceMaterialIndex;

    public GameObject rightPrefab;
    private GameObject rightobj;
    public GameObject leftPrefab;
    private GameObject leftobj;

    private NativeArray<ARCoreFaceRegionData> regions;

    void Start()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        arSessionOrigin = GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        ARCoreFaceSubsystem arCoreSystem = (ARCoreFaceSubsystem)arFaceManager.subsystem;

        foreach (var face in arFaceManager.trackables)
        {
            arCoreSystem.GetRegionPoses(face.trackableId, Unity.Collections.Allocator.Persistent, ref regions);

            foreach (ARCoreFaceRegionData faceregion in regions)
            {
                ARCoreFaceRegion regiontype = faceregion.region;

                if(regiontype == ARCoreFaceRegion.ForeheadRight)
                {
                    if (!rightobj)
                    {
                        rightobj = Instantiate(rightPrefab, arSessionOrigin.trackablesParent);
                        //rightobj.SetActive(false);
                    }
                    rightobj.transform.localPosition = faceregion.pose.position + new Vector3(-0.05f,0.05f,0.1f);
                    rightobj.transform.localRotation = faceregion.pose.rotation;
                }
                else if (regiontype == ARCoreFaceRegion.ForeheadLeft)
                {
                    if (!leftobj)
                    {
                        leftobj = Instantiate(leftPrefab, arSessionOrigin.trackablesParent);
                        //leftobj.SetActive(false);
                    }
                    leftobj.transform.localPosition = faceregion.pose.position + new Vector3(0.05f, 0.05f, 0.1f);
                    leftobj.transform.localRotation = faceregion.pose.rotation;
                }
            }
        }
    }

    public void SwitchFace()
    {
        foreach (var face in arFaceManager.trackables)
        {
            face.GetComponent<Renderer>().material = faceMaterials[faceMaterialIndex];

        }
        faceMaterialIndex++;

        /*if (faceMaterialIndex == 3)
        {
            rightobj.SetActive(true);
            leftobj.SetActive(true);
        }
        else
        {
            rightobj.SetActive(false);
            leftobj.SetActive(false);
        }*/

        if (faceMaterialIndex == faceMaterials.Count)
        {
            faceMaterialIndex = 0;
        }
    }

    public void MaskOn()
    {
        
    }
}
