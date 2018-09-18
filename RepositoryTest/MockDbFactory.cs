using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryTest
{
    public class MockDbSetFactory
    {
        /// <summary>
        /// Creates a Mock of a DbSet object by using the provided set of objects
        /// </summary>
        /// <remarks>
        /// This is to support unit testing repositories.
        /// </remarks>
        /// <typeparam name="T">The type of DbSet to Create</typeparam>
        /// <param name="mockObjects">The objects to fill the DbSet with</param>
        /// <returns>A DbSet that should be able to be used for querying data</returns>
        public static Mock<DbSet<T>> CreateMockDbSetWithObjects<T>(IEnumerable<T> mockObjects) where T : class, new()
        {
            Mock<DbSet<T>> mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.Setup(m => m.Local).Returns(new ObservableCollection<T>(mockObjects));

            IQueryable<T> mockComponentsAsQueryable = mockObjects.AsQueryable();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(mockComponentsAsQueryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(mockComponentsAsQueryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(mockComponentsAsQueryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                .Returns(mockComponentsAsQueryable.GetEnumerator());

            mockDbSet.Setup(m => m.Add(It.IsAny<T>())).Returns(new T());
            return mockDbSet;
        }

        /// <summary>
        /// Creates a Mock of a DbSet object by using the provided set of objects
        /// This method includes mocking capabilities for adding objects to a DB set.
        /// </summary>
        /// <remarks>
        /// This is to support unit testing repositories.
        /// </remarks>
        /// <typeparam name="T">The type of DbSet to Create</typeparam>
        /// <param name="mockObjects">The objects to fill the DbSet with</param>
        /// <returns>A DbSet that should be able to be used for querying data</returns>
        public static Mock<DbSet<T>> CreateMockDbSetWithObjectsWithAddCapability<T>(IList<T> mockObjects) where T : class, new()
        {
            Mock<DbSet<T>> mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.Setup(m => m.Local).Returns(new ObservableCollection<T>(mockObjects));

            IQueryable<T> mockComponentsAsQueryable = mockObjects.AsQueryable();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(mockComponentsAsQueryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(mockComponentsAsQueryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(mockComponentsAsQueryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                .Returns(mockComponentsAsQueryable.GetEnumerator());
            mockDbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => mockObjects.Add(s));
            return mockDbSet;
        }
    }
}
