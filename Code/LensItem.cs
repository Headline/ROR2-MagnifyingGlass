using System;
using System.Reflection;
using R2API;
using RoR2;
using UnityEngine;

using static On.RoR2.HealthComponent;

namespace LensMod
{
    class LensItem
    {
        public ItemDef Definition { get; private set; }

        public GameObject ItemModel;
        public Sprite ItemIcon;

        public LensItem()
        {
            this.LoadAssets();
            this.Definition = this.BuildItemDefinition();
        }

        private void LoadAssets()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LensMod.lensmod"))
            {
                var bundle = AssetBundle.LoadFromStream(stream);

                this.ItemModel = bundle.LoadAsset<GameObject>("Assets/model.dae");
                this.ItemIcon = bundle.LoadAsset<Sprite>("Assets/icon.png");
            }
        }

        private ItemDef BuildItemDefinition()
        {
            var itemdef = ScriptableObject.CreateInstance<ItemDef>();
            itemdef.name = "LENSITEM";
            itemdef.tier = ItemTier.Tier2;
            itemdef.tags = new[]{
                ItemTag.Damage
            };
            itemdef.pickupModelPrefab = this.ItemModel;
            itemdef.pickupIconSprite = this.ItemIcon;
            itemdef.nameToken = "Lens Maker's Magnifying Glass";
            itemdef.pickupToken = "Critical strike damage is increased";
            itemdef.descriptionToken = "Critical strike damage is increased! Stacks to a maximum of double the damage.";
            itemdef.loreToken = "The prototype for the lens but it didnt work so the lens maker brought it to the government and the government said no and lens man said arr and then killed someone with them";
            return itemdef;
        }

        public ItemDisplayRuleDict BuildDisplayRules()
        {
            ItemDisplayRuleDict dict = new ItemDisplayRuleDict();
            dict.Add("mdlCommandoDualies", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(0.08832F, 0.15109F, -0.10412F),
                localAngles = new Vector3(0F, 120F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlHuntress", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(-0.00331F, 0.10582F, -0.09374F),
                localAngles = new Vector3(0F, 0F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlToolbot", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(0.97156F, 4.02498F, -0.11258F),
                localAngles = new Vector3(340F, 90F, 180F),
                localScale = new Vector3(2F, 2F, 2F)
            });
            dict.Add("mdlEngi", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(0.03088F, 0.02799F, -0.22667F),
                localAngles = new Vector3(0F, 0F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlMage", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(-0.0121F, 0.23915F, -0.06297F),
                localAngles = new Vector3(0F, 0F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlMerc", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(-0.02027F, 0.20177F, -0.15007F),
                localAngles = new Vector3(0F, 0F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlTreebot", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "FootBackL",
                localPos = new Vector3(-0.10585F, 0.5113F, -0.00238F),
                localAngles = new Vector3(0F, 90F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlLoader", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(0.0643F, 0.23763F, -0.0847F),
                localAngles = new Vector3(0F, 330F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlCroco", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(0.16156F, 0.8883F, -1.25733F),
                localAngles = new Vector3(15F, 0F, 0F),
                localScale = new Vector3(2F, 2F, 2F)
            });
            dict.Add("mdlCaptain", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "CalfL",
                localPos = new Vector3(0.00525F, 0.29403F, 0.10998F),
                localAngles = new Vector3(345F, 0F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });
            dict.Add("mdlBandit2", new ItemDisplayRule
            {
                ruleType = ItemDisplayRuleType.ParentedPrefab,
                followerPrefab = this.ItemModel,
                childName = "ThighL",
                localPos = new Vector3(-0.00035F, 0.32595F, 0.09654F),
                localAngles = new Vector3(0F, 0F, 0F),
                localScale = new Vector3(0.35F, 0.35F, 0.35F)
            });

            return dict;
        }

        public void OnTakeDamage(orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            GameObject dmgSource = null;
            if (damageInfo.attacker != null)
            {
                dmgSource = damageInfo.attacker;
            }
            else if (damageInfo.inflictor != null)
            {
                dmgSource = damageInfo.inflictor;
            }
            else // no damage source, nothing for us to do?
            {
                orig(self, damageInfo);
                return;
            }

            var body = dmgSource.GetComponent<CharacterBody>();
            if (body != null)
            {
                if (body.inventory != null)
                {
                    var item_count = body.inventory.GetItemCount(this.Definition);
                    if (item_count > 0)
                    {
                        if (damageInfo.crit)
                        {
                            var modifier = LensItem.CalculateDamageModifier(item_count) + 1f;
                            damageInfo.damage *= modifier;
                        }
                    }
                }
            }

            orig(self, damageInfo);
            return;
        }

        public static float CalculateDamageModifier(int item_count)
        {
            // y=-0.22-(-0.37/0.29)*(1-e^(-0.29*x))
            return -0.22f - (-1.275f * (1.0f - (float)Math.Exp(-0.29f * item_count)));
        }
    }
}
