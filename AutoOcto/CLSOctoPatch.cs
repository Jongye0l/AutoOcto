using DG.Tweening;
using HarmonyLib;

namespace AutoOcto {
    [HarmonyPatch(typeof(scnCLS), "Refresh")]
    public class CLSOctoPatch {
        public static void Postfix(bool setup) {
            if(!setup || GCS.useUnlockKeyLimiter) return;
            GCS.useUnlockKeyLimiter = true;
            foreach (OptionsPanelsCLS.Option rightPanelOption in scnCLS.instance.optionsPanels.rightPanelOptions)
                if(rightPanelOption.name == OptionsPanelsCLS.OptionName.UnlockKeyLimiter) {
                    rightPanelOption.selected = true;
                    rightPanelOption.text.DOKill();
                    rightPanelOption.text.DOColor(scnCLS.instance.optionsPanels.selectedColor, 0.15f);
                }
        }
    }
}