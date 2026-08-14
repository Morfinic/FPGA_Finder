# FPGA Card Finder

Aplikacja full-stack do wyszukiwania kart FPGA. Pozwala na filtrowanie, sortowanie 
oraz podgląd dziennika średniego dziennego wykorzystania.

---

## Struktura

### `Backend/` - ASP.NET Core Web Api (.NET 10)
| Katalog            | Odpowiedzialność |
|--------------------|------------------|
| `Api/Controllers/` |                  |
| `Api/Data/`        |                  |
| `Api/Models/`      |                  |
| `Api/Migrations/`  |                  |
| `Api/Services/`    |                  |

<br>

---

### `Frontent/` - Blazor Webassembly
| Katalog           | Odpowiedzialność |
|-------------------|------------------|
| `Api/Components/` |                  |
| `Api/Pages/`      |                  |

<br>

---

### `Shared/` - Współdzielona biblioteka

<br>

---

## Funkcjonalność

---

## Uruchomienie

### Wymagania
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Docker Desktop v4.86.0

<br>

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
docker compose up
```