using HarmonyLib;
using UnityEngine;

namespace AutoOcto {
    [HarmonyPatch(typeof(scnEditor), "Start")]
    public class EditorOctoPatch {
        public static void Postfix() {
            ADOBase.controller.unlockKeyLimiter = true;
            scnEditor.instance.unlockKeyLimiterImage.color = Color.white;
        }
    }
}