using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;

namespace TI.Repository.UnitTests
{
    [TestFixture]
    public class RepositoryInterfaceTests
    {
        
    }
    [TestFixture]
    public class RepositoryStorageTests
    {

    }

    [TestFixture]
    public class RepositoryTests
    {

        
        [Test]
        public void IsDisposed_ObjectIsNotDisposed_ReturnFalse()
        {
            //ARRANGE
            Mock<Repository<int>> moq = new Mock<Repository<int>>();

            //ACT
            var result = moq.Object.IsDisposed;

            //ASSERT
            Assert.IsFalse(result);
        }
    }
}
