namespace Explorer.API.Controllers
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// LINQ extension that should be called last to get paged items. Includes ordering by Id.
        /// </summary>
        public static long GetPersonId(this HttpContext source)
        {
            try
            {
                
                return long.Parse(source?.User?.Claims?.FirstOrDefault(c => c.Type == "personId")?.Value);

            }
            catch (Exception e)
            {
                throw new Exception("Person id is not valid. " + e.Message);
            }
        }
    }
}
