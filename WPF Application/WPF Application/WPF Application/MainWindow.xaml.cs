using System.Windows;
using System.Xml.Linq;
using WPF_Application;

namespace WPF_Application
{
	public partial class MainWindow : Window
	{
		private DatabaseHelper dbHelper = new DatabaseHelper();
		private List<Student> students;
		private Student selectedStudent;

		public MainWindow()
		{
			InitializeComponent();
			LoadGrades();
			LoadSubjects();
			LoadStudents();
		}

		private void LoadGrades()
		{
			// Load predefined grades
			var grades = new List<string> { "A", "A+", "B", "B+", "C", "D", "F" };
			GradeComboBox.ItemsSource = grades;
		}

		private void LoadSubjects()
		{
			// Load unique subjects from the database
			var subjects = dbHelper.GetUniqueSubjects();
			SubjectComboBox.ItemsSource = subjects;
		}

		private void LoadStudents(string grade = null, string subject = null)
		{
			students = dbHelper.GetStudents(grade, subject);
			StudentsDataGrid.ItemsSource = students;
		}

		private void GradeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			FilterStudents();
		}

		private void SubjectComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			FilterStudents();
		}

		private void FilterStudents()
		{
			string selectedGrade = GradeComboBox.SelectedItem as string;
			string selectedSubject = SubjectComboBox.SelectedItem as string;
			LoadStudents(selectedGrade, selectedSubject);
		}

		private void AddEditButton_Click(object sender, RoutedEventArgs e)
		{
			var editWindow = new EditStudentWindow(selectedStudent);
			editWindow.ShowDialog();
			LoadStudents(); // Refresh the data after returning
		}

		private void StudentsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			selectedStudent = StudentsDataGrid.SelectedItem as Student;
		}
		private void UpdateStudentButton_Click(object sender, RoutedEventArgs e)
		{
			if (selectedStudent != null)
			{
				// Assuming you have TextBoxes for user input
				selectedStudent.Name = txtName.Text; // Assuming txtName is a TextBox for the student's name
				selectedStudent.Grade = GradeComboBox.SelectedItem as string; // Get selected grade
				selectedStudent.Subject = SubjectComboBox.SelectedItem as string; // Get selected subject
				selectedStudent.Marks = int.Parse(txtMarks.Text); // Assuming txtMarks is a TextBox for marks
				selectedStudent.AttendancePercentile = decimal.Parse(txtAttendance.Text); // Assuming txtAttendance is a TextBox for attendance

				// Update the student in the database
				dbHelper.UpdateStudent(selectedStudent);

				// Refresh the data grid
				LoadStudents();
			}
			else
			{
				MessageBox.Show("Please select a student to update.");
			}
		}

		private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
		{
			if (selectedStudent != null)
			{
				// Confirm deletion
				var result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					// Delete the student from the database
					dbHelper.DeleteStudent(selectedStudent.Id);

					// Refresh the data grid
					LoadStudents();
				}
			}
			else
			{
				MessageBox.Show("Please select a student to delete.");
			}
		}
	}
}