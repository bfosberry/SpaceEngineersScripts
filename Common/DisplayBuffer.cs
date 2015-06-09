using System;
using System.Collections.Generic;
using Sandbox.ModAPI.Ingame;

namespace SpaceEngineersScripts
{
	public class DisplayBuffer
	{
		IMyTextPanel panel;
		int MAX_CAPACITY = 20;
		Queue<String> queue;

		public DisplayBuffer (IMyTerminalBlock block)
		{
			if (block != null) {
				panel = (IMyTextPanel)block;
			}
			queue = new Queue<String> (MAX_CAPACITY);
		}

		public void Writeln (string message)
		{
			queue.Enqueue (message + "\n");
			flush ();
		}

		public void Clear ()
		{
			queue.Clear ();
			flush ();
		}

		void flush ()
		{
			if (panel != null) {
				panel.WritePublicText ("", false);
				Queue<String>.Enumerator e = queue.GetEnumerator ();
				while (e.MoveNext()) {
					panel.WritePublicText (e.Current, true);
				}
				panel.ShowTextureOnScreen ();   
				panel.ShowPublicTextOnScreen ();
			}
		}
	}
}