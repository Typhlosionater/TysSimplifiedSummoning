using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.Linq;
using System.Text;

namespace TysSimplifiedSummoning.Items
{
    public class TysSimplifiedSummoningGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            //Whip Effects
            if (item.CountsAsClass(DamageClass.Summon) && (item.DamageType == DamageClass.SummonMeleeSpeed))
            {
                if (ItemID.Search.TryGetName(item.type, out string name))
                {
                    //Whips autoreuse
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().WhipAutoreuse == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().AutoreuseBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.autoReuse = true;
                    }
                }
            }

            //Minion Effects
            if (item.CountsAsClass(DamageClass.Summon) && !item.sentry && (item.DamageType != DamageClass.SummonMeleeSpeed))
            {
                if (ItemID.Search.TryGetName(item.type, out string name))
                {
                    //Minions don't cost mana
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().ManaFreeMinions == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().ManaBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.mana = 0;
                    }
                    //Minion summon speed increase
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().FasterMinions == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().SpeedBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.useTime = (int)(item.useTime / 2f);
                        item.useAnimation = (int)(item.useAnimation / 2f);
                        if (item.useTime < 10)
                        {
                            item.useTime = 10;
                            item.useAnimation = 10;
                        }
                    }
                    //Minions autoreuse
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().MinionAutoreuse == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().AutoreuseBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.autoReuse = true;
                    }
                }
            }

            //Sentries Effects
            if (item.CountsAsClass(DamageClass.Summon) && item.sentry && (item.DamageType != DamageClass.SummonMeleeSpeed))
            {
                if (ItemID.Search.TryGetName(item.type, out string name))
                {
                    //Sentries don't cost mana
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().ManaFreeSentries == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().ManaBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.mana = 0;
                    }
                    //Sentry summon speed increase
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().FasterSentries == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().SpeedBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.useTime = (int)(item.useTime / 2f);
                        item.useAnimation = (int)(item.useAnimation / 2f);
                        if (item.useTime < 10)
                        {
                            item.useTime = 10;
                            item.useAnimation = 10;
                        }
                    }
                    //Sentries autoreuse
                    if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().SentryAutoreuse == true && !ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().AutoreuseBlacklist.Contains(new ItemDefinition(name)))
                    {
                        item.autoReuse = true;
                    }
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<TysSimplifiedSummoningConfigServer>().SummonTooltips == true && item.CountsAsClass(DamageClass.Summon) && (item.DamageType != DamageClass.SummonMeleeSpeed))
            {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Knockback" && x.Mod == "Terraria");
                if (line != null)
                {
                    if (item.useStyle > 0)
                    {
                        string Temp = line.Text;

                        if (item.useAnimation <= 8)
                        {
                            line.Text = Lang.tip[6].Value;
                        }
                        else if (item.useAnimation <= 20)
                        {
                            line.Text = Lang.tip[7].Value;
                        }
                        else if (item.useAnimation <= 25)
                        {
                            line.Text = Lang.tip[8].Value;
                        }
                        else if (item.useAnimation <= 30)
                        {
                            line.Text = Lang.tip[9].Value;
                        }
                        else if (item.useAnimation <= 35)
                        {
                            line.Text = Lang.tip[10].Value;
                        }
                        else if (item.useAnimation <= 45)
                        {
                            line.Text = Lang.tip[11].Value;
                        }
                        else if (item.useAnimation <= 55)
                        {
                            line.Text = Lang.tip[12].Value;
                        }
                        else
                        {
                            line.Text = Lang.tip[13].Value;
                        }

                        line.Text += "\n";

                        line.Text += Temp;
                    }
                }
            }
        }
    }
}