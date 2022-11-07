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
//DateTime inizioMod = inizio.ToDateTime(TimeOnly.Parse("10:00 PM"));
//DateTime fineMod = fine.ToDateTime(TimeOnly.Parse("10:00 PM"));
//if (cliente.Stipendio / 2 < ammontare / (fineMod.Subtract(inizioMod).Days / 30))
//    return false;

Banca fineco = new Banca("Fineco");
//utenti
fineco.AggiungiCliente("sandro", "ficini", "prova", 500);
fineco.AggiungiCliente("federica", "elia", "fdrela45677", 1500);
fineco.AggiungiCliente("pippo", "ippo", "ppppp3457", 500);
fineco.AggiungiCliente("chicco", "pepe", "cccpp4859", 800);
//copia che non viene stampata grazie al controllo sui doppioni
fineco.AggiungiCliente("sandro", "ficini", "fcnsdr9327", 500);

//prestiti
fineco.AggiungiPrestito(2000, 200, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("12/12/2023"), "prova");
fineco.AggiungiPrestito(3000, 300, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("12/12/2023"), "prova");


Console.WriteLine("Seleziona l'azione");
Console.WriteLine("0: Lista clienti");
Console.WriteLine("1: Modifica utente");
Console.WriteLine("2: Cerca cliente");
Console.WriteLine("3: Aggiungi un prestito");
Console.WriteLine("4: Cerca un prestito");
Console.WriteLine("5: Stampa tutti i prestiti");


int action = Convert.ToInt32(Console.ReadLine());
switch (action)
{
    case 0:
        //Lista clienti
        fineco.StampaListaClienti();
        break;

    case 1:
        //Modifica utente
        Console.WriteLine("Inserisci il codice fiscale dell'utente che vuoi modificare");
        string userInput = Console.ReadLine();
        Console.WriteLine("Inserisci in ordine i dati da modificare (nome, cognome, cod fiscale, stipendio");
        string inputNome = Console.ReadLine();
        string inputCognome = Console.ReadLine();
        string inputCodFiscale = Console.ReadLine();
        int inputStipendio = Convert.ToInt32(Console.ReadLine());
        fineco.ModificaCliente(userInput, inputNome, inputCognome, inputCodFiscale, inputStipendio);
        break;

    case 2:
        //Cerca cliente
        Console.WriteLine("Inserisci il codice fiscale dell'utente che vuoi cercare");
        string userInputRicerca = Console.ReadLine();
        Cliente cercaCliente = fineco.RicercaCliente(userInputRicerca);
        if (cercaCliente != null)
            Console.WriteLine("nome: " + cercaCliente.Nome + ", stipendio: " + cercaCliente.Stipendio);
        break;

    case 3:
        //Aggiungi un prestito
        Console.WriteLine("Inserisci in ordine i dati dal prestito (ammontare prestito, valore rata, fine prestito, cod fiscale)");
        int ammontare = Convert.ToInt32(Console.ReadLine());
        int valoreRata = Convert.ToInt32(Console.ReadLine());
        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        var dateEnd = DateOnly.Parse(Console.ReadLine());
        string inputCodFiscaledue = Console.ReadLine();

        fineco.AggiungiPrestito(ammontare, valoreRata, dateNow, dateEnd, inputCodFiscaledue);
        fineco.AggiungiPrestito(1500, 150, dateNow, dateEnd, "fdrela45677");

        break;

    case 4:
        //Cerca prestito
        Console.WriteLine("Inserisci il codice fiscale dell'utente associato al prestito che vuoi cercare");
        string userInputPrestito = Console.ReadLine();
        Prestito cercaPrestito = fineco.RicercaPrestito(userInputPrestito);
        if (cercaPrestito != null)
            Console.WriteLine("------------");
            Console.WriteLine("id prestito: " + cercaPrestito.ID);
            Console.WriteLine("Ammontare prestito: " + cercaPrestito.Ammontare);
            Console.WriteLine("ValoreRata prestito: " + cercaPrestito.ValoreRata);
            Console.WriteLine("Inizio prestito: " + cercaPrestito.Inizio);
            Console.WriteLine("Fine prestito: " + cercaPrestito.Fine);
            Console.WriteLine("Intestatario prestito: " + cercaPrestito.Intestatario.Cognome);
        break;

    case 5:
        //Stampa lista prestiti
        fineco.StampaListaPrestiti();
        break;
}




