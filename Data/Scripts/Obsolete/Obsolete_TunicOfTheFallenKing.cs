using System;
using Server;

namespace Server.Items
{
	public class TunicOfTheFallenKing : LeatherChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 19; } }
		public override int BaseEnergyResistance{ get{ return 19; } }

		[Constructable]
		public TunicOfTheFallenKing()
		{
			Name = "Tunic of the Fallen King";
			Hue = 0x76D;
			Attributes.BonusStr = 8;
			Attributes.RegenHits = 15;
			Attributes.RegenStam = 5;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public TunicOfTheFallenKing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_TunicOfTheFallenKing(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x551 )
					Hue = 0x76D;

				ColdBonus = 0;
				EnergyBonus = 0;
			}
		}
	}
}