# APBD PC Components API



Projekt przedstawia REST API do zarządzania komputerami oraz ich komponentami. Aplikacja została wykonana z użyciem ASP.NET Core Web API, Entity Framework Core oraz podejścia Code First.

## Technologie

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Rider
- Git / GitHub

## Baza danych

Projekt wykorzystuje SQL Server LocalDB.

Connection string znajduje się w pliku `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apbd;Integrated Security=True;"
  }
}
```

Nazwa bazy danych:

```txt
apbd
```

## Struktura projektu

```txt
Configurations/
Controllers/
Data/
DTOs/
Entities/
Exceptions/
Migrations/
Services/
```

Opis folderów:

- `Entities` — klasy encji odwzorowujące tabele bazy danych.
- `Configurations` — konfiguracje encji EF Core z użyciem Fluent API.
- `Data` — kontekst bazy danych `AppDbContext`.
- `DTOs` — klasy DTO dla danych wejściowych i wyjściowych API.
- `Services` — warstwa logiki aplikacji.
- `Controllers` — kontrolery REST API.
- `Exceptions` — własne klasy wyjątków.
- `Migrations` — migracje Entity Framework Core.

## Encje

Projekt zawiera następujące encje:

- `PC`
- `Component`
- `ComponentType`
- `ComponentManufacturer`
- `PCComponent`

Relacje:

- jeden `PC` może mieć wiele wpisów `PCComponent`,
- jeden `Component` może występować w wielu wpisach `PCComponent`,
- jeden `ComponentType` może mieć wiele komponentów,
- jeden `ComponentManufacturer` może mieć wiele komponentów,
- `PCComponent` jest tabelą pośrednią z kluczem złożonym `PCId + ComponentCode`.

## Seed data

Baza danych jest wypełniana przykładowymi danymi startowymi przy użyciu `HasData()`.

Dodane są minimum 3 rekordy dla głównych tabel:

- `PCs`
- `Components`
- `ComponentTypes`
- `ComponentManufacturers`

Tabela `PCComponents` zawiera przykładowe powiązania komputerów z komponentami.

## Endpointy

### Pobranie wszystkich komputerów

```http
GET /api/pcs
```

Zwraca listę komputerów z podstawowymi informacjami.

Przykładowa odpowiedź:

```json
[
  {
    "id": 1,
    "name": "Gaming Beast X",
    "weight": 12.5,
    "warranty": 36,
    "createdAt": "2026-05-08T09:00:00",
    "stock": 5
  }
]
```

### Pobranie komponentów komputera

```http
GET /api/pcs/{id}/components
```

Zwraca komputer wraz z przypisanymi komponentami.

Jeśli komputer nie istnieje, zwracany jest status:

```txt
404 Not Found
```

### Dodanie komputera

```http
POST /api/pcs
```

Przykładowe body:

```json
{
  "name": "Student Lab PC",
  "weight": 6.5,
  "warranty": 24,
  "createdAt": "2026-05-21T12:00:00",
  "stock": 7
}
```

Po poprawnym dodaniu zwracany jest status:

```txt
201 Created
```

### Aktualizacja komputera

```http
PUT /api/pcs/{id}
```

Przykładowe body:

```json
{
  "name": "Updated Student Lab PC",
  "weight": 7.1,
  "warranty": 36,
  "createdAt": "2026-05-21T12:00:00",
  "stock": 10
}
```

Po poprawnej aktualizacji zwracany jest status:

```txt
200 OK
```

Jeśli komputer nie istnieje, zwracany jest status:

```txt
404 Not Found
```

### Usunięcie komputera

```http
DELETE /api/pcs/{id}
```

Po poprawnym usunięciu zwracany jest status:

```txt
204 No Content
```

Jeśli komputer nie istnieje, zwracany jest status:

```txt
404 Not Found
```

## Uruchomienie projektu

1. Sklonuj repozytorium:

```bash
git clone git@github.com:Hemimaster/APBD-PC-Components-API.git
```

2. Przejdź do folderu projektu:

```bash
cd APBD-PC-Components-API
```

3. Upewnij się, że działa SQL Server LocalDB:

```bash
sqllocaldb info MSSQLLocalDB
```

4. Jeśli baza nie istnieje, wykonaj migracje:

```bash
dotnet ef database update
```

5. Uruchom projekt:

```bash
dotnet run
```

Domyślny adres aplikacji:

```txt
http://localhost:5136
```

## Migracje

Projekt zawiera migrację `InitialCreate`, która tworzy strukturę bazy danych oraz dodaje dane startowe.

Przydatne komendy EF Core:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Testowanie

Endpointy były testowane przy użyciu:

- przeglądarki dla metod `GET`,
- Postmana dla metod `POST`, `PUT`, `DELETE`,
- SQL Server Management Studio do sprawdzenia bazy danych i seed data.

Sprawdzone statusy HTTP:

- `200 OK`
- `201 Created`
- `204 No Content`
- `404 Not Found`

## Autor
#### Grzegorz Wojewódzki
