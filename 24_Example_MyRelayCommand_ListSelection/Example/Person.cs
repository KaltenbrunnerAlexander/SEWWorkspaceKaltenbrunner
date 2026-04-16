namespace Example
{
    class Person
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public override string ToString()
        {
            return Name + " Mail: " + EMail;
        }
    }
}
