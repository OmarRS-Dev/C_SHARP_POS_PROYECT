-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 13-12-2024 a las 03:58:03
-- Versión del servidor: 8.0.17
-- Versión de PHP: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdpime`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `articulos`
--

CREATE TABLE `articulos` (
  `codigo` varchar(20) NOT NULL,
  `descripcion` varchar(80) NOT NULL,
  `p_compra` float(12,2) NOT NULL,
  `p_venta` float(12,2) NOT NULL,
  `existencia` float(12,2) NOT NULL,
  `stockmin` float(12,2) NOT NULL,
  `stockmax` float(12,2) NOT NULL,
  `codprovedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `articulos`
--

INSERT INTO `articulos` (`codigo`, `descripcion`, `p_compra`, `p_venta`, `existencia`, `stockmin`, `stockmax`, `codprovedor`) VALUES
('038000846731', 'Pringles 37 gr Original ', 15.00, 20.00, 10.00, 5.00, 15.00, 1),
('038000846755', 'Papas Pringles Queso 40gr', 15.00, 20.00, 10.00, 5.00, 15.00, 4),
('1', '1 metro de cable inalambrico ', 30.00, 100.00, 50.00, 10.00, 60.00, 4),
('10', 'Pastillas de Silicio', 350.00, 1300.00, 80.00, 50.00, 150.00, 12),
('11', 'Laptop Katana MSI 3.0', 7500.00, 12000.00, 5.00, 2.00, 8.00, 9),
('2', 'Soldadura para madera', 10.00, 350.00, 80.00, 60.00, 100.00, 5),
('3', '1 litro de pintura transparente', 30.00, 80.00, 15.00, 10.00, 20.00, 2),
('4', 'Martillo sin impacto', 30.00, 80.00, 20.00, 15.00, 40.00, 4),
('5', 'Destornillador de punta redonda', 15.00, 40.00, 15.00, 5.00, 20.00, 5),
('6', 'Disco de calibre 50', 50.00, 200.00, 10.00, 2.00, 10.00, 1),
('7', 'Aceite en polvo', 90.00, 175.00, 10.00, 5.00, 15.00, 2),
('8', 'Electrodos de plastico', 150.00, 235.00, 20.00, 16.00, 30.00, 3),
('9', 'Iman para madera', 50.00, 120.00, 100.00, 80.00, 130.00, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `codigo` int(11) NOT NULL,
  `rfc` varchar(15) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `email` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`codigo`, `rfc`, `nombre`, `direccion`, `telefono`, `email`) VALUES
(0, 'XAXX010101000', 'PUBLICO EN GENERAL', '----------', '----------', '----------'),
(1, 'JSH2203LO01', 'José Alberto Luque López', 'Isla Tlachichintle #6, Guamúchil, Sinaloa', '6731232913', 'Henrybelico@gmail.com'),
(2, 'KJAJJJAKJKJAKMR', 'Edgar Estiel Heraldez Camacho', 'Prado Bonito, Guamúchil, SInaloa', '6731000147', 'herladezbrawlstars@gmail.com'),
(3, 'SSMD467429HGF45', 'Reynaldo Daniel Leyva Angulo', 'El prado', '6731151807', 'reychilorio282@roblox.com'),
(5, 'FRRS2505RSLMN90', 'Fredy Omar Román Salas', 'Unidad Nacional', '6731151807', 'fredysandcompany@outlook.com'),
(6, 'GSRF26718JHAHAL', 'José Pedro Infante Cruz', 'Av Mariano Matamoros Nte SN, Lomas del Valle, 81410 Guamúchi', '673731001', 'pedritogamer2024@gmail.com'),
(7, 'LAGR3456MSL23KS', 'Laurita Garza', 'Rio Bravo', '6671001212', 'lauritaxemilio1979@hotmail.com'),
(8, 'MKWA2093HSLMN90', 'Mike Wasausky', 'Monsters Inc', '6734562314', 'mikenoobmaster@gmail.com'),
(9, 'FCCH2024HSLGML2', 'Fernando Campos Camacho', 'Guamuchil', '6737398597', 'fernandosoftgml@hotmail.com'),
(10, 'JSHWE343OLSD', 'Erasmo Vilareal', 'Guasave', '6875489898', 'eramospro777@hotmail.com'),
(11, 'ERTF154571RSLS2', 'Enrique Segoviano', 'CDMX', '6547502155', 'enrique8@chavo.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle`
--

CREATE TABLE `detalle` (
  `codigo` varchar(15) NOT NULL,
  `cantidad` double NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `precio` decimal(19,4) NOT NULL,
  `factura` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `deudores`
--

CREATE TABLE `deudores` (
  `codcliente` int(11) NOT NULL,
  `deuda` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `deudores`
--

INSERT INTO `deudores` (`codcliente`, `deuda`) VALUES
(1, 28101.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encabezado`
--

CREATE TABLE `encabezado` (
  `factura` int(11) NOT NULL,
  `numcli` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `rfc` varchar(15) NOT NULL,
  `fecha` datetime NOT NULL,
  `total` decimal(19,4) NOT NULL,
  `credito` binary(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `codigo` int(11) NOT NULL,
  `rfc` varchar(15) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `email` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`codigo`, `rfc`, `nombre`, `direccion`, `telefono`, `email`) VALUES
(1, 'DJSJSJSJSNSND', 'Samsung', 'Corea del sur', '6732587898', 'samsung.help@samsung.com'),
(2, 'AHVB123471LL98', 'Apple', 'Los Ángeles, California', '6731238990', 'Applehelpcenter@icloud.com'),
(3, 'AGSB647302HSL72', 'Huawei', 'China xd', '7627722', '象形字形 声 字假借 字 @gmail.com'),
(4, 'AKJS920122HSL09', 'Lenovo', 'Corea', '562718290', 'Xx_LenovoPRO2024_xX@gmail.com'),
(5, 'HSRE2463MOTSGSJ', 'Motorola Sa de Cv', 'Ecatepec', '6678910283', 'motorola2024pro@hotmail.com'),
(8, 'JHDG245378HSL25', 'Asus', 'Eua', '6731151807', 'asussupport@gmail.com'),
(9, 'GFRT539098LSK25', 'Msi', 'Argentina', '6674158598', 'MSI@hotmail.com'),
(10, 'CYCO025478RSLMN', 'Cisco Systems', 'Miami, Eua', '6687895232', 'cysco.help@gmail.com'),
(11, 'SYNO787841RJSL2', 'Sony', 'Hong Kong', '658789858', 'sony777@hotmail.com'),
(12, 'ITEL145465TRS41', 'Intel', 'Washintong DC', '557845424', 'intelgroup@intel.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `usuario` varchar(20) NOT NULL,
  `clave` varchar(20) NOT NULL,
  `rol` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`usuario`, `clave`, `rol`) VALUES
('Edgar', 'Maincra', 'ADMINISTRADOR'),
('Fernando', 'Ingenieria', 'ADMINISTRADOR'),
('Fredy', '7', 'ADMINISTRADOR'),
('Henry', 'Henry123', 'OPERADOR'),
('Omar', 'J\"25FORSmi', 'ADMINISTRADOR'),
('Rey', 'GeometryDash', 'SUPERVISOR');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `articulos`
--
ALTER TABLE `articulos`
  ADD PRIMARY KEY (`codigo`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`codigo`);

--
-- Indices de la tabla `deudores`
--
ALTER TABLE `deudores`
  ADD PRIMARY KEY (`codcliente`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`codigo`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
