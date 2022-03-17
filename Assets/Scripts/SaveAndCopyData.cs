using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SaveAndCopyData : MonoBehaviour
{


    [Header("SaveDataFormat")]
    [SerializeField] private CustomData _CustomData = new CustomData();
    [Header("SaveDataFuntion")]

    public bool ClickToSave_From;
    public bool ClickToSave_To;
    [Header("CopyDataFunction")]
    public bool ClickToCopyBones;

    public Transform BoneRoot;

    public void SaveIntoJson()
    {
        string potion = JsonUtility.ToJson(_CustomData);
        var path = Application.dataPath + "/" + _CustomData.index + ".json";
        System.IO.File.WriteAllText(path, potion);
        Debug.Log("save to: " + path);
    }

    public void GetBoneData(bool type)
    {
        GameObject activeGameObject;
        if (type)
        {
            activeGameObject = _CustomData.FromGameObject;

        }
        else
        {
            activeGameObject = _CustomData.ToGameObject;
        }
        Transform[] BoneData = activeGameObject.GetComponent<SkinnedMeshRenderer>().bones;
        Matrix4x4[] BindPoseData = activeGameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.bindposes;
        BoneWeight[] BoneWeightsData = activeGameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.boneWeights;

        _CustomData.boneData.bones = BoneData;
        _CustomData.boneData.boneNames = new string[BoneData.Length];
        for (int i = 0; i < BoneData.Length; i++)
        {
            _CustomData.boneData.boneNames[i] = BoneData[i].name;
        }
        _CustomData.boneData.bindposes = BindPoseData;
        _CustomData.boneData.boneWeights = BoneWeightsData;
    }

    public void CopyData()
    {
        var activeGameObject = _CustomData.ToGameObject;
        // activeGameObject.AddComponent<Animation>();
        if (activeGameObject.GetComponent<SkinnedMeshRenderer>())
        {

        }
        else
        {
            activeGameObject.AddComponent<SkinnedMeshRenderer>(); // auto replace the MeshRenderer
        }
        SkinnedMeshRenderer rend = activeGameObject.GetComponent<SkinnedMeshRenderer>();
        // Animation anim = activeGameObject.GetComponent<Animation>();

        // build the mesh
        Mesh mesh = new Mesh();
        mesh = rend.sharedMesh;
        // assign bone weights to mesh
        BoneWeight[] copyBoneWeights = _CustomData.boneData.boneWeights;
        mesh.boneWeights = copyBoneWeights;
        // assgn Bone and BindPose
        Transform[] copyBones = _CustomData.boneData.bones;
        Matrix4x4[] copyBindpose = _CustomData.boneData.bindposes;

        // Assign bones and bind poses
        mesh.bindposes = copyBindpose;
        rend.bones = copyBones;
    }

    void Update()
    {
        if (ClickToSave_From)
        {
            GetBoneData(ClickToSave_From);
            SaveIntoJson();
            ClickToSave_From = false;
            ClickToSave_To = false;
        }
        if(ClickToCopyBones){
            CopyData();
            ClickToCopyBones = false;
        }
    }
}

[System.Serializable]
public class CustomData
{
    public GameObject FromGameObject;
    public GameObject ToGameObject;
    public string custom_name;
    public int index;
    public BoneData boneData = new BoneData();
}

[System.Serializable]
public class BoneData
{
    public Transform[] bones;
    public string[] boneNames;
    public BoneWeight[] boneWeights;
    public Matrix4x4[] bindposes;
}
