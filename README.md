Aplikacja internetowa do postowania żartów i ich ocen.

Użytkowik ma możliwość dzielenia się żartami z innymi użytkownikami aplikacji! Dodatkowo może on oceniać inne żarty.
Posiada możliwość edycji i usuwania kawałów.

Uruchamianie aplikacji:
  1. Skopiować repozytorium na swój komputer
  2. Otworzyć aplikację w programie Visual Studio korzystając z pliku .sln
  3. W razie potrzeby doinstalować wymagane pakiety NuGet:
  (Narzędzia -> Menadżer Pakietów NuGet -> Zarządzaj)
       - Microsoft.AspNetCore.Identity.EntityFrameworkCore  8.0.10
       - Microsoft.EntityFrameworkCore  9.00
       - Microsoft.EntityFrameworkCore.SqlServer  9.0.0
       - Microsoft.EntityFrameworkCore.Tools  9.0.0
  4. Dodać do projektu plik "appsettings.json", z connection stringiem do bazy danych, gdyż z kwesti bezpieczeństwa repozytorium go nie zawiera. Przykład pliku:
     
    "ConnectionStrings": {
        "DefaultConnection": "[nazwa];Trusted_Connection=True;TrustServerCertificate=True;"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"

  5. Otworzyć konsole pakietów NuGet i zaktualizować baze danych poleceniem : ```"Update-Database"```
  6. Uruchomić aplikacje zielonym przyciskiem
  7. Powinno uruchomić się okno przeglądarki
  8. Po utworzeniu konta / zalogowaniu użytkownik może swobodnie dodawać żarty i je edytować

