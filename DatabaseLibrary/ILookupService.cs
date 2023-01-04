namespace DatabaseLibrary
{
    public interface ILookupService
    {
        public int GetLookupItemIdByValue(string lookupName, string description);
    }
}
