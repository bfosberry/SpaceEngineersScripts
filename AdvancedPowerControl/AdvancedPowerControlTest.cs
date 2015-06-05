using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System;

namespace SpaceEngineersScripts.AdvancedPowerControl
{
	using NUnit.Framework;

	[TestFixture]
	public class AdvancedPowerControlTest
	{
		AdvancedPowerController powerControl;

		[SetUp] public void Before ()
		{
			powerControl = new AdvancedPowerController ();
		}

		class DetailedInfoStubTerminalBlock : Common.StubTerminalBlock
		{
			private string details;

			public override string DetailedInfo {
				get {
					return details;
				}
			}

			public DetailedInfoStubTerminalBlock (string details)
			{
				this.details = details;
			}
		}

		[Test]
		public void getDetailedInfoValueTest ()
		{
			string details = "a: b \nc :d\r e : f\r\nfoo\n bar:baz:bing";
			IMyTerminalBlock block = new DetailedInfoStubTerminalBlock (details);

			// for an invalid key
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "fizzle"), "");

			// for an invalid key (no corresponding value)
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "foo"), "");

			// for an valid key
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "a"), "b");

			// for an valid key with a space after it
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "c"), "d");

			// for an valid key with a space before and after it
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "e"), "f");

			// for an valid key with multiple values after it, should return first value
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "bar"), "baz");
		}

		[Test]
		public void getPowerAsIntTest ()
		{
			// with no string data
			Assert.AreEqual (powerControl.getPowerAsInt (""), 0);

			// with a bad string (no space)
			Assert.AreEqual (powerControl.getPowerAsInt ("100kWh"), 0);

			// with a bad string (not power or power rate)
			Assert.AreEqual (powerControl.getPowerAsInt ("100 foo"), 0);

			// with a wattage value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 W"), 100);

			// with a wattage hour value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 Wh"), 100);

			// with a kilowattage value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 kW"), 100000);

			// with a kilowattage hour value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 kWh"), 100000);

			// with a megawattage value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 MW"), 100000000);

			// with a megawattage hour value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 MWh"), 100000000);

		}

		class GetBatteriesStubTerminalSystem : Common.StubGridTerminalSystem
		{
			private List<IMyTerminalBlock> blocks;

			public override void GetBlocksOfType<T> (List<IMyTerminalBlock> blockList, Func<IMyTerminalBlock, bool> collect)
			{
				if (typeof(T) == typeof(IMyBatteryBlock)) {
					blockList.AddList (blocks);
				}
			}

			public GetBatteriesStubTerminalSystem (List<IMyTerminalBlock> blocks)
			{
				this.blocks = blocks;
			}
		}

		[Test]
		public void getBatteriesTest ()
		{
			List<IMyTerminalBlock> blocks = new List<IMyTerminalBlock> ();
			powerControl.GridTerminalSystem = new GetBatteriesStubTerminalSystem (blocks);

			// with a no blocks provided
			Assert.AreEqual (powerControl.getBatteries (), blocks);


			blocks.Add (new Common.StubTerminalBlock ());
			powerControl.GridTerminalSystem = new GetBatteriesStubTerminalSystem (blocks);

			// with a provided list of blocks
			Assert.AreEqual (powerControl.getBatteries (), blocks);
		
		}
	}
}