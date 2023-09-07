using ExpenseTrackerAPI.Constants;
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
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Category(UserId,CategoryName) VALUES(@UserId,@categoryName)";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
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
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = ErrorCodes.SUCCESS_MSG;
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
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
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
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = ErrorCodes.SUCCESS_MSG;
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
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Expenses(UserId,Items,CategoryId,Amount,CreateDate) VALUES(@UserId,@Items,@CategoryId,@Amount,@CreateDate)";

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

                param = command.CreateParameter();
                param.DbType = DbType.DateTime;
                param.ParameterName = "@CreateDate";
                param.Direction = ParameterDirection.Input;
                param.Value = request.CreatedDate;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = ErrorCodes.SUCCESS_MSG;
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
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"INSERT INTO Users(Id,FirstName,Surname,Email,Password) VALUES(@UserId,@FirstName,@Surname,@Email,@Password)";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = Guid.NewGuid().ToString("N");
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
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = "Registration is successful. Please login to start your session";
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

        public async Task<List<ListCategoryResp>> ListCategory(string UserId)
        {
            var listResp = new List<ListCategoryResp>();
            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"SELECT * FROM Category WHERE UserId = @UserId";


                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = UserId;
                command.Parameters.Add(param);


                command.CommandTimeout = 80;

                using IDataReader rs = Task.FromResult(command.ExecuteReader(CommandBehavior.CloseConnection)).Result;
                while (rs != null && rs.Read())
                {
                    var category = new ListCategoryResp()
                    {
                        Id = int.Parse(rs["Id"].ToString().Trim()),
                        UserId = rs["UserId"].ToString().Trim(),
                        CategoryName = rs["CategoryName"].ToString().Trim(),
                        CreateDate = Convert.ToDateTime(rs["CreateDate"].ToString().Trim())
                    };

                    listResp.Add(category);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error >>>>>>>>>> {ex.Message}");
            }

            return listResp;
        }
       
        public async Task<List<ListBudgetResp>> ListBudget(string UserId)
        {
            var listResp = new List<ListBudgetResp>();
            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"SELECT C.CategoryName, B.* FROM Category C, Budgets B WHERE C.Id = B.CategoryId AND B.UserId = @UserId";


                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = UserId;
                command.Parameters.Add(param);


                command.CommandTimeout = 80;

                using IDataReader rs = Task.FromResult(command.ExecuteReader(CommandBehavior.CloseConnection)).Result;
                while (rs != null && rs.Read())
                {
                    var budget = new ListBudgetResp()
                    {
                        Id = int.Parse(rs["Id"].ToString().Trim()),
                        UserId = rs["UserId"].ToString().Trim(),
                        Amount = Convert.ToDecimal(rs["Amount"].ToString().Trim()),
                        CategoryId = int.Parse(rs["CategoryId"].ToString().Trim()),
                        Salary = Convert.ToDecimal(rs["Salary"].ToString().Trim()),
                        SalaryMonth = rs["SalaryMonth"].ToString().Trim(),
                        SalaryPercentage = rs["SalaryPercentage"].ToString().Trim(),
                        CategoryName = rs["CategoryName"].ToString().Trim(),
                        CreateDate = Convert.ToDateTime(rs["CreatedDate"].ToString().Trim())
                    };

                    listResp.Add(budget);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error >>>>>>>>>> {ex.Message}");
            }

            return listResp;
        }

        public async Task<List<ListExpensesResp>> ListExpenses(string UserId)
        {
            var listResp = new List<ListExpensesResp>();
            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"SELECT * FROM Expenses WHERE UserId = @UserId";


                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = UserId;
                command.Parameters.Add(param);


                command.CommandTimeout = 80;

                using IDataReader rs = Task.FromResult(command.ExecuteReader(CommandBehavior.CloseConnection)).Result;
                while (rs != null && rs.Read())
                {
                    var expense = new ListExpensesResp()
                    {
                        Id = int.Parse(rs["Id"].ToString().Trim()),
                        UserId = rs["UserId"].ToString().Trim(),
                        Amount = Convert.ToDecimal(rs["Amount"].ToString().Trim()),
                        CategoryId = int.Parse(rs["CategoryId"].ToString().Trim()),
                        Items = rs["Items"].ToString().Trim(),
                        CreatedDate = Convert.ToDateTime(rs["CreateDate"].ToString().Trim())
                    };

                    listResp.Add(expense);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error >>>>>>>>>> {ex.Message}");
            }

            return listResp;
        }

        public async Task<BaseResponse> DeleteCategory(DeleteRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"DELETE FROM Category WHERE Id = @id AND UserId = @userId";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@id";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Id;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = ErrorCodes.SUCCESS_MSG;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> DeleteBudget(DeleteRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"DELETE FROM Budgets WHERE Id = @id AND UserId = @userId";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@id";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Id;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = ErrorCodes.SUCCESS_MSG;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> DeleteExpenses(DeleteRq request)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };

            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"DELETE FROM Expenses WHERE Id = @id AND UserId = @userId";

                var param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@UserId";
                param.Direction = ParameterDirection.Input;
                param.Value = request.UserId;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = DbType.String;
                param.ParameterName = "@id";
                param.Direction = ParameterDirection.Input;
                param.Value = request.Id;
                command.Parameters.Add(param);

                command.CommandTimeout = 80;

                var res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    response.Success = true;
                    response.StatusCode = ErrorCodes.SUCCESS_CODE;
                    response.StatusDescription = ErrorCodes.SUCCESS_MSG;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception >>> {ex.Message}");
            }

            return response;
        }

        public async Task<Statistics> Statistics()
        {
            var stats = new Statistics();
            IDbCommand command;
            IDbConnection conn = _connect.GetSQLDataConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                command = conn.CreateCommand();

                command.CommandText = @"SELECT(SELECT COUNT(*) FROM Category) AS CategoryCount, ( SELECT COUNT(*) FROM Budgets) AS BudgetCount";

                command.CommandTimeout = 80;

                using IDataReader rs = Task.FromResult(command.ExecuteReader(CommandBehavior.CloseConnection)).Result;
                if (rs != null && rs.Read())
                {
                    stats.Budget = int.Parse(rs["BudgetCount"].ToString().Trim());
                    stats.Category = int.Parse(rs["CategoryCount"].ToString().Trim());
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error >>>>>>>>>> {ex.Message}");
            }

            return stats;
        }


        

    }
}
