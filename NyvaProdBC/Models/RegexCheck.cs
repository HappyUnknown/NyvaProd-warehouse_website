namespace NyvaProdBC
{
    public static class RegexCheck
    {
        public const string cellPattern = @"^\+(?:[0-9]●?){6,14}[0-9]$";

        public static bool IsCellNumber(string line)
        {
            if (line != null) return System.Text.RegularExpressions.Regex.IsMatch(line, cellPattern);
            else return false;
        }
        public static bool IsEmail(string line)
        {
            try { var mailAddr = new System.Net.Mail.MailAddress(line); } catch { return false; }
            return true;
        }
    }
}