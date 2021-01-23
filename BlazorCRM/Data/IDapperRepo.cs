using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRM.Data
{
	public interface IDapperRepo
	{
		Task<List<T>> ListOneOne<T, TP>(string sqlQuery, TP parameters, string connectionString);
		Task<List<T>> ListOneOne<T, T1, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T> map, string split);
		Task<List<T>> ListOneOne<T, T1, T2, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T2, T> map, string split);
		Task<List<T>> ListOneMany<T, T1, T2, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T2, T> map, string split);
		Task<List<T>> ListOneMany<T, T1, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T> map, string split);
		Task<T> SingleOneOne<T, TP>(string sqlQuery, TP parameters, string connectionString);
		Task<T> SingleOneMany<T, T1, T2, TP>(string sqlQuery, TP parameters, string connectionString, Func<T, T1, T2, T> map, string? split);
		Task<int> SaveData<T>(string sqlQuery, T parameters, string connectionString);
	}
}