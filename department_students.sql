-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Dec 12, 2018 at 01:22 AM
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
-- Table structure for table `department_students`
--

CREATE TABLE `department_students` (
  `id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `department_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `department_students`
--

INSERT INTO `department_students` (`id`, `student_id`, `department_id`) VALUES
(1, 1, 1),
(2, 3, 2),
(3, 1, 4),
(4, 8, 4),
(5, 7, 4),
(6, 6, 4),
(7, 5, 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `department_students`
--
ALTER TABLE `department_students`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `department_students`
--
ALTER TABLE `department_students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
