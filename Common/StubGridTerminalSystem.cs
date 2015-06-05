using System;
using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;

namespace SpaceEngineersScripts.Common
{
	public class StubGridTerminalSystem : IMyGridTerminalSystem
	{
		public void GetBlocks (List<IMyTerminalBlock> blocks)
		{
			throw new NotImplementedException ();
		}

		public void GetBlockGroups (List<IMyBlockGroup> blockGroups)
		{
			throw new NotImplementedException ();
		}

		public virtual void GetBlocksOfType<T> (List<IMyTerminalBlock> blocks, Func<IMyTerminalBlock, bool> collect)
		{
			throw new NotImplementedException ();
		}

		public void SearchBlocksOfName (string name, List<IMyTerminalBlock> blocks, Func<IMyTerminalBlock, bool> collect)
		{
			throw new NotImplementedException ();
		}

		public IMyTerminalBlock GetBlockWithName (string name)
		{
			throw new NotImplementedException ();
		}

		[Obsolete ("This will be removed in future update")]
		public List<IMyTerminalBlock> Blocks {
			get {
				throw new NotImplementedException ();
			}
		}

		[Obsolete ("This will be removed in future update")]
		public List<IMyBlockGroup> BlockGroups {
			get {
				throw new NotImplementedException ();
			}
		}
	}
}

