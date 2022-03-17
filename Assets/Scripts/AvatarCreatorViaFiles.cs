using UnityEditor;
using UnityEngine;

namespace Infrastructure.Editor
{
    public class avatarCreator
    {
        [MenuItem("AvatarTools/CreateAvatarMask")]
        private static void CreateAvatarMask()
        {
            GameObject activeGameObject = Selection.activeGameObject;

            if (activeGameObject != null)
            {
                AvatarMask avatarMask = new AvatarMask();

                avatarMask.AddTransformPath(activeGameObject.transform);

                var path = string.Format("Assets/{0}.mask", activeGameObject.name.Replace(':', '_'));
                AssetDatabase.CreateAsset(avatarMask, path);
            }
        }

        [MenuItem("AvatarTools/CreateAvatar")]
        private static void CreateAvatar()
        {
            GameObject activeGameObject = Selection.activeGameObject;
            var humanDescription = new HumanDescription();

            if (activeGameObject != null)
            {
                Avatar avatar = AvatarBuilder.BuildHumanAvatar(activeGameObject, humanDescription);
                avatar.name = activeGameObject.name;
                Debug.Log(avatar.isHuman ? "is human" : "is generic");

                var path = string.Format("Assets/{0}.ht", avatar.name.Replace(':', '_'));
                AssetDatabase.CreateAsset(avatar, path);
            }
        }
    }
}