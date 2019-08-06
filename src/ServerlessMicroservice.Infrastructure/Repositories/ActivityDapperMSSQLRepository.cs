﻿using Dapper;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Repositories
{
    public class ActivityDapperMSSQLRepository : IActivityDapperMSSQLRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ActivityDapperMSSQLRepository()
        {
            // _connectionString = "Server=DESKTOP-85SV1TI\\SQLEXPRESS;Database=RESTfulSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _connectionString = "Server=FABAYON;Database=TitleMicroservice0000TemplateDatabase;Trusted_Connection=True;";

        }
        public Task DeleteData<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllData<T>(T model, string sql)
        {
            //using (IDbConnection connectionString = new SqlConnection(_connectionString))
            //{
            //    var output = connectionString.Query<T>(sql, new DynamicParameters());
            //    return output.ToList();
            //}
            throw new NotImplementedException();
        }

        public Task<T> GetDataBy<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }

        public Task InsertData<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }

        public Task UpdateData<T>(T model, string sql)
        {
            throw new NotImplementedException();
        }
    }
}
