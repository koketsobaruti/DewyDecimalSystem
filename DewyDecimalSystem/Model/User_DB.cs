using DewyDecimalSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DewyDecimalSystem.Model
{
    public class User_DB
    {
        /// <summary>
        ///ADD A NEW USER TO THE TABLE
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user, string gameType)
        {
            using (var connection = new SqlConnection(DB_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("INSERT INTO TBL_USER(FIRST_NAME, SECOND_NAME, SCORE, GAME_TYPE)  VALUES (@FIRST_NAME, @SECOND_NAME,@SCORE, @GAME_TYPE)", connection);
                        
                        command.Parameters.AddWithValue("@FIRST_NAME", user.Name);
                        command.Parameters.AddWithValue("@SECOND_NAME", user.Surname);
                        command.Parameters.AddWithValue("@SCORE", user.Score);
                        command.Parameters.AddWithValue("@GAME_TYPE", gameType);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO CHECK IF THE USER EXISST IN THE TABLE 
        /// </summary>
        /// <returns></returns>
        public static bool FindUser(User user, string gameType)
        {
            bool found = false;
            using (var connection = new SqlConnection(DB_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT FIRST_NAME FROM TBL_USER WHERE (FIRST_NAME = @FIRST_NAME) AND (SECOND_NAME = @SECOND_NAME) AND (GAME_TYPE = @GAME_TYPE)", connection);

                        command.Parameters.AddWithValue("@FIRST_NAME", user.Name);
                        command.Parameters.AddWithValue("@SECOND_NAME", user.Surname);
                        command.Parameters.AddWithValue("@GAME_TYPE", gameType);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            found = true;
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }

                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
            return found;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO RETRIEVE VALUES FROM THE DATABASE
        /// </summary>
        /// <returns></returns>
        public static List<User> GetList(string gameType)
        {
            var list = new List<User>();
            var user = new User();
            using (var connection = new SqlConnection(DB_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT FIRST_NAME, SECOND_NAME, SCORE FROM TBL_USER WHERE (GAME_TYPE = @GAME_TYPE) ORDER BY SCORE DESC", connection);

                        command.Parameters.AddWithValue("@GAME_TYPE", gameType);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user = new User
                                {
                                    Name = reader["FIRST_NAME"].ToString(),
                                    Surname = reader["SECOND_NAME"].ToString(),
                                    Score = Int32.Parse(reader["SCORE"].ToString())
                                };

                                list.Add(user);
                            }
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
                return list;
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// UPDATE THE USER IF THE USER HAS BEEN FOUND
        /// </summary>
        /// <returns></returns>
        public static void UpdateUser(User user, string gameType)
        {
            using (var connection = new SqlConnection(DB_Connection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var updateCommand = new SqlCommand("UPDATE TBL_FIND SET SCORE = @SCORE WHERE (FIRST_NAME = @FIRST_NAME) " +
                            "AND (SECOND_NAME = @SECOND_NAME) " +
                            "AND (GAME_TYPE = @GAME_TYPE)", connection);

                        updateCommand.Parameters.AddWithValue("@FIRST_NAME", user.Name);
                        updateCommand.Parameters.AddWithValue("@SECOND_NAME", user.Surname);
                        updateCommand.Parameters.AddWithValue("@SCORE", user.Score);
                        updateCommand.Parameters.AddWithValue("@GAME_TYPE", gameType);
                        updateCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }

                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }

        }
        /*----------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------*/

    }
}