using System.Windows;
using WPF_Application;

namespace WPF_Application
{
	public partial class EditStudentWindow : Window
{
	private DatabaseHelper dbHelper = new DatabaseHelper();
	private Student currentStudent;

	public EditStudentWindow(Student student = null)
	{
		InitializeComponent();
		currentStudent = student;

		if (currentStudent != null)
		{
			NameTextBox.Text = currentStudent.Name;
			GradeTextBox.Text = currentStudent.Grade;
			SubjectTextBox.Text = currentStudent.Subject;
			MarksTextBox.Text = currentStudent.Marks.ToString();
			AttendanceTextBox.Text = currentStudent.AttendancePercentile.ToString();
		}
	}

	private void SaveButton_Click(object sender, RoutedEventArgs e)
	{
		if (currentStudent == null)
		{
			currentStudent = new Student
			{
				Name = NameTextBox.Text,
				Grade = GradeTextBox.Text,
				Subject = SubjectTextBox.Text,
				Marks = int.Parse(MarksTextBox.Text),
				AttendancePercentile = decimal.Parse(AttendanceTextBox.Text)
			};
			dbHelper.AddStudent(currentStudent);
		}
		else
		{
			currentStudent.Name = NameTextBox.Text;
			currentStudent.Grade = GradeTextBox.Text;
			currentStudent.Subject = SubjectTextBox.Text;
			currentStudent.Marks = int.Parse(MarksTextBox.Text);
			currentStudent.AttendancePercentile = decimal.Parse(AttendanceTextBox.Text);
			dbHelper.UpdateStudent(currentStudent);
		}
		this.Close();
	}

	private void DeleteButton_Click(object sender, RoutedEventArgs e)
	{
		if (currentStudent != null)
		{
			dbHelper.DeleteStudent(currentStudent.Id);
			this.Close();
		}
	}
}
}