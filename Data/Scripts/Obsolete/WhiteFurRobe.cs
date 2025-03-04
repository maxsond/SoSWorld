using System;

namespace Server.Items
{
	[Flipable( 0x1F03, 0x1F04 )]
	public class WhiteFurRobe : Robe
	{
		[Constructable]
		public WhiteFurRobe() : base( 0x1F03 )
		{
			Name = "fur robe";
			Hue = 0x481;
			Weight = 6.0;
			Resistances.Cold = 20;
		}

		public WhiteFurRobe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new Robe();
			item.Resource = CraftResource.WoolyFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}