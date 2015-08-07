using System;

namespace Model.Entities
{
    public class Feed : IGenericModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }

        public virtual Resource Resources { get; set; }

    }
}

