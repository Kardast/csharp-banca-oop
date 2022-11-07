// See https://aka.ms/new-console-template for more information
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");
//Consigli:
//Oggi cerchiamo di migliorare un pochino l’approccio nella costruzione di un codice ad oggetti, ben suddiviso tra diverse responsabilità.
//Il program.cs si occuperà quindi di gestire tutti i console.writeline/readline mentre
//le classi di dominio del nostro progetto devono occuparsi solo della logica applicativa e fare dei controlli dei dati quando questi violano qualche logica.
//Esempio, quando un cliente non può chiedere più prestiti? quale entità potrebbe occuparsi di questo controllo?
//Non dimentichiamoci però che abbiamo aggiunto la keyword static, quale parametro di quale entità potrebbe essere trasformato in STATIC così come abbiamo visto negli esempi?

//Consegna:
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.

//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

//snippet per data di oggi
//var dateNow = DateOnly.FromDateTime(DateTime.Now);

Banca fineco = new Banca("Fineco");
fineco.AggiungiCliente("sandro", "ficini", "prova", 500);
fineco.AggiungiCliente("federica", "elia", "fdrela45677", 1500);
fineco.AggiungiCliente("pippo", "ippo", "ppppp3457", 500);
fineco.AggiungiCliente("chicco", "pepe", "cccpp4859", 800);
//copia che non viene stampata grazie al controllo sui doppioni
fineco.AggiungiCliente("sandro", "ficini", "fcnsdr9327", 500);



fineco.StampaListaClienti();
fineco.ModificaCliente();