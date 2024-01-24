using System;
using System.Collections.Generic;
using System.Linq;
using AmongUsBracken.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace AmongUsBracken
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class AmongUsBracken : BaseUnityPlugin
    {
        private const String modGUID = "GhastCraftHD.AmongUsBracken";
        private const String modName = "AmongUsBracken";
        private const String modVersion = "0.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static AmongUsBracken Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> SoundFX;
        internal static AssetBundle Bundle;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("AmongUsBracken was enabled");

            SoundFX = new List<AudioClip>();

            String FolderPath = Instance.Info.Location;
            FolderPath = FolderPath.TrimEnd("AmongUsBracken.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(FolderPath + "AmongUsBracken");
            if (Bundle != null)
            {
                mls.LogInfo("Loaded asset bundle successfully");
                SoundFX = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                mls.LogError("Failed to load asset bundle");
            }

            harmony.PatchAll(typeof(AmongUsBracken));
            harmony.PatchAll(typeof(FlowermanAIPatch));
        }
    }
}