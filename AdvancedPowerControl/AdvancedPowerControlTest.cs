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
		IMyTerminalBlock block;

		[SetUp] public void Before ()
		{
			powerControl = new AdvancedPowerController ();

			string details = "a: b \nc :d\r e : f\r\nfoo\n bar:baz:bing";
			block = new DetailedInfoStubTerminalBlock (details);
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
		public void getDetailedInfoValueTestWithInvalidKey ()
		{
			// for an invalid key
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "fizzle"), "");
		}

		[Test]
		public void getDetailedInfoValueTestWithMissingKey ()
		{
			// for an invalid key (no corresponding value)
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "foo"), "");
		}

		[Test]
		public void getDetailedInfoValueTestWithValidKey ()
		{
			// for an valid key
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "a"), "b");
		}

		[Test]
		public void getDetailedInfoValueTestWithValidKetWithSpace ()
		{
			// for an valid key with a space after it
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "c"), "d");
		}

		[Test]
		public void getDetailedInfoValueTestWithValidKeyWithSpaces ()
		{
			// for an valid key with a space before and after it
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "e"), "f");
		}

		[Test]
		public void getDetailedInfoValueTestWithValidKeyWithManyValues ()
		{
			// for an valid key with multiple values after it, should return first value
			Assert.AreEqual (powerControl.getDetailedInfoValue (block, "bar"), "baz");
		}

		[Test]
		public void getPowerAsIntTestWithBlankString ()
		{
			// with no string data
			Assert.AreEqual (powerControl.getPowerAsInt (""), 0);
		}

		[Test]
		public void getPowerAsIntTestBadString ()
		{
			// with a bad string (no space)
			Assert.AreEqual (powerControl.getPowerAsInt ("100kWh"), 0);
		}

		[Test]
		public void getPowerAsIntTestBadUnit ()
		{
			// with a bad string (not power or power rate)
			Assert.AreEqual (powerControl.getPowerAsInt ("100 foo"), 0);
		}

		[Test]
		public void getPowerAsIntTestWithWatts ()
		{
			// with a wattage value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 W"), 100);
		}

		[Test]
		public void getPowerAsIntTestWithWattHours ()
		{
			// with a wattage hour value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 Wh"), 100);
		}

		[Test]
		public void getPowerAsIntTestWithKiloWatts ()
		{
			// with a kilowattage value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 kW"), 100000);
		}

		[Test]
		public void getPowerAsIntTestWithKiloWattHours ()
		{
			// with a kilowattage hour value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 kWh"), 100000);
		}

		[Test]
		public void getPowerAsIntTestWithMegaWatts ()
		{
			// with a megawattage value
			Assert.AreEqual (powerControl.getPowerAsInt ("100 MW"), 100000000);
		}

		[Test]
		public void getPowerAsIntTestWithMegaWattHours ()
		{
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
		public void getBatteriesTestWithNoBlocks ()
		{
			List<IMyTerminalBlock> blocks = new List<IMyTerminalBlock> ();
			powerControl.GridTerminalSystem = new GetBatteriesStubTerminalSystem (blocks);

			// with a no blocks provided
			Assert.AreEqual (powerControl.getBatteries (), blocks);

		}

		[Test]
		public void getBatteriesTestWithBlocks ()
		{

			List<IMyTerminalBlock> blocks = new List<IMyTerminalBlock> ();

			blocks.Add (new Common.StubTerminalBlock ());
			powerControl.GridTerminalSystem = new GetBatteriesStubTerminalSystem (blocks);

			// with a provided list of blocks
			Assert.AreEqual (powerControl.getBatteries (), blocks);
		
		}
	}
}