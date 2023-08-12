﻿using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Helpers;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;
using System.Data;

namespace ExpenseTrackerAPI.Services
{
   
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ILogger<ExpenseRepository> _logger;
        private readonly IDataConnect _connect;

        public ExpenseRepository(ILogger<ExpenseRepository> logger, IDataConnect connect)
        {
            _logger = logger;
            _connect = connect;
        }


        public async Task<BaseResponse> AddCategory(AddCategoryRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = StatusCode.ERROR_CODE,
                StatusDescription = StatusCode.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Category(CategoryName) VALUES(@categoryName)";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@categoryName";
                param.Direction = ParameterDirection.Input;
                param.Value = request.CategoryName;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = StatusCode.SUCCESS_CODE;
                    response.StatusDescription = StatusCode.SUCCESS_MSG;
                }
               
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> AddBudget(AddBudgetsRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = StatusCode.ERROR_CODE,
                StatusDescription = StatusCode.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Budgets(UserId,Salary,SalaryMonth,CategoryId,SalaryPercentage,Amount) VALUES(@UserId,@Salary,@SalaryMonth,@CategoryId,@SalaryPercentage,@Amount)";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "@Salary";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Salary;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@SalaryMonth";
                param.Direction = ParameterDirection.Input;
                param.Value = request.SalaryMonth;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.Int32;
                param.ParameterName = "@CategoryId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.CategoryId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@SalaryPercentage";
                param.Direction = ParameterDirection.Input;
                param.Value = request.SalaryPercentage;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "@Amount";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Amount;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = StatusCode.SUCCESS_CODE;
                    response.StatusDescription = StatusCode.SUCCESS_MSG;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> AddExpenses(AddExpensesRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = StatusCode.ERROR_CODE,
                StatusDescription = StatusCode.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Expenses(UserId,Items,CategoryId,Amount) VALUES(@UserId,@Items,@CategoryId,@Amount)";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@Items";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Items;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.Int32;
                param.ParameterName = "@CategoryId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.CategoryId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.Decimal;
                param.ParameterName = "@Amount";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Amount;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = StatusCode.SUCCESS_CODE;
                    response.StatusDescription = StatusCode.SUCCESS_MSG;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> RegisterUser(RegisterUserRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = StatusCode.ERROR_CODE,
                StatusDescription = StatusCode.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Users(UserId,FirstName,Surname,Email,Password) VALUES(@UserId,@FirstName,@Surname,@Email,@Password)";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@FirstName";
                param.Direction = ParameterDirection.Input;
                param.Value = request.FirstName;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@Surname";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Surname;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@Email";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Email;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@Password";
                param.Direction = ParameterDirection.Input;
                param.Value = HelpingMethods.Base64Encode(request.Password);
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = StatusCode.SUCCESS_CODE;
                    response.StatusDescription = StatusCode.SUCCESS_MSG;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<UserDetailsResp> AuthenticateUser(LoginRq request)
        {
            UserDetailsResp response = null;
            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"SELECT * FROM Users WHERE Email = @Email";


                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@Email";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Email;
                command.Parameters.Add(param);


                command.CommandTimeout = 80;

                using IDataReader rs = Task.FromResult(command.ExecuteReader(CommandBehavior.CloseConnection)).Result;
                if (rs != null && rs.Read())
                {
                    response = new UserDetailsResp()
                    {
                        Email = rs["Email"].ToString().Trim(),
                        FirstName = rs["FirstName"].ToString().Trim(),
                        Surname = rs["Surname"].ToString().Trim(),
                        Password = rs["Password"].ToString().Trim(),
                        UserId = rs["Id"].ToString().Trim()
                    };
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error >>>>>>>>>> {ex.Message}");
            }

            return response;
        }
    }
}