using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.AreaTests
{
    [TestFixture]
    public class AreaTest
    {
        private AreaSource _areaSource;

        [SetUp]
        public void AreaTestSetUp()
        {
            _areaSource = new AreaSource();
        }

        [Test]
        public void GetAreaById_MustReturn_SingleValue_OrNull_IfNotFound()
        {
            var result = _areaSource.GetAreaById(2000).Result;
            var result2 = _areaSource.GetAreaById(1000).Result;

            Assert.IsNotNull(result);
            Assert.IsNull(result2);
        }

        [Test]
        public void GetAreaById_ThrowException_IfIdIsNegative()
        {
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => _areaSource.GetAreaById(-1));
        }
    }
}
