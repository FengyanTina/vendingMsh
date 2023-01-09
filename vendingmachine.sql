-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 09, 2023 at 08:23 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `vendingmachine`
--

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `employee_id` int(11) NOT NULL,
  `employee_name` varchar(32) NOT NULL,
  `employee_phone` varchar(32) NOT NULL,
  `employee_email` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`employee_id`, `employee_name`, `employee_phone`, `employee_email`) VALUES
(1, 'David Weloton', '076-248999', 'david@vending.se'),
(2, 'Christina List', '076-888999', 'christina@vending.se'),
(3, 'Kiki Wang', '075-6789534', 'kiki@vending.se');

-- --------------------------------------------------------

--
-- Table structure for table `machines`
--

CREATE TABLE `machines` (
  `machine_id` int(11) NOT NULL,
  `machine_location` varchar(100) NOT NULL,
  `machine_model` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `machines`
--

INSERT INTO `machines` (`machine_id`, `machine_location`, `machine_model`) VALUES
(1, 'Pallas Shopping center   ', 'xw334'),
(2, 'Boras Zoo Park           ', 'xw334'),
(3, 'Knanneland Shopping Center', 'xw334');

-- --------------------------------------------------------

--
-- Table structure for table `orderdetails`
--

CREATE TABLE `orderdetails` (
  `orderDetail_id` int(11) NOT NULL,
  `refillOrder_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_price` double NOT NULL,
  `order_quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `orderdetails`
--

INSERT INTO `orderdetails` (`orderDetail_id`, `refillOrder_id`, `product_id`, `product_price`, `order_quantity`) VALUES
(1, 1, 1, 5, 20),
(2, 1, 2, 5, 20),
(3, 1, 3, 5, 20),
(4, 1, 4, 5, 20),
(5, 1, 5, 5, 20),
(6, 1, 6, 8, 20),
(7, 1, 7, 8, 20),
(8, 1, 8, 8, 20),
(9, 1, 9, 8, 20),
(10, 1, 10, 8, 20),
(11, 1, 11, 8, 20),
(12, 1, 12, 8, 20),
(13, 2, 1, 5, 20),
(14, 2, 2, 5, 20),
(15, 2, 3, 5, 20),
(16, 2, 4, 5, 20),
(17, 2, 5, 5, 20),
(18, 2, 6, 8, 20),
(19, 2, 7, 8, 20),
(20, 2, 8, 8, 20),
(21, 2, 9, 8, 20),
(22, 2, 10, 8, 20),
(23, 2, 11, 8, 20),
(24, 2, 12, 8, 20),
(25, 3, 1, 5, 21),
(26, 3, 2, 5, 20),
(27, 3, 3, 5, 20),
(28, 3, 4, 5, 20),
(29, 3, 5, 5, 20),
(30, 3, 6, 8, 20),
(31, 3, 7, 8, 20),
(32, 3, 8, 8, 20),
(33, 3, 9, 8, 20),
(34, 3, 10, 8, 20),
(35, 3, 11, 8, 20),
(36, 3, 12, 8, 21),
(42, 7, 13, 8, 20),
(43, 8, 16, 8, 20),
(44, 9, 1, 5, 6),
(45, 9, 2, 5, 9),
(46, 9, 3, 5, 8),
(47, 9, 13, 8, 1),
(48, 9, 16, 8, 1),
(49, 10, 1, 5, 8),
(50, 10, 2, 5, 4),
(51, 10, 3, 5, 7),
(52, 10, 4, 5, 5),
(53, 10, 6, 8, 1),
(54, 10, 8, 8, 1),
(55, 10, 9, 8, 7),
(56, 10, 11, 8, 5),
(57, 10, 12, 8, 3),
(58, 11, 1, 5, 1),
(59, 11, 2, 5, 4),
(60, 11, 4, 5, 1),
(61, 11, 5, 5, 2),
(62, 11, 6, 8, 1),
(63, 11, 7, 8, 2),
(64, 11, 8, 8, 1),
(65, 11, 9, 8, 2),
(66, 11, 11, 8, 2),
(67, 11, 12, 8, 1),
(77, 13, 11, 8, 1),
(78, 14, 16, 8, 1),
(79, 15, 16, 8, 1),
(80, 16, 16, 8, 1),
(81, 17, 1, 5, 2),
(82, 17, 5, 5, 2),
(83, 17, 7, 8, 1),
(84, 18, 16, 8, 2),
(85, 19, 2, 5, 3),
(86, 19, 6, 8, 7),
(87, 20, 6, 8, 2),
(88, 21, 1, 5, 2),
(89, 21, 3, 5, 1),
(90, 21, 6, 8, 1),
(91, 21, 9, 8, 1),
(92, 22, 1, 5, 2),
(93, 22, 3, 5, 2),
(94, 23, 1, 5, 2),
(95, 23, 3, 5, 3),
(96, 24, 1, 5, 3),
(97, 25, 4, 5, 2),
(98, 26, 1, 5, 5);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(32) NOT NULL,
  `order_price` double NOT NULL,
  `sale_price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `order_price`, `sale_price`) VALUES
(1, 'Julmust  ', 5, 10),
(2, 'Orange Juice', 5, 10),
(3, 'Protein Bars', 5, 10),
(4, 'Chocolate Bars', 5, 10),
(5, 'Mineral Water', 5, 10),
(6, 'Yogurt   ', 8, 16),
(7, 'Cok          ', 8, 16),
(8, 'Cookie  ', 8, 16),
(9, 'OREO         ', 8, 16),
(10, 'BEEF JERKY ', 8, 16),
(11, 'PopCorn   ', 8, 16),
(12, 'HealthyNut', 8, 16),
(13, 'Milk      ', 8, 16),
(16, 'Läkerol  ', 8, 10);

-- --------------------------------------------------------

--
-- Table structure for table `refillorders`
--

CREATE TABLE `refillorders` (
  `refillOrder_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `machine_id` int(11) NOT NULL,
  `order_date` date NOT NULL,
  `order_status` tinyint(1) NOT NULL,
  `checkedBy_employee` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `refillorders`
--

INSERT INTO `refillorders` (`refillOrder_id`, `employee_id`, `machine_id`, `order_date`, `order_status`, `checkedBy_employee`) VALUES
(1, 1, 1, '2022-08-01', 1, 1),
(2, 2, 2, '2022-09-01', 1, 2),
(3, 2, 3, '2022-09-01', 1, 3),
(7, 1, 1, '2022-11-22', 1, 1),
(8, 1, 1, '2022-11-11', 1, 1),
(9, 1, 1, '2022-12-12', 1, 1),
(10, 2, 2, '2022-12-12', 1, 2),
(11, 3, 3, '2022-12-12', 1, 3),
(13, 2, 2, '2022-12-12', 1, 2),
(14, 1, 1, '2022-12-22', 1, 1),
(15, 1, 1, '2022-12-22', 1, 1),
(16, 1, 1, '2022-12-22', 1, 1),
(17, 1, 1, '2022-12-23', 1, 1),
(18, 1, 1, '2022-12-23', 1, 1),
(19, 1, 1, '2022-12-23', 1, 1),
(20, 2, 2, '2022-12-23', 1, 2),
(21, 3, 3, '2023-01-04', 1, 3),
(22, 1, 1, '2023-01-04', 1, 1),
(23, 1, 1, '2023-01-04', 1, 1),
(24, 1, 1, '2023-01-04', 1, 1),
(25, 1, 1, '2023-01-04', 1, 1),
(26, 1, 1, '2023-01-05', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `saledetails`
--

CREATE TABLE `saledetails` (
  `saleDetail_id` int(11) NOT NULL,
  `sale_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_price` double NOT NULL,
  `sale_quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `saledetails`
--

INSERT INTO `saledetails` (`saleDetail_id`, `sale_id`, `product_id`, `product_price`, `sale_quantity`) VALUES
(1, 1, 1, 10, 2),
(2, 2, 1, 10, 1),
(3, 3, 2, 10, 2),
(4, 4, 3, 10, 3),
(5, 4, 1, 10, 2),
(6, 5, 2, 10, 3),
(7, 6, 3, 10, 1),
(8, 6, 1, 10, 1),
(9, 6, 3, 10, 2),
(10, 7, 2, 10, 2),
(11, 8, 3, 10, 1),
(12, 8, 2, 10, 1),
(13, 9, 3, 10, 1),
(14, 10, 2, 10, 1),
(15, 11, 1, 10, 1),
(16, 11, 3, 10, 1),
(17, 12, 4, 10, 2),
(18, 13, 1, 10, 1),
(19, 14, 3, 10, 1),
(20, 15, 3, 10, 1),
(21, 16, 3, 10, 1),
(22, 17, 2, 10, 1),
(23, 18, 4, 10, 2),
(24, 19, 1, 10, 1),
(25, 20, 9, 16, 1),
(26, 21, 9, 16, 1),
(27, 22, 4, 10, 1),
(28, 23, 3, 10, 1),
(29, 24, 8, 16, 1),
(30, 25, 1, 10, 1),
(31, 21, 12, 16, 1),
(32, 22, 11, 16, 2),
(33, 23, 9, 16, 2),
(34, 24, 12, 16, 1),
(35, 24, 11, 16, 1),
(36, 25, 2, 10, 2),
(37, 21, 1, 10, 1),
(38, 22, 1, 10, 1),
(39, 23, 12, 16, 1),
(40, 24, 9, 10, 2),
(41, 25, 2, 10, 1),
(42, 25, 11, 16, 1),
(43, 26, 1, 10, 2),
(44, 27, 9, 10, 1),
(45, 28, 3, 10, 2),
(46, 29, 6, 16, 1),
(47, 30, 11, 16, 1),
(48, 31, 7, 16, 1),
(49, 32, 11, 16, 1),
(50, 33, 2, 10, 1),
(51, 34, 8, 16, 1),
(52, 35, 9, 16, 2),
(53, 36, 12, 16, 1),
(54, 36, 2, 10, 2),
(55, 38, 5, 10, 1),
(56, 39, 4, 10, 1),
(57, 40, 5, 10, 1),
(58, 41, 1, 10, 1),
(59, 42, 12, 16, 1),
(60, 43, 7, 16, 1),
(61, 44, 11, 16, 1),
(62, 45, 6, 16, 1),
(63, 46, 2, 10, 1),
(64, 37, 1, 10, 1),
(65, 47, 13, 8, 1),
(66, 48, 16, 8, 1),
(71, 49, 6, 16, 1),
(72, 49, 1, 10, 2),
(73, 50, 11, 16, 1),
(74, 50, 13, 16, 2),
(75, 51, 5, 10, 2),
(76, 52, 3, 10, 1),
(77, 53, 6, 16, 2),
(78, 54, 7, 16, 1),
(79, 55, 9, 16, 1),
(80, 56, 1, 10, 2),
(81, 57, 16, 10, 5),
(82, 58, 6, 16, 7),
(83, 59, 2, 10, 3),
(84, 60, 1, 10, 2),
(85, 61, 3, 10, 2),
(86, 62, 3, 10, 1),
(87, 63, 1, 10, 2),
(88, 64, 3, 10, 2),
(89, 65, 1, 10, 3),
(90, 66, 4, 10, 2),
(91, 67, 1, 10, 5);

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `sale_id` int(11) NOT NULL,
  `machine_id` int(11) NOT NULL,
  `sale_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`sale_id`, `machine_id`, `sale_date`) VALUES
(1, 1, '2022-06-01 00:00:00'),
(2, 1, '2022-06-02 00:00:00'),
(3, 1, '2022-06-08 00:00:00'),
(4, 1, '2022-06-15 00:00:00'),
(5, 1, '2022-07-01 00:00:00'),
(6, 1, '2022-07-06 00:00:00'),
(7, 1, '2022-07-13 00:00:00'),
(8, 1, '2022-07-20 00:00:00'),
(9, 1, '2022-07-28 00:00:00'),
(10, 1, '2022-07-30 00:00:00'),
(11, 2, '2022-06-08 00:00:00'),
(12, 2, '2022-06-15 00:00:00'),
(13, 2, '2022-06-16 00:00:00'),
(14, 2, '2022-12-28 00:00:00'),
(15, 2, '2022-06-30 00:00:00'),
(16, 2, '2022-07-06 00:00:00'),
(17, 2, '2022-07-07 00:00:00'),
(18, 2, '2022-07-13 00:00:00'),
(19, 2, '2022-08-01 00:00:00'),
(20, 2, '2022-08-03 00:00:00'),
(21, 2, '2022-08-15 00:00:00'),
(22, 2, '2022-08-16 00:00:00'),
(23, 2, '2022-08-19 00:00:00'),
(24, 2, '2022-08-24 00:00:00'),
(25, 2, '2022-09-01 00:00:00'),
(26, 2, '2022-10-01 00:00:00'),
(27, 2, '2022-10-05 00:00:00'),
(28, 2, '2022-10-10 00:00:00'),
(29, 2, '2022-10-10 00:00:00'),
(30, 2, '2022-12-13 00:00:00'),
(31, 3, '2022-06-02 00:00:00'),
(32, 3, '2022-06-02 00:00:00'),
(33, 3, '2022-06-08 00:00:00'),
(34, 3, '2022-06-15 00:00:00'),
(35, 3, '2022-06-17 00:00:00'),
(36, 3, '0000-00-00 00:00:00'),
(37, 3, '2022-07-13 00:00:00'),
(38, 3, '2022-07-20 00:00:00'),
(39, 3, '2022-07-21 00:00:00'),
(40, 3, '2022-07-30 00:00:00'),
(41, 3, '2022-08-01 00:00:00'),
(42, 3, '2022-08-09 00:00:00'),
(43, 3, '2022-08-15 00:00:00'),
(44, 3, '2022-08-23 00:00:00'),
(45, 3, '2022-08-23 00:00:00'),
(46, 3, '2022-09-01 00:00:00'),
(47, 1, '2022-12-12 00:00:00'),
(48, 1, '2022-12-12 00:00:00'),
(49, 3, '2022-12-12 00:00:00'),
(50, 2, '2022-12-12 00:00:00'),
(51, 1, '2022-12-13 00:00:00'),
(52, 3, '2022-12-13 00:00:00'),
(53, 2, '2022-12-13 00:00:00'),
(54, 1, '2022-12-13 10:55:48'),
(55, 3, '2022-12-13 10:58:19'),
(56, 1, '2022-12-23 09:33:29'),
(57, 1, '2022-12-23 09:39:53'),
(58, 1, '2022-12-23 09:42:52'),
(59, 1, '2022-12-23 09:43:05'),
(60, 1, '2023-01-04 14:01:01'),
(61, 1, '2023-01-04 14:03:18'),
(62, 1, '2023-01-04 14:21:36'),
(63, 1, '2023-01-04 14:32:09'),
(64, 1, '2023-01-04 14:32:36'),
(65, 1, '2023-01-04 14:34:02'),
(66, 1, '2023-01-04 14:39:34'),
(67, 1, '2023-01-05 10:17:25');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`employee_id`);

--
-- Indexes for table `machines`
--
ALTER TABLE `machines`
  ADD PRIMARY KEY (`machine_id`);

--
-- Indexes for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD PRIMARY KEY (`orderDetail_id`),
  ADD KEY `orderdetails_ibfk_1` (`refillOrder_id`),
  ADD KEY `orderdetails_ibfk_2` (`product_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `refillorders`
--
ALTER TABLE `refillorders`
  ADD PRIMARY KEY (`refillOrder_id`),
  ADD KEY `refillorders_ibfk_1` (`machine_id`),
  ADD KEY `refillorders_ibfk_2` (`employee_id`);

--
-- Indexes for table `saledetails`
--
ALTER TABLE `saledetails`
  ADD PRIMARY KEY (`saleDetail_id`),
  ADD KEY `sale_id` (`sale_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`sale_id`),
  ADD KEY `machine_id` (`machine_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `employee_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `machines`
--
ALTER TABLE `machines`
  MODIFY `machine_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `orderdetails`
--
ALTER TABLE `orderdetails`
  MODIFY `orderDetail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=99;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `refillorders`
--
ALTER TABLE `refillorders`
  MODIFY `refillOrder_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `saledetails`
--
ALTER TABLE `saledetails`
  MODIFY `saleDetail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=92;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `sale_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD CONSTRAINT `orderdetails_ibfk_1` FOREIGN KEY (`refillOrder_id`) REFERENCES `refillorders` (`refillOrder_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `orderdetails_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `refillorders`
--
ALTER TABLE `refillorders`
  ADD CONSTRAINT `refillorders_ibfk_1` FOREIGN KEY (`machine_id`) REFERENCES `machines` (`machine_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `refillorders_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `saledetails`
--
ALTER TABLE `saledetails`
  ADD CONSTRAINT `saledetails_ibfk_1` FOREIGN KEY (`sale_id`) REFERENCES `sales` (`sale_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `saledetails_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`machine_id`) REFERENCES `machines` (`machine_id`) ON DELETE CASCADE ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
