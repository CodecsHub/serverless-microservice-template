using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ServerlessMicroservice.Infrastructure.Interfaces
{
    /// <summary>
    /// for Dapper Mocking and refactor the dapper connection string
    /// @url : https://mikhail.io/2016/02/unit-testing-dapper-repositories/
    /// </summary>
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
