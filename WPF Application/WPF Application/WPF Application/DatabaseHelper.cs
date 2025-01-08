using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WPF_Application
{
	public class DatabaseHelper
	{
		private string connectionString = "server=localhost;database=StudentProgressTracker;user=root;password=332211Asdfghjkl;";

		public List<Student> GetStudents(string grade = null, string subject = null)
		{
			List<Student> students = new List<Student>();
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					string query = "SELECT * FROM Students";
					if (!string.IsNullOrEmpty(grade) || !string.IsNullOrEmpty(subject))
					{
						query += " WHERE";
						if (!string.IsNullOrEmpty(grade))
							query += " Grade = @Grade";
						if (!string.IsNullOrEmpty(subject))
							query += " AND Subject = @Subject";
					}

					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						if (!string.IsNullOrEmpty(grade))
							cmd.Parameters.AddWithValue("@Grade", grade);
						if (!string.IsNullOrEmpty(subject))
							cmd.Parameters.AddWithValue("@Subject", subject);

						using (MySqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								students.Add(new Student
								{
									Id = reader.GetInt32("Id"),
									Name = reader.GetString("Name"),
									Grade = reader.GetString("Grade"),
									Subject = reader.GetString("Subject"),
									Marks = reader.GetInt32("Marks"),
									AttendancePercentile = reader.GetDecimal("AttendancePercentile")
								});
							}
						}
					}
				}
			}
			catch (MySqlException ex)
			{
				// Log the exception (you can use a logging framework or simply write to console)
				Console.WriteLine($"MySQL Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				// Log the exception
				Console.WriteLine($"General Error: {ex.Message}");
			}
			return students;
		}

		public List<string> GetUniqueSubjects()
		{
			List<string> subjects = new List<string>();
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					string query = "SELECT DISTINCT Subject FROM Students";
					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						using (MySqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								subjects.Add(reader.GetString("Subject"));
							}
						}
					}
				}
			}
			catch (MySqlException ex)
			{
				Console.WriteLine($"MySQL Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"General Error: {ex.Message}");
			}
			return subjects;
		}

		public void AddStudent(Student student)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					string query = "INSERT INTO Students (Name, Grade, Subject, Marks, AttendancePercentile) VALUES (@Name, @Grade, @Subject, @Marks, @AttendancePercentile)";
					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Name", student.Name);
						cmd.Parameters.AddWithValue("@Grade", student.Grade);
						cmd.Parameters.AddWithValue("@Subject", student.Subject);
						cmd.Parameters.AddWithValue("@Marks", student.Marks);
						cmd.Parameters.AddWithValue("@AttendancePercentile", student.AttendancePercentile);
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (MySqlException ex)
			{
				Console.WriteLine($"MySQL Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"General Error: {ex.Message}");
			}
		}

		public void UpdateStudent(Student student)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					string query = "UPDATE Students SET Name = @Name, Grade = @Grade, Subject = @Subject, Marks = @Marks, AttendancePercentile = @AttendancePercentile WHERE Id = @Id";
					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Id", student.Id);
						cmd.Parameters.AddWithValue("@Name", student.Name);
						cmd.Parameters.AddWithValue("@Grade", student.Grade);
						cmd.Parameters.AddWithValue("@Subject", student.Subject);
						cmd.Parameters.AddWithValue("@Marks", student.Marks);
						cmd.Parameters.AddWithValue("@AttendancePercentile", student.AttendancePercentile);
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (MySqlException ex)
			{
				Console.WriteLine($"MySQL Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"General Error: {ex.Message}");
			}
		}

		public void DeleteStudent(int id)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					string query = "DELETE FROM Students WHERE Id = @Id";
					using (MySqlCommand cmd = new MySqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Id", id);
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (MySqlException ex)
			{
				Console.WriteLine($"MySQL Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"General Error: {ex.Message}");
			}
		}
	}
}