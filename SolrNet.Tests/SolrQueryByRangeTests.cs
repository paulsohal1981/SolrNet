﻿#region license
// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using MbUnit.Framework;

namespace SolrNet.Tests {
	[TestFixture]
	public class SolrQueryByRangeTests {
		public class TestDocument {}

		[Test]
		public void IntInclusive() {
			var q = new SolrQueryByRange<int>("id", 123, 456);
			Assert.AreEqual("id:[123 TO 456]", q.Query);
		}

		[Test]
		public void StringInclusive() {
			var q = new SolrQueryByRange<string>("id", "Arroz", "Zimbabwe");
			Assert.AreEqual("id:[Arroz TO Zimbabwe]", q.Query);
		}

		[Test]
		public void StringExclusive() {
			var q = new SolrQueryByRange<string>("id", "Arroz", "Zimbabwe", false);
			Assert.AreEqual("id:{Arroz TO Zimbabwe}", q.Query);
		}

        [Test]
        public void FloatInclusive() {
            var q = new SolrQueryByRange<float>("price", 123.45f, 234.56f);
            Assert.AreEqual("price:[123.45 TO 234.56]", q.Query);
        }

        [Test]
        public void DateTimeInclusive() {
            var q = new SolrQueryByRange<DateTime>("ts", new DateTime(2001, 1, 5), new DateTime(2002, 3, 4, 5, 6, 7));
            Assert.AreEqual("ts:[2001-01-05T00:00:00Z TO 2002-03-04T05:06:07Z]", q.Query);
        }
	}
}