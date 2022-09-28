namespace Shopping.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;


    public class SqlDB<T> where T : SqlDB<T>, new()
    {
        private static T _instance;
        private static object _lockHelper;

        static SqlDB()
        {
            SqlDB<T>._instance = default(T);
            SqlDB<T>._lockHelper = new object();
        }

        public static T GetInstance()
        {
            if (SqlDB<T>._instance == null)
            {
                lock (SqlDB<T>._lockHelper)
                {
                    if (SqlDB<T>._instance == null)
                    {
                        SqlDB<T>._instance = Activator.CreateInstance<T>();
                    }
                }
            }
            return SqlDB<T>._instance;
        }

        /// <summary>
        /// 存放表的字段
        /// </summary>
        List<string> Colums = new List<string>();

        /// <summary>
       
        /// <returns></returns>
        public int GetCount(string tableName, string condition)
        {
            if (condition == "") condition = "1=1";
            return (int)SqlHelper.ExecuteScalar("SELECT COUNT(*) FROM " + tableName + " WHERE " + condition);
        }

        /// <summary>
        /// 获取总数,判断是否存在
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Exist(string tableName, string condition)
        {
            if (condition == "") condition = "1=1";
            return (int)SqlHelper.ExecuteScalar("SELECT COUNT(*) FROM " + tableName + " WHERE " + condition) > 0 ? true : false;
        }

        /// <summary>
        /// 获取总数,判断是否存在
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Exist(string tableName, string field, string fieldValue)
        {
            bool result = false;

            if (field != "" && fieldValue != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("SELECT COUNT(*) FROM {0} Where {1}='{2}'", tableName, field, fieldValue);

                result = (int)SqlHelper.ExecuteScalar(strSql.ToString()) > 0 ? true : false;
            }
            return result;
        }



        public bool Exist(string tableName, string condition, SqlParameter[] parameters)
        {
            if (condition == "")
            {
                return true;
            }

            string strSql = "SELECT Count(*) From " + tableName + " where " + condition;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, parameters) > 0 ? true : false;
        }

        /// <summary>
        /// 获取总数,判断是否存在
        /// </summary>
        /// <param name="tableName">表名或视图名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Exist(string tableName, string field, int fieldValue)
        {
            bool result = false;

            if (field != "" && fieldValue.ToString() != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("SELECT COUNT(*) FROM {0} Where {1}={2}", tableName, field, fieldValue);

                result = (int)SqlHelper.ExecuteScalar(strSql.ToString()) > 0 ? true : false;
            }
            return result;
        }
        /// <summary>
        /// 根据条件从指定的表删除数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Delete(string tableName, string condition)
        {
            bool result = false;

            if (condition != "" && tableName != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("DELETE From {0} where {1}", tableName, condition);
            }
            return result;
        }

        /// <summary>
        /// 通过ID获取对象实体
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="Filed">字段</param>
        /// <param name="value">字段的值</param>
        /// <returns></returns>
        public SqlDataReader GetModel(string tableName, int Filed, int value)
        {
            return GetModel(tableName, Filed.ToString(), value.ToString());
        }

        /// <summary>
        /// 通过String获取对象实体
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="Filed">字段</param>
        /// <param name="value">字段的值</param>
        /// <returns></returns>
        public SqlDataReader GetModel(string tableName, string Filed, string value)
        {
            SqlParameter[] parameters = { 
                                        SqlHelper.MakeInParam("@value",SqlDbType.VarChar,200,value)
                                        };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT TOP 1 * FROM {0} WHERE {1}=@VALUE", tableName, Filed);

            return SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取数据列表[适用于多表]
        /// </summary>
        /// <param name="tableName">表名或者视图名</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public SqlDataReader GetList(string tableName, int pageSize, int pageNum, string condition, string orderby, string sorttype)
        {
            StringBuilder strSql = new StringBuilder();
            if (condition == "")
            {
                condition = "1=1";
            }
            if (pageNum <= 0)
            {
                pageNum = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 50;
            }

            strSql.Append("SELECT * FROM");
            strSql.Append("(");
            strSql.AppendFormat("SELECT ROW_NUMBER() OVER(ORDER BY {0} {1})  AS RowNum,{2} ", orderby, sorttype, " * ");
            strSql.AppendFormat("From {0}  Where {1}", tableName, condition);
            strSql.Append(")");
            strSql.AppendFormat("AS CustomersWithRowNum Where RowNum >(({0}-1)*{1}) And RowNum <=({0}*{1})", pageNum, pageSize);


            return SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 获取数据列表[适用于多表]
        /// </summary>
        /// <param name="tableName">表名或者视图名</param>
        /// <param name="fileds">字段</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public SqlDataReader GetList(string tableName, string fileds, int pageSize, int pageNum, string condition, string orderby, string sorttype)
        {
            StringBuilder strSql = new StringBuilder();
            if (condition == "")
            {
                condition = "1=1";
            }
            if (pageNum <= 0)
            {
                pageNum = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 50;
            }

            strSql.Append("SELECT * FROM");
            strSql.Append("(");
            strSql.AppendFormat("SELECT ROW_NUMBER() OVER(ORDER BY {0} {1})  AS RowNum,{2} ", orderby, sorttype, fileds);
            strSql.AppendFormat("From {0}  Where {1}", tableName, condition);
            strSql.Append(")");
            strSql.AppendFormat("AS CustomersWithRowNum Where RowNum >(({0}-1)*{1}) And RowNum <=({0}*{1})", pageNum, pageSize);


            return SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 根据存储过程返回分页结果
        /// </summary>
        /// <param name="tableName">表名或者视图名</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public SqlDataReader GetList2(string tableName, int pageSize, int pagenum, string condition, string orderby, string sorttype)
        {
            if (pageSize <= 0)
            {
                pageSize = 25;
            }
            if (pagenum <= 0)
            {
                pagenum = 1;
            }
            if (condition == "")
            {
                condition = "1=1";
            }
            SqlParameter[] parms = {
                SqlHelper.MakeInParam("@tableName", SqlDbType.NVarChar, 4000, tableName),
                SqlHelper.MakeInParam("@pagesize", SqlDbType.Int, 4, pageSize),
                SqlHelper.MakeInParam("@page", SqlDbType.Int, 4, pagenum),
                SqlHelper.MakeInParam("@condition", SqlDbType.NVarChar, 4000, condition),
                SqlHelper.MakeInParam("@orderby", SqlDbType.NVarChar, 100, orderby),
                SqlHelper.MakeInParam("@sorttype", SqlDbType.NVarChar, 5, sorttype)
            };
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SP_GetList", parms);
        }
        /// <summary>
        /// 根据存储过程返回分页结果
        /// </summary>
        /// <param name="tableName">表名或者视图名</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public SqlDataReader GetListByTempTable(string tableName, int pageSize, int pagenum, string condition, string primaryId, string orderby, string sorttype)
        {
            if (pageSize <= 0)
            {
                pageSize = 0x19;
            }
            if (pagenum <= 0)
            {
                pagenum = 1;
            }
            if (condition == "")
            {
                condition = "1=1";
            }
            SqlParameter[] commandParameters = new SqlParameter[] { 
                SqlHelper.MakeInParam("@tableName", SqlDbType.NVarChar, 50, tableName),
                SqlHelper.MakeInParam("@pagesize", SqlDbType.Int, 4, pageSize), 
                SqlHelper.MakeInParam("@page", SqlDbType.Int, 4, pagenum),
                SqlHelper.MakeInParam("@condition", SqlDbType.NVarChar, 0xfa0, condition), 
                SqlHelper.MakeInParam("@primaryId", SqlDbType.NVarChar, 100, primaryId),
                SqlHelper.MakeInParam("@orderby", SqlDbType.NVarChar, 100, orderby),
                SqlHelper.MakeInParam("@sorttype", SqlDbType.NVarChar, 5, sorttype) };
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, "EduSystemDATA_SP_GetListByTempTable", commandParameters);
        }
        /// <summary>
        /// 根据存储过程返回分页结果
        /// </summary>
        /// <param name="tableName">表名或者视图名</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="page">当前页码，1开始</param>
        /// <param name="condition">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="sorttype">排序类型（ASC，DESC）</param>
        /// <returns></returns>
        public SqlDataReader GetListByTempTable(SqlConnection conn, string tableName, int pageSize, int pagenum, string condition, string primaryId, string orderby, string sorttype)
        {
            if (pageSize <= 0)
            {
                pageSize = 0x19;
            }
            if (pagenum <= 0)
            {
                pagenum = 1;
            }
            if (condition == "")
            {
                condition = "1=1";
            }
            SqlParameter[] commandParameters = new SqlParameter[] { 
                SqlHelper.MakeInParam("@tableName", SqlDbType.NVarChar, 50, tableName), 
                SqlHelper.MakeInParam("@pagesize", SqlDbType.Int, 4, pageSize), 
                SqlHelper.MakeInParam("@page", SqlDbType.Int, 4, pagenum),
                SqlHelper.MakeInParam("@condition", SqlDbType.NVarChar, 0xfa0, condition), 
                SqlHelper.MakeInParam("@primaryId", SqlDbType.NVarChar, 100, primaryId), 
                SqlHelper.MakeInParam("@orderby", SqlDbType.NVarChar, 100, orderby),
                SqlHelper.MakeInParam("@sorttype", SqlDbType.NVarChar, 5, sorttype) };
            return SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "EduSystemDATA_SP_GetListByTempTable", commandParameters);
        }
        /// <summary>
        /// 更新数据集
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int UpdateDataTable(DataTable dataTable, string sql)
        {
            return SqlHelper.UpdateDataTable(dataTable, sql);
        }
        /// <summary>
        /// 获取表字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public SqlDataReader GetFields(string tableName)
        {
            SqlParameter[] parms = {
                SqlHelper.MakeInParam("@tableName", SqlDbType.NVarChar, 50, tableName),
            };
            return SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SP_GetFields", parms);
        }
        /// <summary>
        /// 获取DataTable数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            return SqlHelper.ExecuteDataset(sql).Tables[0];
        }
    }
}

