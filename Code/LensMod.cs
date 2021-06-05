using BepInEx;

using R2API;
using R2API.Utils;
using RoR2;
using System.Runtime.CompilerServices;

namespace LensMod
{
    [BepInDependency(R2API.R2API.PluginGUID)]
    [BepInDependency("dev.ontrigger.itemstats", BepInDependency.DependencyFlags.SoftDependency)]
    [R2APISubmoduleDependency(nameof(ItemAPI), nameof(LanguageAPI))]
    [BepInPlugin(ModGuid, ModName, ModVer)]
    public class LensMod : BaseUnityPlugin
    {
        private const string ModVer = "1.1.0";
        private const string ModName = "LensMod";
        private const string ModGuid = "com.headline.lensmod";

        private LensItem item;

        public void Awake()
        {
            item = new LensItem();
            this.AddItem(item);

            RoR2Application.onLoad += () =>
            {
                if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("dev.ontrigger.itemstats"))
                {
                    this.AddToItemStats();
                }
            };

            On.RoR2.HealthComponent.TakeDamage += item.OnTakeDamage;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void AddToItemStats()
        {
            var idx = ItemCatalog.FindItemIndex("LensMakersMagnifyingGlass");
            if (idx.ToString() == "None")
            {
                this.Logger.LogError($"Unable to add LensMakersMagnifyingGlass to ItemStatsMod");
                return;
            }
            this.Logger.LogMessage($"Adding LensMakersMagnifyingGlass (idx {idx}) to ItemStatsMod");
            ItemStats.ItemStatsMod.AddCustomItemStatDef(idx, item.CreateItemStatDef());
        }

        private void AddItem(LensItem item)
        {
            var lens_item = new CustomItem(item.Definition, item.BuildDisplayRules());
            if (!ItemAPI.Add(lens_item))
            {
                this.Logger.LogError("Unable to add lens item");
            }
        }

        private static void AddLanguageTokens()
        {
            LanguageAPI.Add("LENSITEM_NAME", "Lens Maker's Magnifying Glass");
            LanguageAPI.Add("LENSITEM_PICKUP", "Critical strike damage is increased");
            LanguageAPI.Add("LENSITEM_DESC", "Critical strike damage is increased");
            LanguageAPI.Add("LENSITEM_LORE", "The prototype for the lens but it didnt work so the lens maker brought it to the government and the government said no and he said arr and then killed someone with them");
        }
    }
}