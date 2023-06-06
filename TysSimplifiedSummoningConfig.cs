using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace TysSimplifiedSummoning
{
	[Label("Mod Config")]
	public class TysSimplifiedSummoningConfigServer : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		//Mana Free Minion Config
		[Label("Minions cost no mana to summon")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ManaFreeMinions { get; set; }

		//Mana Free Sentry Config
		[Label("Sentries cost no mana to summon")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ManaFreeSentries { get; set; }

		//Mana Free Blacklist Config
		[ReloadRequired]
		[Label("Mana cost blacklist")]
		[Tooltip("Items added to this blacklist will not have their mana cost removed")]
		public List<ItemDefinition> ManaBlacklist { get; set; } = new List<ItemDefinition>
				{
				};

		//Faster Minion Config
		[Label("Increases the summoning speed of minions")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool FasterMinions { get; set; }

		//Faster Sentry Config
		[Label("Increases the summoning speed of sentries")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool FasterSentries { get; set; }

		//Faster Blacklist Config
		[ReloadRequired]
		[Label("Summoning speed blacklist")]
		[Tooltip("Items added to this blacklist will not have their summoning speed increased")]
		public List<ItemDefinition> SpeedBlacklist { get; set; } = new List<ItemDefinition>
				{
				};

		//Autoreuse Minion Config
		[Label("All minion weapons have autoreuse")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool MinionAutoreuse { get; set; }

		//Autoreuse Sentry Config
		[Label("All sentry weapons have autoreuse")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool SentryAutoreuse { get; set; }

		//Autoreuse Whip Config
		[Label("All whip weapons have autoreuse")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool WhipAutoreuse { get; set; }

		//Autoreuse Blacklist Config
		[ReloadRequired]
		[Label("Autoreuse blacklist")]
		[Tooltip("Items added to this blacklist will not be given autoreuse")]
		public List<ItemDefinition> AutoreuseBlacklist { get; set; } = new List<ItemDefinition>
				{
				};

		//Summon Speed Tooltip Config
		[Label("Non-whip summon weapons display their use speed too")]
		[Tooltip("(Enabled by default)")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool SummonTooltips { get; set; }
	}
}
