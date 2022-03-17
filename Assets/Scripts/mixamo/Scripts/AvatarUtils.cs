using System.Collections.Generic;
using UnityEngine;

namespace BKUnity
{
    public class AvatarUtils
    {
        //A static dictionary containing the mapping from joint/bones names in the model
        //to the names Unity uses for them internally.
        //In this case they match the naming from the included Mixamo model on the left
        //and the Unity equivalent name on the right. 
        //This does not need to be hard-coded. 
        public static Dictionary<string, string> HumanSkeletonNames = new Dictionary<string, string>()
        {
            //{"mixamorig:Spine1", "Chest"},
            //{"mixamorig:Head", "Head" },
            //{"mixamorig:Hips", "Hips" },
            //{"mixamorig:LeftHandIndex3", "Left Index Distal" },
            //{"mixamorig:LeftHandIndex2", "Left Index Intermediate" },
            //{"mixamorig:LeftHandIndex1", "Left Index Proximal" },
            //{"mixamorig:LeftHandPinky3", "Left Little Distal" },
            //{"mixamorig:LeftHandPinky2", "Left Little Intermediate" },
            //{"mixamorig:LeftHandPinky1", "Left Little Proximal" },
            //{"mixamorig:LeftHandMiddle3", "Left Middle Distal" },
            //{"mixamorig:LeftHandMiddle2", "Left Middle Intermediate" },
            //{"mixamorig:LeftHandMiddle1", "Left Middle Proximal" },
            //{"mixamorig:LeftHandRing3", "Left Ring Distal" },
            //{"mixamorig:LeftHandRing2", "Left Ring Intermediate" },
            //{"mixamorig:LeftHandRing1", "Left Ring Proximal" },
            //{"mixamorig:LeftHandThumb3", "Left Thumb Distal" },
            //{"mixamorig:LeftHandThumb2", "Left Thumb Intermediate" },
            //{"mixamorig:LeftHandThumb1", "Left Thumb Proximal" },
            //{"mixamorig:LeftFoot", "LeftFoot" },
            //   {"mixamorig:LeftHand", "LeftHand" },
            //{"mixamorig:LeftForeArm", "LeftLowerArm" },
            //{"mixamorig:LeftLeg", "LeftLowerLeg" },
            //{"mixamorig:LeftShoulder", "LeftShoulder" },
            //{"mixamorig:LeftToeBase", "LeftToes" },
            //{"mixamorig:LeftArm", "LeftUpperArm" },
            //{"mixamorig:LeftUpLeg", "LeftUpperLeg" },
            //{"mixamorig:Neck", "Neck" },
            //{"mixamorig:RightHandIndex3", "Right Index Distal" },
            //{"mixamorig:RightHandIndex2", "Right Index Intermediate" },
            //{"mixamorig:RightHandIndex1", "Right Index Proximal" },
            //{"mixamorig:RightHandPinky3", "Right Little Distal" },
            //{"mixamorig:RightHandPinky2", "Right Little Intermediate" },
            //{"mixamorig:RightHandPinky1", "Right Little Proximal" },
            //{"mixamorig:RightHandMiddle3", "Right Middle Distal" },
            //{"mixamorig:RightHandMiddle2", "Right Middle Intermediate" },
            //{"mixamorig:RightHandMiddle1", "Right Middle Proximal" },
            //{"mixamorig:RightHandRing3", "Right Ring Distal" },
            //{"mixamorig:RightHandRing2", "Right Ring Intermediate" },
            //{"mixamorig:RightHandRing1", "Right Ring Proximal" },
            //{"mixamorig:RightHandThumb3", "Right Thumb Distal" },
            //{"mixamorig:RightHandThumb2", "Right Thumb Intermediate" },
            //{"mixamorig:RightHandThumb1", "Right Thumb Proximal" },
            //{"mixamorig:RightFoot", "RightFoot" },
            //{"mixamorig:RightHand", "RightHand" },
            //{"mixamorig:RightForeArm", "RightLowerArm" },
            //{"mixamorig:RightLeg", "RightLowerLeg" },
            //{"mixamorig:RightShoulder", "RightShoulder" },
            //{"mixamorig:RightToeBase", "RightToes" },
            //{"mixamorig:RightArm", "RightUpperArm" },
            //{"mixamorig:RightUpLeg", "RightUpperLeg" },
            //{"mixamorig:Spine", "Spine" },
            //{"mixamorig:Spine2", "UpperChest" }


            // blender
            {"spine" , "Hips"},
            {"spine.001", "Spine"},
            {"spine.002", "Chest"},
            {"spine.003", "UpperChest"},
            {"spine.004", "Neck"},
            {"spine.005", "Head"},
            {"shoulder.L", "LeftShoulder"},
            {"shoulder.R", "RightShoulder"},
            {"upper_arm.L", "LeftUpperArm"},
            {"upper_arm.R", "RightUpperArm"},
            {"forearm.L", "LeftLowerArm"},
            {"forearm.R", "RightLowerArm"},
            {"hand.L", "LeftHand"},
            {"hand.R", "RightHand"},
            {"thigh.R", "RightUpperLeg"},
            {"shin.R", "RightLowerLeg"},
            {"foot.R", "RightFoot"},
            {"toe.R", "RightToes"},
            {"thigh.L", "LeftUpperLeg"},
            {"shin.L", "LeftLowerLeg"},
            {"foot.L", "LeftFoot"},
            {"toe.L", "LeftToes"},

            //
            //   {"spine.03" , "Hips"},
            //{"spine.02", "Spine"},
            //{"spine.01", "Chest"},
            ////{"", "UpperChest"},
            //{"neck", "Neck"},
            //{"head", "Head"},

            ////{"", "LeftShoulder"},
            //{"upper_arm.L", "LeftUpperArm"},
            //{"forearm.L", "LeftLowerArm"},
            //{"palm.01.L", "LeftHand"},

            ////{"", "RightShoulder"},
            //{"upper_arm.R", "RightUpperArm"},
            //{"forearm.R", "RightLowerArm"},
            //{"palm.01.R", "RightHand"},

            //{"thigh.L", "RightUpperLeg"},
            //{"shin.L", "RightLowerLeg"},
            //{"foot.L", "RightFoot"},
            //{"toe.L", "RightToes"},

            //{"thigh.R", "LeftUpperLeg"},
            //{"shin.R", "LeftLowerLeg"},
            //{"foot.R", "LeftFoot"},
            //{"toe.R", "LeftToes"},

            //            {"Hips" , "Hips"},
            //{"Spine", "Spine"},
            //{"Spine1", "Chest"},
            //{"Spine2", "UpperChest"},
            //{"Neck", "Neck"},
            //{"Head", "Head"},
            //{"LeftShoulder", "LeftShoulder"},
            //{"RightShoulder", "RightShoulder"},
            //{"LeftArm", "LeftUpperArm"},
            //{"RightArm", "RightUpperArm"},
            //{"LeftForeArm", "LeftLowerArm"},
            //{"RightForeArm", "RightLowerArm"},
            //{"LeftHand", "LeftHand"},
            //{"RightHand", "RightHand"},
            //{"RightUpLeg", "RightUpperLeg"},
            //{"RightLeg", "RightLowerLeg"},
            //{"RightFoot", "RightFoot"},
            //{"RightToeBase", "RightToes"},
            //{"LeftUpLeg", "LeftUpperLeg"},
            //{"LeftLeg", "LeftLowerLeg"},
            //{"LeftFoot", "LeftFoot"},
            //{"LeftToeBase", "LeftToes"},

            // kongz 
            //            {"Hip-Global" , "Hips"},
            // {"Belly-Global", "Spine"},
            // {"Chest-Global", "Chest"},
            // // {"Spine2", "UpperChest"},
            // {"Neck", "Neck"},
            // {"Head-Global", "Head"},
            // // {"", "RightShoulder"},
            // {"Right_Arm-Global", "RightUpperArm"},
            // {"Right_Forearm-Global", "RightLowerArm"},
            // {"Right_Hand-Global", "RightHand"},
            // // {"", "LeftShoulder"},
            // {"Left_Arm-Global", "LeftUpperArm"},
            // {"Left_Forearm-Global", "LeftLowerArm"},
            // {"Left_Hand-Global", "LeftHand"},

            // {"Right_Thigh-Global", "RightUpperLeg"},
            // {"Right_Leg-Global", "RightLowerLeg"},
            // {"Right_Foot-Global", "RightFoot"},
            ////  {"", "RightToes"},
            // {"Left_Thigh-Global", "LeftUpperLeg"},
            // {"Left_Leg-Global", "LeftLowerLeg"},
            // {"Left_Foot-Global", "LeftFoot"},
            // // {"", "LeftToes"},

        };

        /// <summary>
        /// Create a HumanDescription out of an avatar GameObject. 
        /// The HumanDescription is what is needed to create an Avatar object
        /// using the AvatarBuilder API. This function takes care of 
        /// creating the HumanDescription by going through the avatar's
        /// hierarchy, defining its T-Pose in the skeleton, and defining
        /// the transform/bone mapping in the HumanBone array. 
        /// </summary>
        /// <param name="avatarRoot">Root of your avatar object</param>
        /// <returns>A HumanDescription which can be fed to the AvatarBuilder API</returns>
        public static HumanDescription CreateHumanDescription(GameObject avatarRoot)
        {
            HumanDescription description = new HumanDescription()
            {
                armStretch = 0.05f,
                feetSpacing = 0f,
                hasTranslationDoF = false,
                legStretch = 0.05f,
                lowerArmTwist = 0.5f,
                lowerLegTwist = 0.5f,
                upperArmTwist = 0.5f,
                upperLegTwist = 0.5f,
                skeleton = CreateSkeleton(avatarRoot),
                human = CreateHuman(avatarRoot),
            };
            return description;
        }

        //Create a SkeletonBone array out of an Avatar GameObject
        //This assumes that the Avatar as supplied is in a T-Pose
        //The local positions of its bones/joints are used to define this T-Pose
        private static SkeletonBone[] CreateSkeleton(GameObject avatarRoot)
        {
            List<SkeletonBone> skeleton = new List<SkeletonBone>();

            Transform[] avatarTransforms = avatarRoot.GetComponentsInChildren<Transform>();
            foreach (Transform avatarTransform in avatarTransforms)
            {
                SkeletonBone bone = new SkeletonBone()
                {
                    name = avatarTransform.name,
                    position = avatarTransform.localPosition,
                    rotation = avatarTransform.localRotation,
                    scale = avatarTransform.localScale
                };

                skeleton.Add(bone);
            }
            return skeleton.ToArray();
        }

        //Create a HumanBone array out of an Avatar GameObject
        //This is where the various bones/joints get associated with the
        //joint names that Unity understands. This is done using the
        //static dictionary defined at the top. 
        private static HumanBone[] CreateHuman(GameObject avatarRoot)
        {
            List<HumanBone> human = new List<HumanBone>();

            Transform[] avatarTransforms = avatarRoot.GetComponentsInChildren<Transform>();
            foreach (Transform avatarTransform in avatarTransforms)
            {
                if (HumanSkeletonNames.TryGetValue(avatarTransform.name, out string humanName))
                {
                    HumanBone bone = new HumanBone
                    {
                        boneName = avatarTransform.name,
                        humanName = humanName,
                        limit = new HumanLimit()
                    };
                    bone.limit.useDefaultValues = true;

                    human.Add(bone);
                }
            }
            return human.ToArray();
        }
    }
}
