CREATE DATABASE StudentProgressTracker;

USE StudentProgressTracker;

CREATE TABLE Students (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Grade VARCHAR(10) NOT NULL,
    Subject VARCHAR(100) NOT NULL,
    Marks INT NOT NULL,
    AttendancePercentile DECIMAL(5,2) NOT NULL
);