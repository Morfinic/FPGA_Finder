# FPGA Card Finder

Aplikacja full-stack do wyszukiwania i filtrowania kart FPGA. Umożliwia podgląd 
szczegółowych danych technicznych oraz analizę średniego dziennego wykorzystania 
kart na przestrzeni czasu.

---

## Struktura

### `Backend/` - ASP.NET Core Web Api (.NET 10)
| Katalog            | Odpowiedzialność                                                          |
|--------------------|---------------------------------------------------------------------------|
| `Api/Controllers/` | Warstwa HTTP - obsługa żądań REST API                                     |
| `Api/Data/`        | Konfiguracja EF Core, definicja kontekstu bazy danych i seedowanie danych |
| `Api/Models/`      | Encje bazodanowe                                                          |
| `Api/Migrations/`  | Pliki migracji bazy danych (Entity Framework Core)                                                                          |
| `Api/Services/`    | Logika biznesowa                                                          |

---

### `Frontend/` - Blazor Webassembly
| Katalog           | Odpowiedzialność                |
|-------------------|---------------------------------|
| `Api/Components/` | Komponenty wielokrotnego użytku |
| `Api/Pages/`      | Strony aplikacji                |

---

### `Shared/` - Współdzielona biblioteka

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

### Wymagania
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Docker Desktop v4.86.0

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

| Usługa   | URL                            | Opis                              |
|----------|--------------------------------|-----------------------------------|
| Backend  | `http://localhost:8080`        | Główny endpoint REST API          |
| Scalar   | `http://localhost:8080/scalar` | Interaktywna dokumentacja API     |
| Frontend | `http://localhost:5079`        | Główny endpoint aplikacji webowej |