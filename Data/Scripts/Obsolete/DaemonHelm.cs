using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1451, 0x1456 )]
	public class DaemonHelm : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		public override int InitMinHits{ get{ return 40; } }
		public override int InitMaxHits{ get{ return 70; } }

		public override int AosStrReq{ get{ return 20; } }
		public override int OldStrReq{ get{ return 40; } }

		public override int ArmorBase{ get{ return 46; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override int LabelNumber{ get{ return 1041374; } } // daemon bone helmet

		[Constructable]
		public DaemonHelm() : base( 0x1451 )
		{
			Hue = 0x648;
			Weight = 3.0;

			ArmorAttributes.SelfRepair = 1;
			ArmorAttributes.MageArmor = 1;
			Attributes.BonusMana = 5;
			Attributes.BonusInt = 4;
			Attributes.RegenMana = 1;
			Attributes.Luck = 50; 
			Attributes.LowerRegCost = 12;
		}

		public DaemonHelm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new BoneHelm();
			((BaseArmor)item).Resource = CraftResource.DevilSkeletal;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}