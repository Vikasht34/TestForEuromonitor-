using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataEntity.BaseCode
{
   public interface ITestDataModel: IDisposable
    {

        /// <summary>
        /// Returns the data model as a DbContext object
        /// </summary>
        /// <returns>The data model as a DbContext object</returns>
        TestDbEntities GetDataModelAsDbContext();

        /// <summary>
        /// Returns the connection string used in the data model.
        /// </summary>
        /// <remarks>
        /// ONLY USE if querying with ADO.NET
        /// </remarks>
        /// <returns>The connection string</returns>
        string GetConnectionStringForAdoQueries();

        /// <summary>
        /// Saves changes to the database
        /// </summary>
        /// <returns>The number of object written to the database</returns>
        /// <remarks>This method was overridden so that db entity exceptions are readable to the developer</remarks>
        int SaveChanges();

         DbSet<CustomerVarientCost> CustomerVarientCosts { get; set; }
        DbSet<DistanceVarientBaseCost> DistanceVarientBaseCosts { get; set; }
        DbSet<StairsVarientBaseCost> StairsVarientBaseCosts { get; set; }

    }
}
