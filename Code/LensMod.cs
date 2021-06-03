using BepInEx;

using R2API;
using R2API.Utils;

namespace LensMod
{
    [BepInDependency(R2API.R2API.PluginGUID)]
    [R2APISubmoduleDependency(nameof(ItemAPI), nameof(LanguageAPI))]
    [BepInPlugin(ModGuid, ModName, ModVer)]
    public class LensMod : BaseUnityPlugin
    {
        private const string ModVer = "1.0.1";
        private const string ModName = "LensMod";
        private const string ModGuid = "com.headline.lensmod";

        private LensItem item;

        public void Awake()
        {
            item = new LensItem();
            this.AddItem(item);

            On.RoR2.HealthComponent.TakeDamage += item.OnTakeDamage;
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