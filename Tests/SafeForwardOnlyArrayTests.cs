﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ITNight;
using Xunit;

namespace ITNight.Tests
{
	public class SafeForwardOnlyArrayTests: CronTests
	{
		protected override string ParseToString(string expression)
		{
			return SafeForwardOnlyArrayCron.Parse(expression).ToString();
		}

		protected override DateTime GetNext(string expression, DateTime value)
		{
			return SafeForwardOnlyArrayCron.Parse(expression).GetNext(value);
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
