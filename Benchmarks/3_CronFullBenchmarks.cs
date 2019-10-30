﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;

namespace ITNight.Benchmarks
{
	//[DryJob(RuntimeMoniker.NetCoreApp30)]
	//[DisassemblyDiagnoser(true, false, true, true, 4, false)]
	//[InliningDiagnoser(false, new[] { "ITNight" })]

	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[MemoryDiagnoser]
	[RankColumn(NumeralSystem.Arabic)]
	[SuppressMessage("Naming", "ENYIM0001:File name does not match the type name", Justification = "Demo")]
	public class CronFullBenchmarks
	{
		private readonly DateTime Input = new DateTime(2012, 11, 30, 22, 59, 0);

#if !OPT_ONLY

		[Benchmark(Baseline = true)]
		[ArgumentsSource(nameof(Args))]
		public object Naive(string value) => NaiveCron.Parse(value).GetNext(Input);

		[Benchmark]
		[ArgumentsSource(nameof(Args))]
		public object NaiveSpan(string value) => SpanCron.Parse(value).GetNext(Input);

		[Benchmark]
		[ArgumentsSource(nameof(Args))]
		public object Array(string value) => SpanArrayCron.Parse(value).GetNext(Input);

		[Benchmark]
		[ArgumentsSource(nameof(Args))]
		public object UlongBaseline(string value) => SpanUlongCronBaseline.Parse(value).GetNext(Input);

		[Benchmark]
		[ArgumentsSource(nameof(Args))]
		public object UlongAdv(string value) => SpanUlongCronAdv.Parse(value).GetNext(Input);

#endif
#if OPT_ONLY

		[Benchmark]
		[ArgumentsSource(nameof(Args))]
		public object OptArray(string value) => ITNight.Optimized.SpanArrayCronAdv.Parse(value).GetNext(Input);

		[Benchmark]
		[ArgumentsSource(nameof(Args))]
		public object OptUlongAdv(string value) => ITNight.Optimized.SpanUlongCronAdv.Parse(value).GetNext(Input);

#endif

		public IEnumerable<string> Args()
		{
			yield return "* * * * *";
			yield return "1-3 4/4 */3 1,2,4-6,3/3,1-10/2 *";
		}
	}
}

#region [ License information          ]

/*

Copyright (c) Attila Kiskó, enyim.com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*/

#endregion
