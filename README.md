# FPGA Card Finder

Aplikacja full-stack do wyszukiwania i filtrowania kart FPGA. Umożliwia podgląd 
szczegółowych danych technicznych oraz analizę średniego dziennego wykorzystania 
kart na przestrzeni czasu.

---

## Struktura

### `Backend/` - ASP.NET Core Web Api (.NET 10)
| Katalog            | Odpowiedzialność                                                          |
|--------------------|---------------------------------------------------------------------------|
| `Backend/Controllers/` | Warstwa HTTP - obsługa żądań REST API                                     |
| `Backend/Data/`        | Konfiguracja EF Core, definicja kontekstu bazy danych i seedowanie danych |
| `Backend/Models/`      | Encje bazodanowe                                                          |
| `Backend/Migrations/`  | Pliki migracji bazy danych (Entity Framework Core)                                                                          |
| `Backend/Services/`    | Logika biznesowa                                                          |

---

### `Frontend/` - Blazor Webassembly
| Katalog                | Odpowiedzialność                                                |
|------------------------|-----------------------------------------------------------------|
| `Frontend/Components/` | Komponenty wielokrotnego użytku                                 |
| `Frontend/Pages/`      | Strony aplikacji                                                |
| `Frontend/Services/`   | Wszystkie zapytania do Api zebrane w jednej klasie pomocnieczej |
| `Frontend/Models/`     | Modele pomocnicze Frontendu                                     |

---

### `Shared/` - Współdzielona biblioteka
Projekt do którego odwołuje się zarówno `Backend` jak i `Frontend`.

---

## Funkcjonalność
| Metoda   | Endpoint                        | Opis                                                 |
|----------|---------------------------------|------------------------------------------------------|
| `GET`    | `/api/FpgaCard`                 | Zwraca listę wszystkich kart                         |
| `GET`    | `/api/FpgaCard/{id}`            | Zwraca jedną kartę po ID                             |
| `GET`    | `/api/FpgaCard/filter`          | Zwraca listę kart stosując filtr                     |
| `GET`    | `/api/UsageLogs/card/{card_id}` | Zwraca listę dziennika dziennego zużycia karty po ID |

---

## Uruchomienie
Cały stos aplikacyjny (Frontedn, Backend oraz Baza danych) został skonfigurowany przy użyciu Docker Compose.
Baza danych jest automatycznie tworzona przy uruchomieniu aplikacji (modele + zasiewanie danymi).

### Wymagania
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Docker Desktop v4.86.0 (lub nowszy) z uruchomioną usługą Docker Engine

---

### Krok 1 - Sklonuj repozytorium
```bash
git clone https://github.com/Morfinic/FPGA_Finder.git
cd FPGA_Finder
```
---

### Krok 2 - Uruchom docker desktop

---

### Krok 3 - Uruchom aplikację
```bash
docker compose up --build
```

Powyższe polecenie automatycznie pobierze obraz TimescaleDB, zbuduje kontenery, 
zaaplikuje migrację oraz zainicjalizuje bazę danych.

| Usługa   | URL                            | Opis                              |
|----------|--------------------------------|-----------------------------------|
| Backend  | `http://localhost:8080`        | Główny endpoint REST API          |
| Scalar   | `http://localhost:8080/scalar` | Interaktywna dokumentacja API     |
| Frontend | `http://localhost:5079`        | Główny endpoint aplikacji webowej |

## Zrealizowane dodatkowe funkcjonalności
* TimescaleDB
* Sortowanie i paginacja
* Prosta responsywność

## Podjęte decyzje techniczne
* Wykorzystanie Scalar: Wykorzystano dokumentację OpenAPI ze względu na większą znajomość narzędzia.
* Docker Compose: Spięcie bazy danych, api oraz klienta w jeden plik compose.yaml umożliwia przygotowanie i uruchomienie 
środowiska jedną komendą.
* Współdzielone elemty `Shared/`: Wykorzystanie architektury .NET pozwoliło na używanie tych samych obiektów po obu 
stronach. Pozwoliło to na uniknięcie rozsynchronizowania typów pomiędzy frontendem i backendem.
* Wykorzystanie komponentów: Pozwoliło na stworzenie czytelniejszego oraz prostszego w zarządzaniu kodu.
* Dodanie klasy pomocniczej zapytań http: Odizolowano komunikację API do dedykowanej klasy zamiast wykonywać je bezpośrednio]
z poziomu widoku

## Co zrobiłym inaczej
* Wykonanie paginacji po stronie serwera: Dla małej ilości danych paginacja na danych w pamięci może być akceptowalna, 
lecz dla znacząco większej ilości danych może skutkować gorszą wydajnością.