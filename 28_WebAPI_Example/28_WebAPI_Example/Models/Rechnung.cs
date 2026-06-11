namespace _28_WebAPI_Example.Models
{
    public class Rechnung
    {
        public int Id { get; set; }
        public int Zahl1 { get; set; }
        public int Zahl2 { get; set; }
        public string op {  get; set; } //Operator +, -, *, /
        public int Ergebnis { get; set; }
    }
}
