using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCFirstMod.Patches;

namespace LCFirstMod
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class LCMod : BaseUnityPlugin
    {
        private const string ModGuid = "Burstyx.LCFirstMod";
        private const string ModName = "LC FirstMod";
        private const string ModVersion = "1.0.0";

        private readonly Harmony _harmony = new Harmony(ModGuid);

        private static LCMod _instance;

        private ManualLogSource _mls;

        private void Awake()
        {
            if (_instance == null) _instance = this;

            _mls = BepInEx.Logging.Logger.CreateLogSource(ModGuid);
            
            _mls.LogInfo("My first mod is loaded ^^!");
            
            _harmony.PatchAll(typeof(LCMod));
            _harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}