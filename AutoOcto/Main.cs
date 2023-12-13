using System.Reflection;
using HarmonyLib;
using UnityModManagerNet;

namespace AutoOcto {
    public class Main {
        public static UnityModManager.ModEntry.ModLogger Logger;
        public static Harmony Harmony;
        public static bool Enabled;

        public static void Setup(UnityModManager.ModEntry modEntry) {
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
        }

        public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
            Enabled = value;
            if(value) {
                Harmony = new Harmony(modEntry.Info.Id);
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            } else Harmony.UnpatchAll(modEntry.Info.Id);
            return true;
        }
    }
}