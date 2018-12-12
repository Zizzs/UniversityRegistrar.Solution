-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 12, 2018 at 01:23 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `universityregistrar`
--

-- --------------------------------------------------------

--
-- Table structure for table `students_courses`
--

CREATE TABLE `students_courses` (
  `id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students_courses`
--

INSERT INTO `students_courses` (`id`, `student_id`, `course_id`, `status`) VALUES
(1, 1, 1, 0),
(2, 2, 1, 0),
(3, 4, 4, 0),
(4, 1, 2, 0),
(5, 1, 3, 0),
(6, 1, 6, 1),
(7, 1, 5, 0),
(8, 1, 4, 0),
(9, 5, 4, 0),
(10, 3, 5, 0),
(11, 3, 2, 0),
(12, 6, 4, 0),
(13, 6, 6, 0),
(14, 6, 5, 0),
(15, 1, 11, 1),
(16, 7, 1, 0),
(17, 7, 11, 0),
(18, 6, 9, 0),
(19, 3, 10, 0),
(20, 5, 11, 0),
(21, 6, 3, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `students_courses`
--
ALTER TABLE `students_courses`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `students_courses`
--
ALTER TABLE `students_courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
