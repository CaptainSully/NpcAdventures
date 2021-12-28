using StardewModdingAPI;
using System;

namespace NpcAdventure
{
	public static class Log
	{
		public static void D(string str, bool debug)
		{
			if (debug) { NpcAdventureMod.Instance.Monitor.Log(str, LogLevel.Debug); }
		}
		public static void T(string str)
		{
			NpcAdventureMod.Instance.Monitor.Log(str, LogLevel.Trace);
		}
		public static void E(string str)
		{
			NpcAdventureMod.Instance.Monitor.Log(str, LogLevel.Alert);
		}
		public static void E(string str, Exception e)
		{
			string errorMessage = e == null ? string.Empty : $"\n{e.Message}\n{e.StackTrace}";
			NpcAdventureMod.Instance.Monitor.Log(str + errorMessage, LogLevel.Error);
		}
		public static void I(string str)
		{
			NpcAdventureMod.Instance.Monitor.Log(str, LogLevel.Info);
		}
		public static void A(string str)
		{
			NpcAdventureMod.Instance.Monitor.Log(str, LogLevel.Alert);
		}
		public static void W(string str)
		{
			NpcAdventureMod.Instance.Monitor.Log(str, LogLevel.Warn);
		}
	}
}