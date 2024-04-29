using System.Diagnostics;

namespace maui_view_performance;

static class Timing
{
	static readonly Dictionary<string, Stopwatch> Watches = new();

	public static void Start(string name)
	{
		if (!Watches.TryGetValue(name, out var watch))
		{
			Watches.Add(name, watch = new Stopwatch());
		}

		watch.Restart();
	}

	public static void Stop(string name)
	{
		if (Watches.TryGetValue(name, out var watch))
		{
			watch.Stop();
#if WINDOWS && DEBUG
			Debug.WriteLine($"{name} took {watch.ElapsedMilliseconds}ms");
#elif WINDOWS && TRACE
			Trace.WriteLine($"{name} took {watch.ElapsedMilliseconds}ms");
#else
			Console.WriteLine($"{name} took {watch.ElapsedMilliseconds}ms");
#endif
		}
	}
}
