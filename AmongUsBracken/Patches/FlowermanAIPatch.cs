using HarmonyLib;

namespace AmongUsBracken.Patches
{
    [HarmonyPatch(typeof(FlowermanAI))]
    internal class FlowermanAIPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void OverrideAudio(FlowermanAI __instance)
        {
            __instance.crackNeckSFX = AmongUsBracken.SoundFX[0];
        }
    }
}