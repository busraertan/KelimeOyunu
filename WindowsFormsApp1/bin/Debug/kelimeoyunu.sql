-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: kelimeoyunu
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cevaplar`
--

DROP TABLE IF EXISTS `cevaplar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cevaplar` (
  `cevap_id` int NOT NULL AUTO_INCREMENT,
  `cevap` varchar(45) NOT NULL,
  `harf_sayisi` int NOT NULL,
  PRIMARY KEY (`cevap_id`),
  UNIQUE KEY `cevap_id_UNIQUE` (`cevap_id`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cevaplar`
--

LOCK TABLES `cevaplar` WRITE;
/*!40000 ALTER TABLE `cevaplar` DISABLE KEYS */;
INSERT INTO `cevaplar` VALUES (1,'Yüce',4),(2,'Ajans',5),(3,'Zamane',6),(4,'Uğrunda',7),(5,'Tahsilat',8),(6,'Nemelazım',9),(7,'Dilimlemek',10),(8,'Çiftegitme',10),(9,'Zona',4),(10,'Robot',5),(11,'Sağmak',6),(12,'Keramet',7),(13,'Yerinmek',8),(14,'Hizmetkar',9),(15,'Sıla',4),(16,'Yurt',4),(17,'Ilgın',5),(18,'Litre',5),(19,'Hercai',6),(20,'Jaluzi',6),(21,'Pastane',7),(22,'İşatmak',7),(23,'Haytalık',8),(24,'Rahmetli',8),(25,'Ilıştırma',9),(26,'Pörtlemek',9),(27,'Senetsepet',10),(28,'Yaşlıbaşlı',10);
/*!40000 ALTER TABLE `cevaplar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kullanici`
--

DROP TABLE IF EXISTS `kullanici`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kullanici` (
  `k_id` int NOT NULL AUTO_INCREMENT,
  `k_adi` varchar(100) NOT NULL,
  PRIMARY KEY (`k_id`),
  UNIQUE KEY `k_id_UNIQUE` (`k_id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kullanici`
--

LOCK TABLES `kullanici` WRITE;
/*!40000 ALTER TABLE `kullanici` DISABLE KEYS */;
INSERT INTO `kullanici` VALUES (1,'busra'),(2,'ayşe'),(3,'fatma'),(4,'ahmet'),(5,'büşra'),(6,'mehmet'),(7,'Melek');
/*!40000 ALTER TABLE `kullanici` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skor`
--

DROP TABLE IF EXISTS `skor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skor` (
  `skor_id` int NOT NULL AUTO_INCREMENT,
  `k_adi` varchar(100) NOT NULL,
  `skor` int NOT NULL,
  `sure` varchar(10) NOT NULL,
  `tarih` varchar(100) NOT NULL,
  PRIMARY KEY (`skor_id`),
  UNIQUE KEY `skor_id_UNIQUE` (`skor_id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skor`
--

LOCK TABLES `skor` WRITE;
/*!40000 ALTER TABLE `skor` DISABLE KEYS */;
INSERT INTO `skor` VALUES (1,'busra',9800,'3:24','15.04.2021'),(2,'ahmet',8200,'2:58','15.04.2021'),(3,'büşra',9800,'3:43','15.04.2021'),(4,'Melek',5100,'3:31','16.04.2021');
/*!40000 ALTER TABLE `skor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sorular`
--

DROP TABLE IF EXISTS `sorular`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sorular` (
  `soru_id` int NOT NULL AUTO_INCREMENT,
  `soru` varchar(1000) NOT NULL,
  PRIMARY KEY (`soru_id`),
  UNIQUE KEY `soru_id_UNIQUE` (`soru_id`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sorular`
--

LOCK TABLES `sorular` WRITE;
/*!40000 ALTER TABLE `sorular` DISABLE KEYS */;
INSERT INTO `sorular` VALUES (1,'“Ulvi” sözünün Türkçe kökenli eş anlamlısı'),(2,'Haber toplama, yayma ve üyelerine dağıtma işiyle uğraşan kuruluş'),(3,'Yakınma ve hafifseme yoluyla “Şimdiki devir” anlamında kullanılan sözcük'),(4,'“Amacında, yolunda” anlamında bir zarf'),(5,'Alacakların toplanması'),(6,'“Bu işle ilgilenmem, buna karışmam” anlamında bir tabir'),(7,'Bir bütünü keserek ince ve yassı parçalara ayırmak'),(8,'Okey oyununda taşların eşlerini toplama'),(9,'Deride sinirler boyunca beliren, “Gece yanığı” olarak da bilinen hastalık'),(10,'Gelişen teknolojiyle birçok alanda insanın yerini alabileceği düşünülen elektromekanik araç'),(11,'Argoda, “Aldatarak parasını çekmek”'),(12,'Evliya mucizesi'),(13,'“Acınmak, yazıklanmak, teessüf etmek” anlamlarındaki söz'),(14,'Genellikle ev işlerinde çalışan, işverenlerin isteklerini yerine getiren emekçi'),(15,'Ait olunan fakat uzak kalıp özlenen yer'),(16,'Bakıma ve barınmaya muhtaç bir grup insanın oturduğu, yetiştirildiği veya bakıldığı kurum'),(17,'Akdeniz’e özgü, Deniz kıyısında bile yetişebilen bir ağaç'),(18,'Bir desimetreküp hacmindeki ölçü birimi'),(19,'Gönlü değişken, aşkı vefasız olan'),(20,'Şerit biçimde metal veya plastik levhalardan yapılmış bir tür perde'),(21,'Tatlı ve hamur işi dükkanı'),(22,'Argoda, “Gönlü olup olmadığını anlamak için manalı tavırlarda bulunmak, kur yapmak”'),(23,'Bir baltaya sap olmadan, başıboş yaşama hali'),(24,'“Olmak” fiili ile beraber kullanıldığında “Ölmek” anlamına gelen kelime'),(25,'Sıcak suya soğuk veya soğuğa sıcak su katma'),(26,'Özellikle gözler için, “Yuvasından dışarıya doğru fırlamak” anlamında bir söz'),(27,'“Borç kağıdı, sözleşme gibi resmi bağlayıcılığı olan belgeler” için kullanılan bir tabir'),(28,'“Uzun yılları geride bırakmış ve belli bir olgunluğa erişmiş” anlamında bir söz');
/*!40000 ALTER TABLE `sorular` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-04-16 18:18:20
