namespace domain
{
    public class Category
    {   
        public Category ()
        {

        }
        public Category(int Id, string Desc) { 
            Description = Desc;
            this.Id = Id;
        }
        public int Id { get; set; }
        
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}