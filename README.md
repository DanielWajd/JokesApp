Aplikacja internetowa do postowania żartów i ich ocen.

Uruchamianie aplikacji:
  1. Skopiować repozytorium na swój komputer
  2. Otworzyć aplikację w programie Visual Studio korzystając z pliku .sln
  3. W razie potrzeby doinstalować wymagane pakiety NuGet:
       - Microsoft.AspNetCore.Identity.EntityFrameworkCore
       - Microsoft.EntityFrameworkCore
       - Microsoft.EntityFrameworkCore.SqlServer
       - Microsoft.EntityFrameworkCore.Tools
  4. Dodać do projektu plik "appsettings.json", z connection stringiem do bazy danych, gdyż z kwesti bezpieczeństwa repozytorium go nie zawiera. Przykład pliku:
     {
     "ConnectionStrings": {
    "DefaultConnection": "Server=[nazwa];Trusted_Connection=True;TrustServerCertificate=True;"}
      }
  5. Otworzyć konsole pakietów NuGet i zaktualizować baze danych poleceniem : "Update-Database"
  6. Uruchomić aplikacje zielonym przyciskiem
  7. Po utworzeniu konta / zalogowaniu użytkowik może swobodnie dodawać żarty i je edytować

