# Metode i tehnike testiranja programske podrške - projektni zadatak!

U ovom projektu je rješen problem testiranja web api krajnjih točaka koje zahtjevaju autentikaciju korisnika.
Za autentikaciju je korišten jwt(JSON web token), a alat koji riješava ovaj problem je JMeter.

# Web api dummy aplikacija

Za potrebe prikazivanja i rješavanja ovog problema kreirao sam dummy web api aplikaciju u .NET-u
Koraci:

 - Zaštita GET rute sa Auth guardom:
    
![image](https://github.com/user-attachments/assets/739ff20b-3234-406a-89f2-7f842b3d80e1)
 - Registracija zahtjeva za JWT autentikacijom:
![image](https://github.com/user-attachments/assets/318e7477-374f-41bc-ad58-277c058b7136)
 - Implementacija klase koja generira JWT token:
![image](https://github.com/user-attachments/assets/1364124c-5ed9-4426-b7b4-2a97765e82d3)
 - krajnja točka za dohvat validnog JWT tokena:
 ![image](https://github.com/user-attachments/assets/f5cd396a-af49-4605-8bae-5a37bcea4c75)

# JMeter rješenje problema

Prije testiranja želljenog endpointa potrebno je obaviti autentikaciju, zatim spremiti dohvaćeni token te taj isti token staviti u zaglavlje http zahtjeva za željenu krajnju točku.

 - Obavljanje autentikacije
	 - definiranje poziva na krajnju točku
	 
		
		![image](https://github.com/user-attachments/assets/9c0b532e-2aaa-4a13-a5f3-ec8acd24b566)
najvažnije je postaviti metodu(POST), protokol(https), adresu računala(localhost), port na kojem sluša(44313)
	 - skripta za spremanje odgovora
	 
		![image](https://github.com/user-attachments/assets/6539f6ad-a3b8-49f5-aec8-c2eb36e19b71)
Skripta se izvrši nakon što se zahtjev završi, pročita tijelo odgovora te preprty pod imenom "accessToken" spremi u varijablu koja se također zove accessToken
 - Slanje zahtjeva sa dohvaćenim podatcima za autentikaciju
 
	 - HTTP Header Manager
	 Potrebno je dodati komponentu HTTP Header Manager u kojoj se definira zaglavlje zahtjeva na krajnju točku koju ćemo testirati
	 
		![image](https://github.com/user-attachments/assets/dcc1af64-5e70-4693-a1d8-65dda2e4fd1a)
		globalnu varijablu "accessToken" postavljeamo u zaglavlje za autentikaciju (Bearer "accessToken") 
	 - Slanje zahtjeva
		 Nakon što smo obavili autentikaciju i učitali u zaglavlje zahtjeva, možemo napokon definirati ostatak zahtjeva
		 
		![image](https://github.com/user-attachments/assets/1656c5c5-0c3c-4382-af72-69ef94800e29)
Stvorimo novu HTTP request komponentu i definiramo port, protokol, računalo, putanju do resursa i metodu zahtjeva

## Kako Pokrenuti Aplikaciju

Potrebno:

 - Web api aplikacija
	 - klonirati repozitorij i buildati .net aplikaciju lokalno
	 - aplikacija se može pokrenuti na više načina, sve je definirano u Properties/launchSettings.json datoteci
	 - ovisno prema načinu pokretanja web api aplikacije potrebno je podesiti port u jmeteru(ja sam pokretao aplikaciju preko IIS expresa te sam stoga definirao port 44313)
 - JMeter
	 - verzija 5.6.2
	 - otvoriti JMeter aplikaciju i importati .jmx file koji je dohvacen sa repozitorija
	 - takoder moze i preko komandne linije (preporučam kroz aplikaciju radi vizualizacije)
