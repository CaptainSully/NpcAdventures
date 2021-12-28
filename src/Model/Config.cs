using StardewModdingAPI;

namespace NpcAdventure.Model
{
    class Config
    {
        public SButton ChangeBuffButton { get; set; } = SButton.G;
        public int HeartThreshold { get; set; } = 5;
        public int HeartSuggestThreshold { get; set; } = 7;
        public bool ShowHUD { get; set; } = true;
        public bool EnableDebug { get; set; } = false;
        public bool AdventureMode { get; set; } = true;
        public bool AvoidSayHiToMonsters { get; set; } = true;
        public bool RequestsWithShift { get; set; } = false;
        public SButton RequestsShiftButton { get; set; } = SButton.LeftShift;
        public ExperimentalFeatures Experimental { get; set; } = new ExperimentalFeatures();
        public bool AllowGainFriendship { get; set; } = true;
        public bool FightThruCompanion { get; set; } = true;
        // from version 0.16.0 will be removed and enabled hard
        public bool UseCheckForEventsPatch { get; set; } = true;
        public bool AllowEntryLockedCompanionHouse { get; set; } = true;
        public bool UseAsk2FollowCursor { get; set; } = true;
        public bool AllowLegacyContentPacks { get; set; } = false;

        public class ExperimentalFeatures
        {    
        }

        public static void VerifyConfigValues(Config config, NpcAdventureMod mod)
        {
            bool invalidConfig = false;

            if (config.HeartThreshold < 0 || config.HeartThreshold > 10)
            {
                invalidConfig = true;
                config.HeartThreshold = 5;
            }
            if (config.HeartSuggestThreshold < 0 || config.HeartSuggestThreshold > 10)
            {
                invalidConfig = true;
                config.HeartSuggestThreshold = 7;
            }
            if (config.Experimental == null)
            {
                //invalidConfig = true;
                //config.Experimental = something?;
            }

            if (invalidConfig)
            {
                Log.I("At least one config value was out of range and was reset.");
                mod.Helper.WriteConfig(config);
            }
        }

        public static void SetUpModConfigMenu(Config config, NpcAdventureMod mod)
        {
            IGenericModConfigMenuApi api = mod.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (api == null) { return; }
            var manifest = mod.ModManifest;

            api.Register(manifest, () => config = new Config(), delegate { mod.Helper.WriteConfig(config); VerifyConfigValues(config, mod); });

            api.AddKeybind(manifest, () => config.ChangeBuffButton, val => config.ChangeBuffButton = val,
                    name: () => "Set buff button");

            api.AddNumberOption(manifest, () => config.HeartThreshold, (int val) => config.HeartThreshold = val,
                    name: () => "Hearts needed to recruit someone");

            api.AddNumberOption(manifest, () => config.HeartSuggestThreshold, (int val) => config.HeartSuggestThreshold = val,
                    name: () => "Heart suggest threshold");

            api.AddBoolOption(manifest, () => config.ShowHUD, (bool val) => config.ShowHUD = val,
                    name: () => "Show HUD");

            api.AddBoolOption(manifest, () => config.AdventureMode, (bool val) => config.AdventureMode = val,
                    name: () => "Adventure mode");

            api.AddBoolOption(manifest, () => config.AvoidSayHiToMonsters, (bool val) => config.AvoidSayHiToMonsters = val,
                    name: () => "Avoid say hi to monsters");

            api.AddBoolOption(manifest, () => config.RequestsWithShift, (bool val) => config.RequestsWithShift = val,
                    name: () => "Requests with shift");

            api.AddKeybind(manifest, () => config.RequestsShiftButton, val => config.RequestsShiftButton = val,
                    name: () => "Set requests button");

            api.AddBoolOption(manifest, () => config.AllowGainFriendship, (bool val) => config.AllowGainFriendship = val,
                    name: () => "Allow gain friendship");

            api.AddBoolOption(manifest, () => config.FightThruCompanion, (bool val) => config.FightThruCompanion = val,
                    name: () => "Fight through companion");

            api.AddBoolOption(manifest, () => config.UseCheckForEventsPatch, (bool val) => config.UseCheckForEventsPatch = val,
                    name: () => "Use check for events patch");

            api.AddBoolOption(manifest, () => config.AllowEntryLockedCompanionHouse, (bool val) => config.AllowEntryLockedCompanionHouse = val,
                    name: () => "Allow entry to locked companions house");

            api.AddBoolOption(manifest, () => config.UseAsk2FollowCursor, (bool val) => config.UseAsk2FollowCursor = val,
                    name: () => "Use ask to follow cursor");

            api.AddBoolOption(manifest, () => config.AllowLegacyContentPacks, (bool val) => config.AllowLegacyContentPacks = val,
                    name: () => "Allow legacy content packs");
        }
    }
}
