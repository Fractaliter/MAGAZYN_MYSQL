-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 13 Lut 2018, 01:44
-- Wersja serwera: 10.1.29-MariaDB
-- Wersja PHP: 7.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `magazyn`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dostawcy`
--

CREATE TABLE `dostawcy` (
  `id_Dostawcy` int(11) NOT NULL,
  `Imie` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Nazwa_firmy` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `dostawcy`
--

INSERT INTO `dostawcy` (`id_Dostawcy`, `Imie`, `Nazwisko`, `Nazwa_firmy`) VALUES
(9, 'Testowy', 'Dostawca', 'Home');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klienci`
--

CREATE TABLE `klienci` (
  `Id_Klienci` int(11) NOT NULL,
  `Imie` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Nazwa_firmy` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `klienci`
--

INSERT INTO `klienci` (`Id_Klienci`, `Imie`, `Nazwisko`, `Nazwa_firmy`) VALUES
(13, 'Testowy', 'Klient', 'Home');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pozycja`
--

CREATE TABLE `pozycja` (
  `Numer_pozycji` int(11) NOT NULL,
  `Ilosc` int(11) NOT NULL,
  `Produkty_Id_Produkty` int(11) NOT NULL,
  `Zamowienia_id_Zamowienia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `pozycja`
--

INSERT INTO `pozycja` (`Numer_pozycji`, `Ilosc`, `Produkty_Id_Produkty`, `Zamowienia_id_Zamowienia`) VALUES
(49, 3, 2, 29),
(52, 5, 3, 30);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pracownicy`
--

CREATE TABLE `pracownicy` (
  `Id_Pracownika` int(11) NOT NULL,
  `Imie` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `pracownicy`
--

INSERT INTO `pracownicy` (`Id_Pracownika`, `Imie`, `Nazwisko`) VALUES
(66, 'Testowy', 'Pracownik');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `produkty`
--

CREATE TABLE `produkty` (
  `Id_produkty` int(11) NOT NULL,
  `Nazwa_Produktu` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Ilosc_Magazyn` int(11) NOT NULL,
  `Cena_aktualna` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `produkty`
--

INSERT INTO `produkty` (`Id_produkty`, `Nazwa_Produktu`, `Ilosc_Magazyn`, `Cena_aktualna`) VALUES
(1, 'Papierosy', 20, 15),
(2, 'Mleko', 2000, 5),
(3, 'Korniszony', 0, 5),
(5, 'Kawa', 2, 15),
(11, 'Klopsy', 55, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `uzytkownicy`
--

CREATE TABLE `uzytkownicy` (
  `Id_Uzytkownicy` int(11) NOT NULL,
  `Login` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Haslo` varchar(50) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Klienci_Id_Klienci` int(11) DEFAULT NULL,
  `Pracownicy_Id_Pracownicy` int(11) DEFAULT NULL,
  `Dostawcy_Id_Dostawcy` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `uzytkownicy`
--

INSERT INTO `uzytkownicy` (`Id_Uzytkownicy`, `Login`, `Haslo`, `Klienci_Id_Klienci`, `Pracownicy_Id_Pracownicy`, `Dostawcy_Id_Dostawcy`) VALUES
(46, 'testd', 'testd', NULL, NULL, 9),
(47, 'testp', 'testp', NULL, 66, NULL),
(48, 'testk', 'testk', 13, NULL, NULL);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zamowienia`
--

CREATE TABLE `zamowienia` (
  `Id_Zamowienia` int(11) NOT NULL,
  `Data_Zamowienia` date NOT NULL,
  `Czy_Przyjete` tinyint(1) NOT NULL,
  `Czy_Zrealizowane` tinyint(1) NOT NULL,
  `Czy_Zaplacone` tinyint(1) NOT NULL,
  `Kwota` int(11) NOT NULL,
  `Uzytkownicy_Id_Uzytkownicy` int(11) NOT NULL,
  `Dost/zam` text CHARACTER SET utf32 COLLATE utf32_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `zamowienia`
--

INSERT INTO `zamowienia` (`Id_Zamowienia`, `Data_Zamowienia`, `Czy_Przyjete`, `Czy_Zrealizowane`, `Czy_Zaplacone`, `Kwota`, `Uzytkownicy_Id_Uzytkownicy`, `Dost/zam`) VALUES
(29, '2018-02-13', 1, 0, 0, 2, 48, 'z'),
(30, '2018-02-13', 0, 1, 0, 3, 46, 'd');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `dostawcy`
--
ALTER TABLE `dostawcy`
  ADD PRIMARY KEY (`id_Dostawcy`);

--
-- Indexes for table `klienci`
--
ALTER TABLE `klienci`
  ADD PRIMARY KEY (`Id_Klienci`);

--
-- Indexes for table `pozycja`
--
ALTER TABLE `pozycja`
  ADD PRIMARY KEY (`Numer_pozycji`),
  ADD KEY `Produkty_Id_Produkty` (`Produkty_Id_Produkty`),
  ADD KEY `Zamowienia_id_Zamowienia` (`Zamowienia_id_Zamowienia`);

--
-- Indexes for table `pracownicy`
--
ALTER TABLE `pracownicy`
  ADD PRIMARY KEY (`Id_Pracownika`);

--
-- Indexes for table `produkty`
--
ALTER TABLE `produkty`
  ADD PRIMARY KEY (`Id_produkty`);

--
-- Indexes for table `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  ADD PRIMARY KEY (`Id_Uzytkownicy`),
  ADD KEY `Klienci_Id_Klienci` (`Klienci_Id_Klienci`),
  ADD KEY `Pracownicy_Id_Pracownicy` (`Pracownicy_Id_Pracownicy`),
  ADD KEY `Dostawcy_Id_Dostawcy` (`Dostawcy_Id_Dostawcy`);

--
-- Indexes for table `zamowienia`
--
ALTER TABLE `zamowienia`
  ADD PRIMARY KEY (`Id_Zamowienia`),
  ADD KEY `Uzytkownicy_Id_Uzytkownicy` (`Uzytkownicy_Id_Uzytkownicy`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `dostawcy`
--
ALTER TABLE `dostawcy`
  MODIFY `id_Dostawcy` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT dla tabeli `klienci`
--
ALTER TABLE `klienci`
  MODIFY `Id_Klienci` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT dla tabeli `pozycja`
--
ALTER TABLE `pozycja`
  MODIFY `Numer_pozycji` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT dla tabeli `pracownicy`
--
ALTER TABLE `pracownicy`
  MODIFY `Id_Pracownika` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- AUTO_INCREMENT dla tabeli `produkty`
--
ALTER TABLE `produkty`
  MODIFY `Id_produkty` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  MODIFY `Id_Uzytkownicy` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT dla tabeli `zamowienia`
--
ALTER TABLE `zamowienia`
  MODIFY `Id_Zamowienia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `pozycja`
--
ALTER TABLE `pozycja`
  ADD CONSTRAINT `Kluczyk` FOREIGN KEY (`Produkty_Id_Produkty`) REFERENCES `produkty` (`Id_produkty`),
  ADD CONSTRAINT `k2` FOREIGN KEY (`Zamowienia_id_Zamowienia`) REFERENCES `zamowienia` (`Id_Zamowienia`);

--
-- Ograniczenia dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  ADD CONSTRAINT `U` FOREIGN KEY (`Klienci_Id_Klienci`) REFERENCES `klienci` (`Id_Klienci`),
  ADD CONSTRAINT `U2` FOREIGN KEY (`Pracownicy_Id_Pracownicy`) REFERENCES `pracownicy` (`Id_Pracownika`),
  ADD CONSTRAINT `U3` FOREIGN KEY (`Dostawcy_Id_Dostawcy`) REFERENCES `dostawcy` (`id_Dostawcy`);

--
-- Ograniczenia dla tabeli `zamowienia`
--
ALTER TABLE `zamowienia`
  ADD CONSTRAINT `K_U` FOREIGN KEY (`Uzytkownicy_Id_Uzytkownicy`) REFERENCES `uzytkownicy` (`Id_Uzytkownicy`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
