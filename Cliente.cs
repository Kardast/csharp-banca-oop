// See https://aka.ms/new-console-template for more information

//Cliente:
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
public class Cliente
{
    //attributi
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }

    //qui non serve perchè è già in banca e anche in Prestito c'è la relazione con il cliente
    //public List<Prestito> Prestiti { get; set; }

    //costruttore
    public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;
    }
}