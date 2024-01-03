-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 20, 2023 at 08:10 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tickets`
--

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`username`, `password`) VALUES
('admin', '1234');

-- --------------------------------------------------------

--
-- Table structure for table `passenger`
--

CREATE TABLE `passenger` (
  `TicketNumber` int(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `MiddleName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Age` int(11) NOT NULL,
  `Address` varchar(50) NOT NULL,
  `CpNumber` varchar(50) NOT NULL,
  `EmailAddress` varchar(50) NOT NULL,
  `Gender` varchar(15) NOT NULL,
  `DestinationFrom` varchar(50) NOT NULL,
  `DestinationTo` varchar(50) NOT NULL,
  `DateofTravel` varchar(50) NOT NULL,
  `BusNumber` int(11) NOT NULL,
  `SeatNumber` int(11) NOT NULL,
  `Price` varchar(50) NOT NULL,
  `Staff` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `passenger`
--

INSERT INTO `passenger` (`TicketNumber`, `FirstName`, `MiddleName`, `LastName`, `Age`, `Address`, `CpNumber`, `EmailAddress`, `Gender`, `DestinationFrom`, `DestinationTo`, `DateofTravel`, `BusNumber`, `SeatNumber`, `Price`, `Staff`) VALUES
(2023001, 'Servando', 'Subang', 'Tio', 22, 'Dakit, SF, Southern Leyte', '09956322301', 'servandoytio@gmail.com', 'Male', 'Pasay', 'San Francisco', '2023-12-20', 9857, 25, '2,347.40', 'Edgar Corsiga'),
(2023002, 'Mary Rose', 'P', 'Quigao', 22, 'Agay,Ay, SJ, Southern Leyte', '09876543211', 'mpquigao@gmail.com', 'Female', 'San Juan', 'Pasay', '2023-12-22', 9857, 23, '2,212.60', 'Robert A. Gacutan');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
