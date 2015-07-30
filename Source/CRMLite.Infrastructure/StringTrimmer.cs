namespace CRMLite.Infrastructure
{
   public class StringTrimmer
    {
        public static string QuotesRemover(string path,string filename)
        {
            string returnValue=path+filename.Trim('"');
            return returnValue;
        }
    }
}
