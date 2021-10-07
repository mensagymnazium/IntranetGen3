# Seedování dat

Aby se dala aplikace snadno vyvíjet a předvádět, potřebujeme ji naplnit základními číselníky (`CoreProfile`), popř. ukázkovými daty (`DemoProfile`).

Říká se tomu "seed" (čenglicky "seedování"), kdy aplikace sama, obvykle při spuštění (`CoreProfile`) nebo na kliknutí z administrace (`DemoProfile`), provede naplnění sebe sama daty.

Entity Framework Core v sobě má nějaký [základní mechanizmus na přednaplnění databázových tabulek](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding),
nicméně tento je velmi primitivní, proto je v používaném stacku připraven custom mechanizmus seedování. Stačí do DataLayer/Seeds/... přidat třídu,
která bude dědit z `DataSeed<CoreProfile|DemoProfile>` (generický typ odkazuje na seed-profil, do kterého seed patří) a v ní už je potřeba udělat jen dva/tři základní úkony:

1. Připravit si data (pomocí tříd datového modelu)
2. Nastavit spouštění seedu (zejm. způsob párování na již existující záznamy)
3. Nastavit závislosti, tj. jaké seedy již musí být provedeny, aby mohl ten konkrétní proběhnout. Např. abych mohl seedovat předměty, musel již proběhnout seed typů předmětů, jinak by chyběly při ukládání do DB závislosti.

Nejlépe je toto všechno vidět na ukázkových seedech:
https://github.com/hakenr/GoranG3/tree/master/DataLayer/Seeds

Je k tomu i dokumentace, viz kapitola 1.5 - Seedování dat:
https://github.com/mensagymnazium/IntranetGen3/blob/master/doc/HAVIT%20Stack/HAVIT%20Stack%20-%20EF%20Core.pdf

## Spouštění seedů

Seedování `CoreProfile` se spouští automaticky při každém startu aplikace, odsud:
https://github.com/mensagymnazium/IntranetGen3/blob/f9d8f401700216ae291ad55ecf7ff129e655b726/Web.Server/Startup.cs#L129
https://github.com/mensagymnazium/IntranetGen3/blob/f9d8f401700216ae291ad55ecf7ff129e655b726/Web.Server/Tools/DatabaseMigration.cs#L25-L26

Seedování další profilů, zejména `DemoProfile` je nutno vyvolat z administračního UI aplikace:
https://github.com/mensagymnazium/IntranetGen3/tree/master/Web.Client/Pages/Admin/Components
