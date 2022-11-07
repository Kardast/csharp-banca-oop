// See https://aka.ms/new-console-template for more information

//Banca:
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)

//FUNZIONALITà
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente. OK
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.

//p.s: per la modifica utente, non complichiamoci la vita, facciamo una interazione semplice tipo:
//vengono chiesti all’utente tutti i campi del cliente
//se viene premuto invio senza dati significa che il campo specifico non verrà modificato
//se invece viene scritto un valore allora andremo a modificare il campo con il nuovo valore
//ATTENZIONE: dato che abbiamo strutturato la ricerca utente in una funzione separata, la return ci permette di ragionare con i riferimenti? se non dovesse funzionare come dovremmo fare?

public class Banca
{
    //proprietà
    public string Nome { get; set; }
    List<Cliente> Clienti { get; set; }
    List<Prestito> Prestiti { get; set; }

    //costruttore
    public Banca(string nome)
    {
        Nome = nome;
        Clienti = new List<Cliente>();
        Prestiti = new List<Prestito>();
    }

    //Aggiungi clienti
    public bool AggiungiCliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {

        if (
            nome == null || nome == "" ||
            cognome == null || cognome == "" ||
            codiceFiscale == null || codiceFiscale == "" ||
            stipendio < 0
            )
        {
            return false;
        }

        Cliente esistente = RicercaCliente(codiceFiscale);

        //se il cliente esiste l'istanza sarà diversa dal null
        if (esistente != null)
            return false;

        Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
        Clienti.Add(cliente);

        return true;
    }

    //Stampa clienti
    public void StampaListaClienti()
    {
        foreach (Cliente cliente in Clienti)
        {
            Console.WriteLine("---");
            Console.WriteLine(cliente.Nome);
            Console.WriteLine(cliente.CodiceFiscale);
        }
    }

    //Ricerca clienti
    public Cliente RicercaCliente(string codiceFiscale)
    {

        foreach (Cliente cliente in Clienti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return cliente;
        }

        return null;
    }

    //Modifica clienti
    public void ModificaCliente(string userInput, string inputNome, string inputCognome, string inputCodFiscale, int inputStipendio)
    {
        foreach (Cliente cliente in Clienti)
        {
            if(cliente.CodiceFiscale == userInput)
            {
                if (inputNome != null)
                {
                    cliente.Nome = inputNome;
                }
                if (inputCognome != null)
                {
                    cliente.Cognome = inputCognome;
                }
                if (inputCodFiscale != null)
                {
                    cliente.CodiceFiscale = inputCodFiscale;
                }
                if (inputStipendio != null)
                {
                    cliente.Stipendio = inputStipendio;
                }
            }
        }
        StampaListaClienti();
    }

    //Aggiungi prestito
    public bool AggiungiPrestito(int ammontare, int valoreRata, DateOnly inizio, DateOnly fine, string codiceFiscale)
    {
        Cliente cliente = RicercaCliente(codiceFiscale);
        if (cliente == null)
            return false;
        Prestito mioPrestito = new Prestito(ammontare, valoreRata, inizio, fine, cliente);
        Prestiti.Add(mioPrestito);
        return true;
    }

    //Ricerca prestito
    public Prestito RicercaPrestito(string codiceFiscale)
    {
        Cliente cliente = RicercaCliente(codiceFiscale);
        foreach (Prestito prestito in Prestiti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return prestito;
        }

        return null;
    }

    //Stampa prestiti
    public void StampaListaPrestiti()
    {
        foreach (Prestito prestito in Prestiti)
        {
            Console.WriteLine("------------");
            Console.WriteLine("id prestito: " + prestito.ID);
            Console.WriteLine("Ammontare prestito: " + prestito.Ammontare);
            Console.WriteLine("ValoreRata prestito: " + prestito.ValoreRata);
            Console.WriteLine("Inizio prestito: " + prestito.Inizio);
            Console.WriteLine("Fine prestito: " + prestito.Fine);
            Console.WriteLine("Intestatario prestito: " + prestito.Intestatario.Cognome);
        }
    }
}