using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace DomainComputersInfo
{
    public class GetComputers
    {
        //===============================================================================================
        public static List<String> GetFromAD(String DomainName)
        {
            PrincipalContext CurrentPrincipalContext = new(ContextType.Domain, DomainName);
            ComputerPrincipal CurrentComputerPrincipal = new(CurrentPrincipalContext);
            PrincipalSearcher search = new(CurrentComputerPrincipal);

            List<String> PCnames = new();

            foreach (ComputerPrincipal result in search.FindAll())
            {
                if ((bool)result.Enabled)
                    PCnames.Add(result.Name + "." + DomainName);
            }
            search.Dispose();

            return PCnames;
        }
        //===============================================================================================
        public static List<String> GetManual(String DomainName, String PCName, List<String> PCNames)
        {
            PCNames.Add(PCName + "." + DomainName);

            return PCNames;
        }
        //===============================================================================================
    }
}