using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Editor
{
    public class AvatarMaker
    {
        [MenuItem("CustomTools/MakeHumanAvatar")]
        private static void MakeHumanAvatar()
        {
            var activeGameObject = Selection.activeGameObject;

            if (activeGameObject == null) return;

            //var boneMapping = new Dictionary<string, string>
            //{
            //    {"Hips", "DEF-spine"},
            //    {"LeftUpperLeg", "DEF-thigh.L"},
            //    {"RightUpperLeg", "DEF-thigh.R"},
            //    {"LeftLowerLeg", "DEF-shin.L"},
            //    {"RightLowerLeg", "DEF-shin.R"},
            //    {"LeftFoot", "DEF-foot.L"},
            //    {"RightFoot", "DEF-foot.R"},
            //    {"Spine", "DEF-spine.001"},
            //    {"Chest", "DEF-spine.002"},
            //    {"Neck", "DEF-neck"},
            //    {"Head", "DEF-head"},
            //    {"LeftShoulder", "DEF-shoulder.L"},
            //    {"RightShoulder", "DEF-shoulder.R"},
            //    {"LeftUpperArm", "DEF-upper_arm.L"},
            //    {"RightUpperArm", "DEF-upper_arm.R"},
            //    {"LeftLowerArm", "DEF-forearm.L"},
            //    {"RightLowerArm", "DEF-forearm.R"},
            //    {"LeftHand", "DEF-hand.L"},
            //    {"RightHand", "DEF-hand.R"},
            //    {"LeftToes", "DEF-toe.L"},
            //    {"RightToes", "DEF-toe.R"},
            //    {"UpperChest", "DEF-spine.003"},
            //};

            var boneMapping = new Dictionary<string, string>
            {
                {"Hips", "spine"},
                {"Spine", "spine.001"},
                {"Chest", "spine.002"},
                {"UpperChest", "spine.003"},
                {"Neck", "spine.004"},
                {"Head", "spine.005"},
                {"LeftShoulder", "shoulder.L"},
                {"RightShoulder", "shoulder.R"},
                {"LeftUpperArm", "upper_arm.L"},
                {"RightUpperArm", "upper_arm.R"},
                {"LeftLowerArm", "forearm.L"},
                {"RightLowerArm", "forearm.R"},
                {"LeftHand", "hand.L"},
                {"RightHand", "hand.R"},
                {"RightUpperLeg", "thigh.R"},
                {"RightLowerLeg", "shin.R"},
                {"RightFoot", "foot.R"},
                {"RightToes", "toe.R"},
                {"LeftUpperLeg", "thigh.L"},
                {"LeftLowerLeg", "shin.L"},
                {"LeftFoot", "foot.L"},
                {"LeftToes", "toe.L"},
            };

            //var boneMapping = new Dictionary<string, string>
            //{
            //    {"Hips", "mixamorig:Hips"},
            //    {"Spine", "mixamorig:Spine"},
            //    {"Chest", "mixamorig:Spine1"},
            //    {"UpperChest", "mixamorig:Spine2"},
            //    {"Neck", "mixamorig:Neck"},
            //    {"Head", "mixamorig:Head"},

            //    {"LeftShoulder", "mixamorig:LeftShoulder"},
            //    {"LeftUpperArm", "mixamorig:LeftArm"},
            //    {"LeftLowerArm", "mixamorig:LeftForeArm"},
            //    {"LeftHand", "mixamorig:LeftHand"},

            //    {"RightShoulder", "mixamorig:RightShoulder"},
            //    {"RightUpperArm", "mixamorig:RightArm"},
            //    {"RightLowerArm", "mixamorig:RightForeArm"},
            //    {"RightHand", "mixamorig:RightHand"},

            //    {"LeftUpperLeg", "mixamorig:LeftUpLeg"},
            //    {"LeftLowerLeg", "mixamorig:LeftLeg"},
            //    {"LeftFoot", "mixamorig:LeftFoot"},
            //    {"LeftToes", "mixamorig:LeftToeBase"},

            //    {"RightUpperLeg", "mixamorig:RightUpLeg"},
            //    {"RightLowerLeg", "mixamorig:RightLeg"},
            //    {"RightFoot", "mixamorig:RightFoot"},
            //    {"RightToes", "mixamorig:RightToeBase"},
            //};

            var humanDescription = new HumanDescription
            {
                human = boneMapping.Select(mapping =>
                {
                    var bone = new HumanBone { humanName = mapping.Key, boneName = mapping.Value };
                    bone.limit.useDefaultValues = true;
                    return bone;
                }).ToArray(),
            };

            var avatar = AvatarBuilder.BuildHumanAvatar(activeGameObject, humanDescription);
            avatar.name = activeGameObject.name;

            if (!avatar.isValid)
            {
                Debug.LogError("Invalid avatar");
                return;
            }

            Debug.Log(avatar.isHuman ? "is human" : "is generic");

            var path = $"Assets/{avatar.name.Replace(':', '_')}.ht";
            AssetDatabase.CreateAsset(avatar, path);
        }
    }
}

