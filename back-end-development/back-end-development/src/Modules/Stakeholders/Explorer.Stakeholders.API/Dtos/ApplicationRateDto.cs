namespace Explorer.Stakeholders.API.Dtos
{
    using System;

    public class ApplicationRateDto
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public long? PersonId { get; set; }
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
