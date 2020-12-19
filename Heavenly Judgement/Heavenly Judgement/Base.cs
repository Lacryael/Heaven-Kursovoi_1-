using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Heavenly_Judgement
{
    class Base
    {
        private static string connString = @"Data Source = DESKTOP-1PLCADN\PANOPHOBIA; Initial Catalog = Heaven; Integrated Security = True";

        public static DataTable Query(string query)
        {
            SqlConnection connect = new SqlConnection(connString);
            DataTable result = new DataTable();
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(@"get dateformat dmy " + query, connect);
                SqlCommand myCommand = new SqlCommand(query.ToString(), connect);
                SqlDataReader reader = command.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connect.State != ConnectionState.Closed)
                    connect.Close();
            }
            return result;
        }

        public int GetPersonalData(string query, string data)
        {
            int temp = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;

                                if (data.ToString() == (string)reader[i])
                                {
                                    temp = 1;
                                }
                                else
                                {
                                    temp = 0;
                                }
                                i++;
                            }
                        }
                    }
                    connection.Close();
                    return temp;
                }
                catch (Exception e)
                {
                    string Exc = String.Format("Connection Error \n more info:\n {0}", e.ToString());
                    MessageBox.Show(Exc);
                    return temp;
                }
            }
        }

        public int GetId(string query, string data)
        {
            int temp = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;

                                if (Convert.ToInt32(data.ToString()) == (int)reader[i])
                                {
                                    temp = 1;
                                }
                                else
                                {
                                    temp = 0;
                                }
                                i++;
                            }
                        }
                    }
                    connection.Close();
                    return temp;
                }
                catch (Exception e)
                {
                    string Exc = String.Format("Connection Error \n more info:\n {0}", e.ToString());
                    MessageBox.Show(Exc);
                    return temp;
                }
            }
        }
        public string GetFio(string query)
        {
            string temp = "0";
            using (SqlConnection connection = new SqlConnection(connString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(query);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temp = reader[0].ToString();
                        }
                    }
                }
                connection.Close();
                return temp;
            }
        }


        public static void AddSoul (string fio, string gender, object dater, object dates, string smert)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Soul(status, fio, gender, dater, dates, smert)  VALUES(@status, @fio, @gender, @dater, @dates, @smert)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("status", 1));
                        command.Parameters.Add(new SqlParameter("fio", fio));
                        command.Parameters.Add(new SqlParameter("gender", gender));
                        command.Parameters.Add(new SqlParameter("dater", dater));
                        command.Parameters.Add(new SqlParameter("dates", dates));
                        command.Parameters.Add(new SqlParameter("smert", smert));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }
        public static void ChtecSoul(string id, string zaslugi, string grehi)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Soul SET status=@status, zaslugi=@zaslugi, grehi=@grehi WHERE id=@id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", Convert.ToInt32(id)));
                        command.Parameters.Add(new SqlParameter("status", 2));
                        command.Parameters.Add(new SqlParameter("zaslugi", zaslugi));
                        command.Parameters.Add(new SqlParameter("grehi", grehi));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

        public static void SudSoul(string id, int status, string mesto)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Soul SET status=@status, mesto=@mesto WHERE id=@id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", Convert.ToInt32(id)));
                        command.Parameters.Add(new SqlParameter("status", status));
                        command.Parameters.Add(new SqlParameter("mesto", mesto));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

        public static void PointPluse(string login)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Sotrud SET point=point+1 WHERE login=@login", connection))
                    {
                        command.Parameters.Add(new SqlParameter("login", login));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

        public static void Delete(string login)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Sotrud WHERE login = @login", connection))
                    {
                        command.Parameters.Add(new SqlParameter("login", login));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

        public static void Ochered(int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("Select ochered FROM Soul WHERE id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("ochered", id));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }
        public static void OcheredPluse(int ochered)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Soul SET status = status + 1 WHERE id = @id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", ochered));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }
        public static void AddUser(int addid2, string doljn2, int point2, string loginUser, string passUser)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Sotrud(id, doljn, point, login, pass)  VALUES(@id, @doljn, @point, @login, @pass)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", addid2));
                        command.Parameters.Add(new SqlParameter("doljn", doljn2));
                        command.Parameters.Add(new SqlParameter("point", point2));
                        command.Parameters.Add(new SqlParameter("login", loginUser));
                        command.Parameters.Add(new SqlParameter("pass", passUser));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

        public static void ChangeSoul(int id, int status, string fio, string gender, string smert, string zaslugi, string grehi, string mesto)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Soul SET status=@status, fio=@fio, gender=@gender, smert=@smert, zaslugi=@zaslugi, grehi=@grehi, mesto=@mesto WHERE id=@id", connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", id));
                        command.Parameters.Add(new SqlParameter("status", status));
                        command.Parameters.Add(new SqlParameter("fio", fio));
                        command.Parameters.Add(new SqlParameter("gender", gender));
                        command.Parameters.Add(new SqlParameter("smert", smert));
                        command.Parameters.Add(new SqlParameter("zaslugi", zaslugi));
                        command.Parameters.Add(new SqlParameter("grehi", grehi));
                        command.Parameters.Add(new SqlParameter("mesto", mesto));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка. Данные не изменены.");
                }
                connection.Close();
            }
        }

    }
}
