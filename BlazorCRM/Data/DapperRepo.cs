using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace BlazorCRM.Data
{
	public class DapperRepo : IDapperRepo
	{
		public async Task<List<T>> ListOneOne<T, TP>(string sqlQuery, TP parameters, string connectionString)
		{
			await using var connection = new SqliteConnection(connectionString);
			var result = await connection.QueryAsync<T>(sql: sqlQuery, param: parameters);
			return result.ToList();
		}

		public async Task<List<T>> ListOneOne<T, T1, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T> map, string split)
		{
			await using var connection = new SqliteConnection(connectionString);
			var result = await connection.QueryAsync<T, T1, T>(sql: sqlQuery, param: parameters, map: map, splitOn: split);
			return result.ToList();
		}

		public async Task<List<T>> ListOneOne<T, T1, T2, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T2, T> map, string split)
		{
			await using var connection = new SqliteConnection(connectionString);
			var result = await connection.QueryAsync<T, T1, T2, T>(sql: sqlQuery, param: parameters, map: map, splitOn: split);
			return result.ToList();
		}
		/// <summary>
		/// To Make a query with a collection is inside an entity. 
		/// </summary>
		public async Task<List<T>> ListOneMany<T, T1, T2, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T2, T> map, string? split)
		{
			await using var connection = new SqliteConnection(connectionString);
			var dictionary = new Dictionary<int, T>();
			var result = await connection.QueryAsync<T, T1, T2, T>(sql: sqlQuery, map: map, parameters, splitOn: split);
			return result.Distinct().ToList();
		}
		public async Task<List<T>> ListOneMany<T, T1, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T> map, string? split)
		{
			await using var connection = new SqliteConnection(connectionString);
			var dictionary = new Dictionary<int, T>();
			var result = await connection.QueryAsync<T, T1, T>(sql: sqlQuery, map: map, parameters, splitOn: split);
			return result.Distinct().ToList();
		}
		public async Task<T> SingleOneOne<T, TP>(string sqlQuery, TP parameters, string connectionString)
		{
			await using var connection = new SqliteConnection(connectionString);
			var result = await connection.QueryFirstOrDefaultAsync<T>(sql: sqlQuery, param: parameters);
			return result;
		}

		public async Task<int> SaveData<T>(string sqlQuery, T parameters, string connectionString)
		{
			await using var connection = new SqliteConnection(connectionString);
			var result = await connection.ExecuteAsync(sql: sqlQuery, param: parameters);
			return result;
		}
	}
}