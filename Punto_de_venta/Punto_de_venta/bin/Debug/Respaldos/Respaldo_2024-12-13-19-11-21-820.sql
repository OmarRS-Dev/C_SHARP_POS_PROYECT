-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bdpimes
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `articulos`
--

DROP TABLE IF EXISTS `articulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `articulos` (
  `codigo` varchar(20) NOT NULL,
  `descripcion` varchar(80) NOT NULL,
  `p_compra` float(12,2) NOT NULL,
  `p_venta` float(12,2) NOT NULL,
  `existencia` float(12,2) NOT NULL,
  `stockmin` float(12,2) NOT NULL,
  `stockmax` float(12,2) NOT NULL,
  `codprovedor` int(11) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articulos`
--

LOCK TABLES `articulos` WRITE;
/*!40000 ALTER TABLE `articulos` DISABLE KEYS */;
INSERT INTO `articulos` VALUES ('038000846731','Pringles 37 gr Original ',15.00,20.00,10.00,5.00,15.00,1),('038000846755','Papas Pringles Queso 40gr',15.00,20.00,10.00,5.00,15.00,4),('1','1 metro de cable inalambrico ',30.00,100.00,50.00,10.00,60.00,4),('10','Pastillas de Silicio',350.00,1300.00,80.00,50.00,150.00,12),('11','Laptop Katana MSI 3.0',7500.00,12000.00,5.00,2.00,8.00,9),('2','Soldadura para madera',10.00,350.00,80.00,60.00,100.00,5),('3','1 litro de pintura transparente',30.00,80.00,15.00,10.00,20.00,2),('4','Martillo sin impacto',30.00,80.00,20.00,15.00,40.00,4),('5','Destornillador de punta redonda',15.00,40.00,15.00,5.00,20.00,5),('6','Disco de calibre 50',50.00,200.00,10.00,2.00,10.00,1),('7','Aceite en polvo',90.00,175.00,10.00,5.00,15.00,2),('8','Electrodos de plastico',150.00,235.00,20.00,16.00,30.00,3),('9','Iman para madera',50.00,120.00,100.00,80.00,130.00,1);
/*!40000 ALTER TABLE `articulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `rfc` varchar(15) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `email` varchar(60) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (0,'XAXX010101000','PUBLICO EN GENERAL','----------','----------','----------'),(1,'JSH2203LO01','JosÃƒÆ’Ã‚Â© Alberto Luque LÃƒÆ’Ã‚Â³pez','Isla Tlachichintle #6, GuamÃƒÆ’Ã‚Âºchil, Sinaloa','6731232913','Henrybelico@gmail.com'),(2,'KJAJJJAKJKJAKMR','Edgar Estiel Heraldez Camacho','Prado Bonito, GuamÃƒÆ’Ã‚Âºchil, SInaloa','6731000147','herladezbrawlstars@gmail.com'),(3,'SSMD467429HGF45','Reynaldo Daniel Leyva Angulo','El prado','6731151807','reychilorio282@roblox.com'),(5,'FRRS2505RSLMN90','Fredy Omar RomÃƒÆ’Ã‚Â¡n Salas','Unidad Nacional','6731151807','fredysandcompany@outlook.com'),(6,'GSRF26718JHAHAL','JosÃƒÆ’Ã‚Â© Pedro Infante Cruz','Av Mariano Matamoros Nte SN, Lomas del Valle, 81410 GuamÃƒÆ’Ã‚Âº','673731001','pedritogamer2024@gmail.com'),(7,'LAGR3456MSL23KS','Laurita Garza','Rio Bravo','6671001212','lauritaxemilio1979@hotmail.com'),(8,'MKWA2093HSLMN90','Mike Wasausky','Monsters Inc','6734562314','mikenoobmaster@gmail.com'),(9,'FCCH2024HSLGML2','Fernando Campos Camacho','Guamuchil','6737398597','fernandosoftgml@hotmail.com'),(10,'JSHWE343OLSD','Erasmo Vilareal','Guasave','6875489898','eramospro777@hotmail.com'),(11,'ERTF154571RSLS2','Enrique Segoviano','CDMX','6547502155','enrique8@chavo.com');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle`
--

DROP TABLE IF EXISTS `detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle` (
  `codigo` varchar(15) NOT NULL,
  `cantidad` double NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `precio` decimal(19,4) NOT NULL,
  `factura` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle`
--

LOCK TABLES `detalle` WRITE;
/*!40000 ALTER TABLE `detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deudores`
--

DROP TABLE IF EXISTS `deudores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deudores` (
  `codcliente` int(11) NOT NULL,
  `deuda` float(10,2) NOT NULL,
  PRIMARY KEY (`codcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deudores`
--

LOCK TABLES `deudores` WRITE;
/*!40000 ALTER TABLE `deudores` DISABLE KEYS */;
INSERT INTO `deudores` VALUES (1,28101.00),(7,250.00);
/*!40000 ALTER TABLE `deudores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `encabezado`
--

DROP TABLE IF EXISTS `encabezado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `encabezado` (
  `factura` int(11) NOT NULL,
  `numcli` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `rfc` varchar(15) NOT NULL,
  `fecha` datetime NOT NULL,
  `total` decimal(19,4) NOT NULL,
  `credito` binary(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `encabezado`
--

LOCK TABLES `encabezado` WRITE;
/*!40000 ALTER TABLE `encabezado` DISABLE KEYS */;
/*!40000 ALTER TABLE `encabezado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedores` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `rfc` varchar(15) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `direccion` varchar(60) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `email` varchar(60) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedores`
--

LOCK TABLES `proveedores` WRITE;
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES (1,'DJSJSJSJSNSND','Samsung','Corea del sur','6732587898','samsung.help@samsung.com'),(2,'AHVB123471LL98','Apple','Los ÃƒÆ’Ã‚Ângeles, California','6731238990','Applehelpcenter@icloud.com'),(3,'AGSB647302HSL72','Huawei','China xd','7627722','ÃƒÂ¨Ã‚Â±Ã‚Â¡ÃƒÂ¥Ã‚Â½Ã‚Â¢ÃƒÂ¥Ã‚Â­Ã¢â‚¬â€ÃƒÂ¥Ã‚Â½Ã‚Â¢ ÃƒÂ¥Ã‚Â£Ã‚Â° ÃƒÂ¥Ã‚Â­Ã¢â‚¬â€ÃƒÂ¥Ã‚ÂÃ¢â‚¬Â¡ÃƒÂ¥Ã¢â€šÂ¬Ã…Â¸ ÃƒÂ¥Ã‚Â­Ã¢'),(4,'AKJS920122HSL09','Lenovo','Corea','562718290','Xx_LenovoPRO2024_xX@gmail.com'),(5,'HSRE2463MOTSGSJ','Motorola Sa de Cv','Ecatepec','6678910283','motorola2024pro@hotmail.com'),(8,'JHDG245378HSL25','Asus','Eua','6731151807','asussupport@gmail.com'),(9,'GFRT539098LSK25','Msi','Argentina','6674158598','MSI@hotmail.com'),(10,'CYCO025478RSLMN','Cisco Systems','Miami, Eua','6687895232','cysco.help@gmail.com'),(11,'SYNO787841RJSL2','Sony','Hong Kong','658789858','sony777@hotmail.com'),(12,'ITEL145465TRS41','Intel','Washintong DC','557845424','intelgroup@intel.com');
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `usuario` varchar(20) NOT NULL,
  `clave` varchar(20) NOT NULL,
  `rol` varchar(13) NOT NULL,
  PRIMARY KEY (`usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES ('Edgar','Maincra','ADMINISTRADOR'),('Fernando','Ingenieria','ADMINISTRADOR'),('Fredy','7','ADMINISTRADOR'),('Henry','Henry123','OPERADOR'),('Omar','J\"25FORSmi','ADMINISTRADOR'),('Rey','GeometryDash','SUPERVISOR');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-13 19:11:22

