using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure;

namespace LinJiaYou.Models
{
    public class MyConfiguration:DbConfiguration
    {
        public MyConfiguration()
        {
            SetTransactionHandler(SqlProviderServices.ProviderInvariantName, () => new CommitFailureHandler());
            SetExecutionStrategy("System.Data.SqlClient",()=>new SqlAzureExecutionStrategy(1,TimeSpan.FromSeconds(30)) );
        }
    }
}