   M S B A M L   `   `   `  ����  WPF Application     WPF_Application.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Student Progress Tracker��5   	   $	��450��6*   $	��800��67   
�������.��5      � .+�5   
   �� -   5         ��Name$ GradeComboBox��5      $	��120��6\   $��23,11,657,375q�6h   
���   �6   �� 5   
   -   5        $ SubjectComboBox��5      $	��120��6`   $��220,11,460,375q�6l   
���   �6�   �� 5
   
   -   5        $��Add Student��5
      $	��120��6C   $��414,10,266,375q�6O   
�������
���� ��6z   �� 5   
   -   5         ��Name$ txtName��5      $	��120��6#   $��60,81,620,332q�6/   �� 5   
   -   5        $ txtMarks��5      $��326,81,316,332q�6$   �� 5   
   -   5        $ txtAttendance��5      $	��120��6)   $��550,70,670,358q�65   �� 5   
   -   5        $��Update Student��5      $	��120��6L   $��539,11,141,375q�6X   
�������
���� ��6�   �� 5   
   -   5        $��Delete Student��5      $��664,11,10,375q�6L   
�������
���� ��6v   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ StudentsDataGrid��5         AutoGenerateColumns$ False��6-   $��10,159,10,10q�6I      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5      $ Grade��6%    64   �� *Grade+  5      $ Subject��6%    66   �� *	Subject+  5      $ Marks��6%    64   �� *Marks+  5      $ Attendance Percentile��6%    6D   �� *AttendancePercentile+5      5      5      