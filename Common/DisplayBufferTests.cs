using System;

namespace SpaceEngineersScripts.Common
{
	using NUnit.Framework;

	[TestFixture]
	public class DisplayBufferTests
	{
		DisplayBufferStubTextPanel panel;
		DisplayBuffer buffer;

		[SetUp] public void Before ()
		{
			panel = new DisplayBufferStubTextPanel ();
			buffer = new DisplayBuffer (panel);
		}

		class DisplayBufferStubTextPanel : StubTextPanel
		{

			public int ShowPublicCount, ShowTextureCount;
			public string PanelText;

			public DisplayBufferStubTextPanel ()
			{
				PanelText = "";
				ShowPublicCount = 0;
				ShowTextureCount = 0;
			}

			public override void ShowTextureOnScreen ()
			{
				ShowTextureCount++;
			}

			public override void ShowPublicTextOnScreen ()
			{
				ShowPublicCount++;
			}

			public override bool WritePublicText (string message, bool append)
			{
				if (append) {
					PanelText += message; 	
				} else {
					PanelText = message;
				}
				return true;
			}
		}

		[Test]
		public void WritelnTestWritesString ()
		{
			buffer.Writeln ("foo");
			buffer.Writeln ("bar");

			Assert.AreEqual (panel.PanelText, "foo\nbar\n");
		}

		[Test]
		public void WritelnTestShowsPublicTwice ()
		{
			buffer.Writeln ("foo");
			buffer.Writeln ("bar");

			Assert.AreEqual (panel.ShowPublicCount, 2);
		}

		[Test]
		public void WritelnTestShowsTextureTwice ()
		{
			buffer.Writeln ("foo");
			buffer.Writeln ("bar");

			Assert.AreEqual (panel.ShowTextureCount, 2);
		}

		[Test]
		public void ClearTestWipesPanelText ()
		{
			buffer.Writeln ("bar");
			buffer.Clear ();

			Assert.AreEqual (panel.PanelText, "");
		}

		[Test]
		public void ClearTestWShowsPublicTwice ()
		{
			buffer.Writeln ("bar");
			buffer.Clear ();

			Assert.AreEqual (panel.ShowPublicCount, 2);
		}

		[Test]
		public void ClearTesttShowsTextureTwice ()
		{
			buffer.Writeln ("bar");
			buffer.Clear ();

			Assert.AreEqual (panel.ShowTextureCount, 2);
		}
	}
}
