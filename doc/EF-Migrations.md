# Entity Framework - Migrace

Viz též https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs

Migrace se spouští automaticky při každém spuštění projektu.

Pozor na unit-test [IntranetGen3DbContext_CheckModelConventions](https://github.com/mensagymnazium/IntranetGen3/blob/e73342c6afafcdf2f81ec6915d8940e0e8a10906/Entity.Tests/IntranetGen3DbContextTests.cs#L12), který hlídá základní konvence datového modelu.

## Vytvoření nové migrace
Po změně datového modelu je potřeba promítnout změny do databází.
1. Visual Studio - Package Manager Console
2. Default project si nastavím na Server\Entity (tam chceme migrace směřovat)
3. Dávám příkaz
```
Add-Migration <NázevMigrace> -StartupProject Entity.Tests
```
Migrace se aplikuje u každého na jeho DB spuštěním aplikace. To platí i pro autora migrace, do DB se to dostane následným spuštěním aplikace.

Pokud se nedaří, datový model je potřeba ještě upravit a migraci vytvořit znovu (pokud jsem ji ještě necommitoval, resp. nepushnul do GitHub) je možné migraci odvolat
```
Remove-Migration -StartupProject Entity.Tests
```
...tím se dropne poslední migrace (z projektu, nikoliv z DB, tu může být potřeba založit znovu, viz níže).

## Zahození databáze
Někdy může být potřeba zahodit lokální databázi a nechat ji vytvořit znovu. Např. pokud tzv. resetujeme migrace a začínáme verzovat nové schéma DB.
1. Visual Studio - Package Manager Console
2. Default project si nastavím na Server\Entity (tam chceme migrace směřovat)
3. Dávám příkaz
```
Drop-Database -StartupProject Entity.Tests
```
