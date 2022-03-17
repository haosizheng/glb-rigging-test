using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Editor
{
    public class GetBoneData : MonoBehaviour
    {
        [MenuItem("CustomTools/SaveBoneData")]
        private static void SaveBoneData()
        {
            var activeGameObject = Selection.activeGameObject;
            var BoneData = activeGameObject.GetComponent<SkinnedMeshRenderer>().bones;
            var BindePoseData = activeGameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.bindposes;
            var path = $"Assets/BoneData/{activeGameObject.name.Replace(':', '_')}_BoneData.json";
            var path2 = $"Assets/BoneData/{activeGameObject.name.Replace(':', '_')}_BindPoseData.json";
            // AssetDatabase.CreateAsset(avatar, path);
        }
    }

}
