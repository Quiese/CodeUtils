using System;
using System.Security.Cryptography.X509Certificates;

namespace CodeUtils
{
    public static class Certificate
    {
        public static X509Certificate2 GetFromListRepository()
        {
            var oX509Cert = new X509Certificate2();
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection = store.Certificates;
            var collection2 = collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);

            var scollection = X509Certificate2UI.SelectFromCollection(collection2,
                "Certificados Disponívelis", "Selecione o Certificado Digital para uso no aplicativo",
                X509SelectionFlag.SingleSelection);

            return (collection2.Count == 0 || scollection.Count == 0) ? null : scollection[0];
        }

        public static X509Certificate2 GetBySerialNumber(string serialNumber)
        {
            var oX509Cert = new X509Certificate2();
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection1 = store.Certificates
                .Find(X509FindType.FindByTimeValid, DateTime.Now, false)
                .Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true)
                .Find(X509FindType.FindBySerialNumber, serialNumber, false);

            return (collection1.Count == 0 || collection1.Count == 0) ? null : collection1[0];
        }

        public static X509Certificate2 GetBySubjectName(string subjectName)
        {
            var oX509Cert = new X509Certificate2();
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection1 = store.Certificates
                .Find(X509FindType.FindByTimeValid, DateTime.Now, false)
                .Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true)
                .Find(X509FindType.FindBySubjectName, subjectName, false);

            return (collection1.Count == 0 || collection1.Count == 0) ? null : collection1[0];
        }

    }
}