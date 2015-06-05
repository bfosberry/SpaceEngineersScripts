using System;
using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceEngineersScripts.AdvancedPowerControl
{
	public class AdvancedPowerController
	{
		internal IMyGridTerminalSystem GridTerminalSystem = null;
		//------------------------------------------------------
		//----- Script Begins ----------------------------------
		//------------------------------------------------------
		/*
       *  Written and tested by     Stiggan and Malakeh in January 2015.
       *  Updated and adapted by Fozz in April 2015
       */
		internal string getDetailedInfoValue (IMyTerminalBlock block, string name)
		{
			string value = "";
			string[] lines = block.DetailedInfo.Split (new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
			for (int i = 0; i < lines.Length; i++) {
				string[] line = lines [i].Split (':');
				if (line.Length >= 2) {
					if (line [0].Trim().Equals (name)) {
						value = line [1].Trim();
						break;
					}
				}
			}
			return value;
		}

		internal int getPowerAsInt (string text)
		{ 
			if (String.IsNullOrWhiteSpace (text)) { 
				return 0; 
			} 

			string[] values = text.Split (' '); 
			if (values.Length == 0) {
				return 0;
			}

			float val;
			try {
			  val = float.Parse(values [0]);
			}
			catch (FormatException) {
				return 0;
			}

			string unit = values [1];

			float mult = 0;
			switch (unit.ToLower()) {
			case "w":
				mult = 1;
				break;
			case "wh":
				mult = 1;
				break;
			case "kw":
				mult = 1000;
				break;
			case "kwh":
				mult = 1000;
				break;
			case "mw":
				mult = 1000000;
				break;
			case "mwh":
				mult = 1000000;
				break;
			default:
				mult = 0;
				break;
			}

			return (int)(val * mult);
		}

		internal List<IMyTerminalBlock> getBatteries ()
		{ 
			List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();   
			GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock> (batteries); 
			return batteries;
		}

		public void Main ()
		{
			writeMessage ("Starting"); 
			dischargeBatteries ();  
			int availablePower = availableSolarPower () + availableBatteryPower ();
			writeMessage (availablePower + " power capacity is available!"); 

			List<IMyTerminalBlock> batteries1 = getHighestBatteries ();      
			for (int i = 0; i < batteries1.Count && currentReactorDrain () > 0; i++) {  
				IMyTerminalBlock battery = batteries1 [i];  
				battery.GetActionWithName ("Recharge").Apply (battery);  
			} 

			List<IMyTerminalBlock> batteries = getLowestBatteries ();  
			for (int i = 0; i < batteries.Count && availablePower > 0; i++) {
				IMyTerminalBlock battery = batteries [i];
				if (battery != null) {    
					availablePower -= handleBattery (battery, availablePower);
				} else {    
					writeMessage ("No batteries to charge");     
					return;
				}          
			}   
		}

		int handleBattery (IMyTerminalBlock battery, int availablePower)
		{
			int requiredCapacity = chargeRate (battery);     
			if (getCurrentOutput (battery) > 0) {     
				requiredCapacity += chargeRate (battery);     
			}     

			writeMessage ("Checking power capacity");     
			if (availablePower - requiredCapacity >= 0) {        
				writeMessage ("Charging another battery");         
				battery.GetActionWithName ("Recharge").Apply (battery);            
				return requiredCapacity;      
			} else {       
				writeMessage ("Insufficient power capacity to charge another battery:" + availablePower);        
				return availablePower;   
			}   
		}

		void dischargeBatteries ()
		{
			List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> (); 
			GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock> (batteries); 
			for (int i = 0; i < batteries.Count; i++) { 

				int storedPower = getPowerAsInt (getDetailedInfoValue (batteries [i], "Stored power"));
				int maxStoredPower = getPowerAsInt (getDetailedInfoValue (batteries [i], "Max Stored Power"));
				if (storedPower == maxStoredPower && isRecharging (batteries [i])) {
					batteries [i].GetActionWithName ("Recharge").Apply (batteries [i]); 
				} 
			} 
		}

		bool dischargeHighestBattery ()
		{ 
			writeMessage ("Reactor is draining, trying to discharge a charging battery");
			List<IMyTerminalBlock> batteries = getHighestBatteries ();
			if (batteries.Count > 0) {
				writeMessage ("Switching a Battery to discharge");

				return true;
			}
			return false;
		}

		List<IMyTerminalBlock> getNonFullBatteries ()
		{
			return getBatteries ().FindAll (b => !isFull (b)); 
		}

		List<IMyTerminalBlock> getLowestBatteries ()
		{ 
			List<IMyTerminalBlock> batteries = getNonFullBatteries ();
			batteries = batteries.FindAll (b => !isRecharging (b)); 
			batteries.Sort (
				delegate(IMyTerminalBlock b1, IMyTerminalBlock b2) {
				int p1 = getPowerAsInt (getDetailedInfoValue (b1, "Stored power")); 
				int p2 = getPowerAsInt (getDetailedInfoValue (b2, "Stored power")); 
				return p1 - p2; 
			}); 
			return batteries;
		}

		List<IMyTerminalBlock> getHighestBatteries ()
		{  
			List<IMyTerminalBlock> batteries = getNonFullBatteries (); 
			batteries = batteries.FindAll (b => isRecharging (b));  
			batteries.Sort (
				delegate(IMyTerminalBlock b1, IMyTerminalBlock b2) { 
				int p1 = getPowerAsInt (getDetailedInfoValue (b1, "Stored power"));  
				int p2 = getPowerAsInt (getDetailedInfoValue (b2, "Stored power"));  
				return p2 - p1;  
			});  
			return batteries; 
		}

		int currentReactorDrain ()
		{
			List<IMyTerminalBlock> reactors = new List<IMyTerminalBlock> (); 
			GridTerminalSystem.GetBlocksOfType<IMyReactor> (reactors); 
			int drain = 0; 
			for (int i = 0; i < reactors.Count; i++) { 
				if (healthyReactor (reactors [i]) && ((IMyFunctionalBlock)reactors [i]).Enabled) { 
					drain += getCurrentOutput (reactors [i]); 
				} 
			} 
			return drain;
		}

		int availableSolarPower ()
		{ 
			List<IMyTerminalBlock> solarPanels = new List<IMyTerminalBlock> ();  
			GridTerminalSystem.GetBlocksOfType<IMySolarPanel> (solarPanels);  
			int power = 0;  
			for (int i = 0; i < solarPanels.Count; i++) {  
				power += getAvailableCapacity (solarPanels [i]);  
			}  
			return power; 
		}

		int availableBatteryPower ()
		{  
			List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();   
			GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock> (batteries);   
			batteries = batteries.FindAll (b => !isRecharging (b));  
			int power = 0;   
			for (int i = 0; i < batteries.Count; i++) {   
				power += getAvailableCapacity (batteries [i]);   
			}   
			return power;  
		}

		int getCurrentBatteryChargeCost ()
		{   
			List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();    
			GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock> (batteries);    
			batteries = batteries.FindAll (b => !isRecharging (b)); 
			if (batteries.Count > 0) {
				return getCurrentOutput (batteries [0]);
			}
			return 0;
		}

		int getCurrentOutput (IMyTerminalBlock block)
		{ 
			if (!block.IsBeingHacked) { 
				return getPowerAsInt (getDetailedInfoValue (block, "Current Output")); 
			} 
			return 0; 
		}

		int getAvailableCapacity (IMyTerminalBlock block)
		{  
			if (!block.IsBeingHacked) {  
				int availablePower = getPowerAsInt (getDetailedInfoValue (block, "Stored power"));  
				int current = getCurrentOutput (block);  
				int max = getPowerAsInt (getDetailedInfoValue (block, "Max Output"));  
				if (availablePower > 0) {
					return max - current;
				} 
			}  
			return 0;  
		}

		int numChargeableBatteries ()
		{
			List<IMyTerminalBlock> batteries = new List<IMyTerminalBlock> ();    
			GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock> (batteries);  
			batteries = batteries.FindAll (b => !isRecharging (b));  
			batteries = batteries.FindAll (b => !isFull (b));  
			return batteries.Count; 
		}

		bool healthyReactor (IMyTerminalBlock b)
		{ 
			return isHealthy (b) && detailExist (b, "Current Output"); 
		}

		bool isHealthy (IMyTerminalBlock block)
		{ 
			return (block.IsFunctional && block.IsWorking); 
		}

		bool isRecharging (IMyTerminalBlock block)
		{ 
			return detailExist (block, "Fully recharged in"); 
		}

		bool isFull (IMyTerminalBlock block)
		{ 
			int stored = getPowerAsInt (getDetailedInfoValue (block, "Stored power"));   
			int max = getPowerAsInt (getDetailedInfoValue (block, "Max Stored Power"));  
			return max == stored;
		}

		int chargeRate (IMyTerminalBlock block)
		{ 
			return getPowerAsInt (getDetailedInfoValue (block, "Max Required Input"));   
		}

		bool detailExist (IMyTerminalBlock block, string name)
		{ 
			return !String.IsNullOrEmpty (getDetailedInfoValue (block, name)); 
		}

		void writeMessage (string message)
		{ 
			List<IMyTerminalBlock> work = new List<IMyTerminalBlock> (); 
			GridTerminalSystem.SearchBlocksOfName ("Power Debug LCD Panel", work); 
			if (work.Count > 0) {
				IMyTextPanel panel = (IMyTextPanel)work [0];  
				panel.WritePublicText (message, false); 
				panel.ShowTextureOnScreen ();   
				panel.ShowPublicTextOnScreen ();
			}
		}
		//------------------------------------------------------
		//----- Script Ends ------------------------------------
		//------------------------------------------------------
	}
}

